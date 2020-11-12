using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Mutations
{
    public class MutationResponse
    {
        // helper methods to get at the data without having to navigate the object tree
        public bool Success => DataResult?.UpdateCardField?.Success ?? false;

        [JsonPropertyName("data")]
        public DataResponse DataResult { get; set; }

        public class DataResponse
        {
            [JsonPropertyName("updateCardField")]
            public UpdateCardField UpdateCardField { get; set; }
        }

        public class UpdateCardField
        {
            [JsonPropertyName("clientMutationId")]
            public object ClientMutationId { get; set; }

            [JsonPropertyName("success")]
            public bool Success { get; set; }
        }
    }
}