using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Queries
{
    public class AllCardsRequest : PipefyRequestBase
    {
        private static readonly string _query = EmbeddedManager.CommandDictionary[$"{typeof(AllCardsRequest).FullName}.ql"];
        private readonly string _pipeId = "0";

        public AllCardsRequest(long pipeId)
        : this(pipeId.ToString()) { }

        public AllCardsRequest(string pipeId)
        {
            _pipeId = pipeId;
        }

        [JsonPropertyName("query")]
        public string Query => _query.Replace(PipefyConsts.FilterParameters.GraphFilters, GetGraphFilters()).Replace(PipefyConsts.FilterParameters.PipeId, _pipeId);
    }
}
