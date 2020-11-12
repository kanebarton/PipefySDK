using Axis.PipefySdk.Models.Common;
using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Models
{
    public class PhaseModel : PipefyIdNameModel
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("cards_count")]
        public long? CardsCount { get; set; }
    }
}
