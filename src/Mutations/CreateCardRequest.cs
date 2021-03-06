using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Mutations
{
    public class CreateCardRequest
    {
        private static readonly string _query = EmbeddedManager.CommandDictionary[$"{typeof(CreateCardRequest).FullName}.ql"];
        private readonly string _pipeId = "0";

        public CreateCardRequest(long pipeId, string title)
        : this(pipeId.ToString(), title) { }

        public CreateCardRequest(string pipeId, string title)
        {
            _pipeId = pipeId;
            Title = title;
        }

        [JsonIgnore] public string Title { get; set; } = string.Empty;
        [JsonIgnore] public Dictionary<string, string> Fields { get; } = new();

        [JsonPropertyName("query")]
        public string Query => _query.Replace(PipefyConsts.FilterParameters.PipeId, _pipeId)
            .Replace(PipefyConsts.FilterParameters.Title, Title)
            .Replace(PipefyConsts.FilterParameters.FieldArray, GenerateFieldArray());

        public string GenerateFieldArray()
        {
            var result = string.Empty;
            foreach (var keyValue in Fields)
            {
                result += $"{{field_id: \"{keyValue.Key}\", field_value: \"{keyValue.Value}\"}},";
            }

            return result[0..^1];

            /*
             

            mutation {
  createCard(input: {pipe_id: 301540231, title: "Test", fields_attributes: [{field_id: "error_message", field_value: "test2"}, {field_id: "steps_taken", field_value: "something"}]}) {
    card {
      id
    }
  }
}


             */
        }
    }
}
