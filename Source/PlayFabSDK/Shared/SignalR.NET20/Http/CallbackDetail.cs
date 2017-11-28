#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System;

namespace SignalR.Client._20.Http
{
    public class CallbackDetail<T>
    {
        public bool IsFaulted { get; set; }
        public Exception Exception { get; set; }
        public T Result { get; set; }
    }
}

#endif