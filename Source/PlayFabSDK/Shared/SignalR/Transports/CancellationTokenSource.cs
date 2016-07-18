using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR.Client._20.Transports
{
    internal class CancellationTokenSource
    {
        public bool IsCancellationRequested { get; private set; }

        public void Cancel()
        {
            IsCancellationRequested = true;
        }
    }
}
