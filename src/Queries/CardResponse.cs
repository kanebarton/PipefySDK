using Axis.PipefySdk.Models;
using System;
using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Queries
{
    public class CardResponse
    {
        // helper methods to get at the data without having to navigate the object tree
        public CardModel Card => DataResult?.Card;

        [JsonPropertyName("data")]
        public DataResponse DataResult { get; set; }

        public class DataResponse
        {
            [JsonPropertyName("card")]
            public CardModel Card { get; set; }
        }
    }
}