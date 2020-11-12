using System;

namespace Axis.PipefySdk.Models.Events
{
    public class QueryProgressEventArgs : EventArgs
    {
        public int RecordsAddedCount { get; set; }
        public bool AnotherPage { get; internal set; }
    }
}
