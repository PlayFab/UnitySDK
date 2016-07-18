using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR.Client._20.Transports
{
    public class CustomEventArgs<T> : EventArgs
    {
        public T Result { get; set; }
    }
}
