using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Models.Common
{
    public class PipefyNameModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
