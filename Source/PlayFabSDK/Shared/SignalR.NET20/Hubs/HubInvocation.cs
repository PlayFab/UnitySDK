#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System.Collections.Generic;
using PlayFab.Json;

namespace SignalR.Client._20.Hubs
{
    public class HubInvocation
    {
        [JsonProperty(PropertyName = "I")]
        public string CallbackId { get; set; }

        [JsonProperty(PropertyName = "H")]
        public string Hub { get; set; }

        [JsonProperty(PropertyName = "M")]
        public string Method { get; set; }

        [JsonProperty(PropertyName = "A")]
        public object[] Args { get; set; }

        [JsonProperty(PropertyName = "S", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> State { get; set; }
    }
}

#endif