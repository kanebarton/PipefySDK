using Axis.PipefySdk.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Models
{
    public class CardModel : PipefyIdTitleModel
    {
        private IDictionary<string, CardFieldModel> _fields;

        [JsonPropertyName("fields")]
        public CardFieldModel[] FieldsData { get; set; }

        [JsonPropertyName("assignees")]
        public PipefyIdNameUsernameModel[] Assignees { get; set; }

        [JsonPropertyName("comments")]
        public PipefyTextModel[] Comments { get; set; }

        [JsonPropertyName("comments_count")]
        public long? CommentsCount { get; set; }

        [JsonPropertyName("current_phase")]
        public PipefyNameModel CurrentPhase { get; set; }

        [JsonPropertyName("done")]
        public bool Done { get; set; }

        [JsonPropertyName("due_date")]
        public DateTimeOffset? DueDate { get; set; }

        [JsonPropertyName("labels")]
        public LabelModel[] Labels { get; set; }

        [JsonPropertyName("phases_history")]
        public PhaseHistoryModel[] PhaseHistory { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("createdBy")]
        public PipefyIdModel CreatedBy { get; set; }

        [JsonPropertyName("creatorEmail")]
        public string CreatorEmail { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonPropertyName("current_phase_age")]
        public long? CurrentPhaseAge { get; set; }

        [JsonPropertyName("age")]
        public long? Age { get; set; }

        [JsonPropertyName("attachments_count")]
        public long AttachmentsCount { get; set; }

        [JsonPropertyName("pipe")]
        public PipefyIdNameModel PipeInformation { get; set; }

        [JsonPropertyName("uuid")]
        public string PipefyUniqueIdentifier { get; set; }

        [JsonPropertyName("started_current_phase_at")]
        public DateTimeOffset? StartedCurrentPhaseAt { get; set; }

        [JsonPropertyName("finished_at")]
        public DateTimeOffset? FinishedAt { get; set; }

        [JsonPropertyName("late")]
        public bool Late { get; set; }

        [JsonPropertyName("expired")]
        public bool Expired { get; set; }

        [JsonPropertyName("expiration")]
        public CardExpiration Expiration { get; set; }

        [JsonIgnore]
        public IDictionary<string, CardFieldModel> Fields
        {
            get
            {
                _fields ??= FieldsData.ToDictionary(x => x.Index, x => x);
                return _fields;
            }
        }

        public CardFieldModel GetField(string indexName) => Fields[indexName];
        public PipefyIdNameUsernameModel FirstAssignee => Assignees?.FirstOrDefault();
        public bool HasAssignee => FirstAssignee != null;

        public class PhaseHistoryModel
        {
            [JsonPropertyName("phase")]
            public PhaseModel Phase { get; set; }

            [JsonPropertyName("firstTimeIn")]
            public DateTimeOffset? FirstTimeIn { get; set; }

            [JsonPropertyName("lastTimeOut")]
            public DateTimeOffset? LastTimeOut { get; set; }
        }

        public class CardExpiration
        {
            [JsonPropertyName("expiredAt")]
            public DateTimeOffset? ExpiredAt { get; set; }

            [JsonPropertyName("shouldExpireAt")]
            public DateTimeOffset? ShouldExpireAt { get; set; }
        }
    }
}
