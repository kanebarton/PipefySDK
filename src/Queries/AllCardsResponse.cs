using Axis.PipefySdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Queries
{
    public class AllCardsResponse : IPipefyPagedResponse
    {
        // helper methods to get at the data without having to navigate the object tree
        public IPipefyQueryPageInfo QueryPageInfo => DataResult?.AllCards?.PageInfo;
        public IEnumerable<CardModel> Cards => DataResult?.AllCards?.Edges?.Select(x => x.Card);

        // allows for pagination
        public int ItemCount => DataResult?.AllCards?.Edges?.Count ?? 0;

        // allows this class to append data to itself (used pagination) and return the number of records added
        public int AppendData(object response)
        {
            var responseAsType = response as AllCardsResponse;
            DataResult.AllCards.Edges.AddRange(responseAsType.DataResult.AllCards.Edges);

            return responseAsType.DataResult.AllCards.Edges.Count;
        }

        public void ApplyRequestFiltering(IPipefyRequest request)
        {
            if (request == null || DataResult?.AllCards?.Edges == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(request.GraphFilterTitle))
            {
                DataResult.AllCards.Edges = DataResult?.AllCards?.Edges.Where(x => x.Card.Title.Contains(request.GraphFilterTitle, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (request.GraphFilterTake.HasValue)
            {
                DataResult.AllCards.Edges = DataResult?.AllCards?.Edges.Take(request.GraphFilterTake.Value).ToList();
            }
        }

        [JsonPropertyName("data")]
        public DataResponse DataResult { get; set; }

        public class DataResponse
        {
            [JsonPropertyName("allcards")]
            public AllCards AllCards { get; set; }
        }

        public class AllCards
        {
            [JsonPropertyName("pageInfo")]
            public PipefyQueryPageInfo PageInfo { get; set; }

            [JsonPropertyName("edges")]
            public List<Edge> Edges { get; set; } = new List<Edge>();
        }

        public class Edge
        {
            [JsonPropertyName("cursor")]
            public string Cursor { get; set; }

            [JsonPropertyName("node")]
            public CardModel Card { get; set; }
        }
    }
}
