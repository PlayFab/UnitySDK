namespace PlayFab.Json
{
    public interface ISerializer
    {
        T DeserializeObject<T>(string json);
        T DeserializeObject<T>(string json, object jsonSerializerStrategy);

        string SerializeObject(object json);
        string SerializeObject(object json, object jsonSerializerStrategy);
    }

    public class JsonWrapper
    {
        private static ISerializer _instance = new SimpleJsonInstance();

        /// <summary>
        /// Use this property to override the Serialization for the SDK.
        /// </summary>
        public static ISerializer Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

        public static T DeserializeObject<T>(string json)
        {
            return _instance.DeserializeObject<T>(json);
        }

        public static T DeserializeObject<T>(string json, object jsonSerializerStrategy)
        {
            return _instance.DeserializeObject<T>(json, jsonSerializerStrategy);
        }

        public static string SerializeObject(object json)
        {
            return _instance.SerializeObject(json);
        }

        public static string SerializeObject(object json, object jsonSerializerStrategy)
        {
            return _instance.SerializeObject(json, jsonSerializerStrategy);
        }
    }

    public class SimpleJsonInstance : ISerializer
    {
        public T DeserializeObject<T>(string json)
        {
            return PlayFab.Json.PlayFabSimpleJson.DeserializeObject<T>(json);
        }

        public T DeserializeObject<T>(string json, object jsonSerializerStrategy)
        {
            return PlayFab.Json.PlayFabSimpleJson.DeserializeObject<T>(json, (PlayFab.Json.IJsonSerializerStrategy)jsonSerializerStrategy);
        }

        public string SerializeObject(object json)
        {
            return PlayFab.Json.PlayFabSimpleJson.SerializeObject(json);
        }

        public string SerializeObject(object json, object jsonSerializerStrategy)
        {
            return PlayFab.Json.PlayFabSimpleJson.SerializeObject(json, (PlayFab.Json.IJsonSerializerStrategy)jsonSerializerStrategy);
        }
    }
}
