using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Models.Common
{
    public class PipefyIdModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
