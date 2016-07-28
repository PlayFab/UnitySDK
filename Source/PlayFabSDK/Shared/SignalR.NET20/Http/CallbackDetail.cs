using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR.Client._20.Http
{
    public class CallbackDetail<T>
    {
        public bool IsFaulted { get; set; }
        public Exception Exception { get; set; }
        public T Result { get; set; }
    }
}
