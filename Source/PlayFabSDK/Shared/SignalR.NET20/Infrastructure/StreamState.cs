using SignalR.Client._20.Http;
using SignalR.Client._20.Transports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SignalR.Client._20.Infrastructure
{
    internal class StreamState
    {
        public Stream Stream { get; set; }
        public byte[] Buffer { get; set; }
        public EventSignal<CallbackDetail<int>> Response { get; set; }
    }
}
