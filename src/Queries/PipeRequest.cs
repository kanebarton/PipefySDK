using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Axis.PipefySdk.Queries
{
    public class PipeRequest : PipefyRequestBase
    {
        private static readonly string _query = EmbeddedManager.CommandDictionary[$"{typeof(PipeRequest).FullName}.ql"];
        private string _pipeId = string.Empty;

        public PipeRequest(long pipeId)
        : this(pipeId.ToString()) { }

        public PipeRequest(string pipeId)
        {
            _pipeId = pipeId;
        }

        [JsonPropertyName("query")]
        public string Query => _query.Replace(PipefyConsts.FilterParameters.GraphFilters, GetGraphFilters()).Replace(PipefyConsts.FilterParameters.PipeId, _pipeId);
    }
}
