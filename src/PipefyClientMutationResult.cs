using Axis.PipefySdk.Mutations;
using System.Collections.Generic;
using System.Linq;

namespace Axis.PipefySdk
{
    public class PipefyClientMutationResult
    {
        public bool AllSuccess { get; set; }
        public IList<MutationResponse> Responses { get; set; } = new List<MutationResponse>();

        public IEnumerable<MutationResponse> Failures() => Responses.Where(x => !x.Success);
    }
}
