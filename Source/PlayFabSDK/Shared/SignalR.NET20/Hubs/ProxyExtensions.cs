#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using PlayFab.Json;
namespace SignalR.Client._20.Hubs
{
    public static class HubProxyExtensions
    {
        public static T GetValue<T>(IHubProxy proxy, string name)
        {
            object _value = proxy[name];
            return Convert<T>(_value);
        }

        private static T Convert<T>(object obj)
        {
            if (obj == null)
                return default(T);

            if (typeof(T).IsAssignableFrom(obj.GetType()))
                return (T)obj;

            return PlayFabSimpleJson.DeserializeObject<T>(obj.ToString());
        }
    }
}

#endif