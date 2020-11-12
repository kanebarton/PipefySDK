using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Axis.PipefySdk
{
    public interface IPipefyRequest
    {
        int? GraphFilterTake { get; set; }
        string GraphFilterTitle { get; set; }
        string GraphFilterCursor { get; set; }
        string GetGraphFilters();
    }

    public abstract class PipefyRequestBase : IPipefyRequest
    {
        public int? GraphFilterTake { get; set; }
        public string GraphFilterTitle { get; set; }
        public string GraphFilterCursor { get; set; }

        public string GetGraphFilters()
        {
            var filter = new List<string>(2);

            if (!string.IsNullOrEmpty(GraphFilterCursor))
            {
                filter.Add($"after: \"{GraphFilterCursor}\"");
            }

            if (GraphFilterTake.HasValue)
            {
                filter.Add($"first: {GraphFilterTake}");
            }

            if (filter.Any())
            {
                return $", {string.Join(", ", filter.ToArray())}";
            }

            return string.Empty;
        }
    }
}
