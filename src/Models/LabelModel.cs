using Axis.PipefySdk.Models.Common;
using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Models
{
    public class LabelModel : PipefyIdNameModel
    {
        [JsonPropertyName("color")]
        public string Color { get; set; }
    }
}
