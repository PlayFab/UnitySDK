using System;
using SignalR.Client._20.Hubs;

namespace SignalR.Client._20
{
    public static class ConnectionExtensions
    {
        public static T GetValue<T>(IConnection connection, string key)
        {
            object _value;
            if (connection.Items.TryGetValue(key, out _value))
                return (T)_value;

            return default(T);
        }
    }
}
