#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System;

namespace SignalR.Client._20.Transports
{
    public class CustomEventArgs<T> : EventArgs
    {
        public T Result { get; set; }
    }
}

#endif