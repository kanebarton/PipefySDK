using Axis.PipefySdk.Models;
using System;
using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Queries
{
    public class PipeResponse
    {
        // helper methods to get at the data without having to navigate the object tree
        public PipeDataResponse Pipe => DataResult?.Pipe;
        public PhaseModel[] Phases => DataResult?.Pipe?.Phases;

        [JsonPropertyName("data")]
        public DataResponse DataResult { get; set; }

        public class DataResponse
        {
            [JsonPropertyName("pipe")]
            public PipeDataResponse Pipe { get; set; }
        }

        public class PipeDataResponse
        {
            [JsonPropertyName("cards_count")]
            public long? CardsCount { get; set; }

            [JsonPropertyName("created_at")]
            public DateTimeOffset CreatedAt { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("phases")]
            public PhaseModel[] Phases { get; set; }

            [JsonPropertyName("labels")]
            public LabelModel[] Labels { get; set; }
        } 
    }
}
