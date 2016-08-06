#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System;

namespace SignalR.Client._20.Hubs
{
    public class Subscription
    {
        public event Action<object[]> Data;

        internal void OnData(object[] data)
        {
            if (Data != null)
                Data(data);
        }
    }
}

#endif