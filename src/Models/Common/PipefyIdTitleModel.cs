using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Models.Common
{
    public class PipefyIdTitleModel : PipefyIdModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
