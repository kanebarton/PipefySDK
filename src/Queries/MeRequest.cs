using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Queries
{
    public class MeRequest : PipefyRequestBase
    {
        private static readonly string _query = EmbeddedManager.CommandDictionary[$"{typeof(MeRequest).FullName}.ql"];

        [JsonPropertyName("query")]
        public string Query => _query;
    }
}
