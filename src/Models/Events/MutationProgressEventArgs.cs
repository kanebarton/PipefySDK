using System;

namespace Axis.PipefySdk.Models.Events
{
    public class MutationProgressEventArgs : EventArgs
    {
        private int _currentPercentComplete = -1;
        private int _progressIndex;

        public int MaximumIndex { get; set; }
        public int PercentComplete { get; set; }

        public int ProgressIndex
        {
            get => _progressIndex; set
            {
                _progressIndex = value;

                if (ProgressIndex < 1 || MaximumIndex < 1)
                {
                    PercentComplete = 0;
                }
                else
                {
                    PercentComplete = Convert.ToInt32(Math.Round((double)ProgressIndex / MaximumIndex * 100, 0));
                }
            }
        }

        public bool ShouldRaiseEvent
        {
            get
            {
                if (_currentPercentComplete != PercentComplete)
                {
                    _currentPercentComplete = Convert.ToInt32(PercentComplete);
                    return true;
                }

                return false;
            }
        }
    }
}
