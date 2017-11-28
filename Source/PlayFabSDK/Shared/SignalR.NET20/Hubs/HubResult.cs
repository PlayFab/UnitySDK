#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System.Collections.Generic;
using PlayFab.Json;

namespace SignalR.Client._20.Hubs
{
    public class HubResult<T>
    {
        [JsonProperty(PropertyName = "R")]
        public T Result { get; set; }

        [JsonProperty(PropertyName = "E")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "S")]
        public IDictionary<string, object> State { get; set; }
    }
} 
#endif