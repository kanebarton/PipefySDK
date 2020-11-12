using Axis.PipefySdk.Models.Events;
using Axis.PipefySdk.Mutations;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Axis.PipefySdk
{
    public interface IPipefyClient
    {
        string PipefyApiEndPoint { get; set; }
        Task<T> QueryAsync<T>(object request);

        Task<PipefyClientMutationResult> MutationAsync(object request);
        Task<PipefyClientMutationResult> MutationsAsync(IEnumerable<object> requests);
    }

    public class PipefyClient : IPipefyClient
    {
        private readonly static HttpClient InternalHttpClient = new HttpClient();
        private readonly static ConcurrentDictionary<Type, bool> ResponsePagingRequiredDictionary = new ConcurrentDictionary<Type, bool>();

        public event EventHandler<MutationProgressEventArgs> OnMutationProgressChanged;
        public event EventHandler<QueryProgressEventArgs> OnQueryProgressChanged;

        /// <summary>
        /// Creates an instance of the Axis Pipefy client. You should create this as a static 
        /// </summary>
        /// <param name="authToken">Your personal access token provided by Pipefy.</param>
        public PipefyClient(string authToken)
            : this(authToken, "https://api.pipefy.com/graphql")
        { }

        /// <summary>
        /// Creates an instance of the Axis Pipefy client. You should create this as a static 
        /// </summary>
        /// <param name="authToken">Your personal access token provided by Pipefy.</param>
        /// <param name="apiEndPoint">The end point for the Pipefy API. Defaults to: https://api.pipefy.com/graphql </param>
        public PipefyClient(string authToken, string apiEndPoint)
        {
            PipefyApiEndPoint = apiEndPoint;
            InternalHttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");
        }

        public string PipefyApiEndPoint { get; set; }

        public async Task<T> QueryAsync<T>(object request)
        {
            var response = await ExecuteGraphQueryCommandAsync(request);
            var result = await response.Content.ReadFromJsonAsync<T>();
            var queryEventArgs = new QueryProgressEventArgs { };

            if (ResponseSupportsPaging(result))
            {
                var responseResult = result as IPipefyPagedResponse;
                if (responseResult != null && responseResult.QueryPageInfo.HasNextPage)
                {
                    (request as PipefyRequestBase).GraphFilterCursor = responseResult.QueryPageInfo.EndCursor;

                    var counter = 0;
                    while (counter < 1000) // this will limit to a maximum of 50,000 cards assuming Pipefy stick to their 50 card per page limit
                    {
                        var pagedResponse = await ExecuteGraphQueryCommandAsync(request);
                        var pagedResult = await pagedResponse.Content.ReadFromJsonAsync<T>();

                        var recordsAddedCount = responseResult.AppendData(pagedResult);
                        queryEventArgs.RecordsAddedCount = recordsAddedCount;

                        var pagedResponseData = (pagedResult as IPipefyPagedResponse);
                        if (pagedResponseData?.QueryPageInfo?.HasNextPage ?? false)
                        {
                            queryEventArgs.AnotherPage = true;
                            OnQueryProgressChanged?.Invoke(this, queryEventArgs);

                            (request as PipefyRequestBase).GraphFilterCursor = pagedResponseData.QueryPageInfo.EndCursor;
                        }
                        else
                        {
                            queryEventArgs.AnotherPage = false;
                            OnQueryProgressChanged?.Invoke(this, queryEventArgs);

                            break;
                        }
                    }
                }

                responseResult.ApplyRequestFiltering(request as IPipefyRequest);
            }

            return result;
        }

        public async Task<PipefyClientMutationResult> MutationAsync(object request)
        {
            var result = new PipefyClientMutationResult { AllSuccess = true };
            var mutationEventArgs = new MutationProgressEventArgs { MaximumIndex = 1 };

            var response = await ExecuteGraphQueryCommandAsync(request);
            var mutationResponse = await response.Content.ReadFromJsonAsync<MutationResponse>();

            mutationEventArgs.ProgressIndex++;
            if (mutationEventArgs.ShouldRaiseEvent)
            {
                OnMutationProgressChanged?.Invoke(this, mutationEventArgs);
            }

            if (!mutationResponse.Success)
            {
                result.AllSuccess = false;
            }
            result.Responses.Add(mutationResponse);

            return result;
        }

        public async Task<PipefyClientMutationResult> MutationsAsync(IEnumerable<object> requests)
        {
            var result = new PipefyClientMutationResult { AllSuccess = true };
            var mutationEventArgs = new MutationProgressEventArgs { MaximumIndex = requests.Count() };

            foreach (var request in requests)
            {
                var response = await ExecuteGraphQueryCommandAsync(request);
                var mutationResponse = await response.Content.ReadFromJsonAsync<MutationResponse>();

                mutationEventArgs.ProgressIndex++;
                if (mutationEventArgs.ShouldRaiseEvent)
                {
                    OnMutationProgressChanged?.Invoke(this, mutationEventArgs);
                }

                if (!mutationResponse.Success)
                {
                    result.AllSuccess = false;
                }
                result.Responses.Add(mutationResponse);
            }

            return result;
        }

        private bool ResponseSupportsPaging<T>(T response)
        {
            if (ResponsePagingRequiredDictionary.ContainsKey(typeof(T)))
            {
                return ResponsePagingRequiredDictionary[typeof(T)];
            }

            var requiresPaging = (response as IPipefyPagedResponse) != null;

            ResponsePagingRequiredDictionary.TryAdd(typeof(T), requiresPaging);
            return requiresPaging;
        }

        private async Task<HttpResponseMessage> ExecuteGraphQueryCommandAsync(object request)
        {
            var jsonRequest = JsonSerializer.Serialize(request);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, PipefyApiEndPoint)
            {
                Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
            };

            var response = await InternalHttpClient.SendAsync(httpRequest);
            response.EnsureSuccessStatusCode();

            return response;
        }
    }
}
