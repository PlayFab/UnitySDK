using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR.Client._20.Transports
{
    public class OptionalEventSignal<T> : EventSignal<T>
    {
        protected override void handleNoEventHandler()
        {
        }
    }
}
