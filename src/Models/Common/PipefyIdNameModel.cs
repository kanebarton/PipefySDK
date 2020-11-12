using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Models.Common
{
    public class PipefyIdNameModel : PipefyIdModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
