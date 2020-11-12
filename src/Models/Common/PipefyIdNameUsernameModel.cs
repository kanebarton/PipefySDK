using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Models.Common
{
    public class PipefyIdNameUsernameModel : PipefyIdNameModel
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }
    }
}
