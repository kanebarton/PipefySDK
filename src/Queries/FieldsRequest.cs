using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Queries
{
    public class FieldsRequest : PipefyRequestBase
    {
        private static readonly string _query = EmbeddedManager.CommandDictionary[$"{typeof(FieldsRequest).FullName}.ql"];
        private readonly string _pipeId = "0";

        public FieldsRequest(long pipeId)
        : this(pipeId.ToString()) { }

        public FieldsRequest(string pipeId)
        {
            _pipeId = pipeId;
        }

        [JsonPropertyName("query")]
        public string Query => _query.Replace(PipefyConsts.FilterParameters.GraphFilters, GetGraphFilters()).Replace(PipefyConsts.FilterParameters.PipeId, _pipeId);
    }
}
