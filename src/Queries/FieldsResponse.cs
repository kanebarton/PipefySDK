using Axis.PipefySdk.Models.Common;
using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Queries
{
    public class FieldsResponse
    {
        // helper methods to get at the data without having to navigate the object tree
        public PipeResponse Pipe => DataResult?.Pipe;
        public StartFormFieldResponse[] Fields => DataResult?.Pipe?.StartFormFields;

        [JsonPropertyName("data")]
        public DataResponse DataResult { get; set; }

        public class DataResponse
        {
            [JsonPropertyName("pipe")]
            public PipeResponse Pipe { get; set; }
        }

        public class PipeResponse : PipefyIdNameModel
        {
            [JsonPropertyName("start_form_fields")]
            public StartFormFieldResponse[] StartFormFields { get; set; }
        }

        public class StartFormFieldResponse : PipefyIdModel
        {
            [JsonPropertyName("label")]
            public string Label { get; set; }

            [JsonPropertyName("required")]
            public bool StartFormFieldRequired { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("options")]
            public string[] Options { get; set; }
        }
    }
}
