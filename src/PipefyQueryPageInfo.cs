using System.Text.Json.Serialization;

namespace Axis.PipefySdk
{
    public interface IPipefyQueryPageInfo
    {
        string EndCursor { get; set; }
        bool HasNextPage { get; set; }
        bool HasPreviousPage { get; set; }
        string StartCursor { get; set; }
    }

    public class PipefyQueryPageInfo : IPipefyQueryPageInfo
    {
        [JsonPropertyName("startCursor")]
        public string StartCursor { get; set; }

        [JsonPropertyName("endCursor")]
        public string EndCursor { get; set; }

        [JsonPropertyName("hasNextPage")]
        public bool HasNextPage { get; set; }

        [JsonPropertyName("hasPreviousPage")]
        public bool HasPreviousPage { get; set; }
    }
}
