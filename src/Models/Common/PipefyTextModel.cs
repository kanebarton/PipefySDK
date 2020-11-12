using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Models.Common
{
    public class PipefyTextModel
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
