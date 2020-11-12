using Axis.PipefySdk.Models.Common;
using System;
using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Queries
{
    public class MeResponse
    {
        // helper methods to get at the data without having to navigate the object tree
        public PipefyAccount PipefyUser => DataResult?.Me;

        [JsonPropertyName("data")]
        public DataResponse DataResult { get; set; }

        public class DataResponse
        {
            [JsonPropertyName("me")]
            public PipefyAccount Me { get; set; }
        }

        public class PipefyAccount : PipefyIdNameUsernameModel
        {
            [JsonPropertyName("email")]
            public string Email { get; set; }

            [JsonPropertyName("avatar_url")]
            public Uri AvatarUrl { get; set; }

            [JsonPropertyName("created_at")]
            public string CreatedAt { get; set; }

            [JsonPropertyName("locale")]
            public string Locale { get; set; }

            [JsonPropertyName("time_zone")]
            public string TimeZone { get; set; }
        }
    }
}