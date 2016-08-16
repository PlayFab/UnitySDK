﻿using System;
using PlayFab.Internal;
using PlayFab.Json;

namespace PlayFab.Json
{
    public interface ISerializer
    {
        T DeserializeObject<T>(string json);
        T DeserializeObject<T>(string json, object jsonSerializerStrategy);
        object DeserializeObject(string json);

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

        public static object DeserializeObject(string json)
        {
            return _instance.DeserializeObject(json);
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
            return PlayFabSimpleJson.DeserializeObject<T>(json);
        }

        public T DeserializeObject<T>(string json, object jsonSerializerStrategy)
        {
            return PlayFabSimpleJson.DeserializeObject<T>(json, (IJsonSerializerStrategy)jsonSerializerStrategy);
        }

        public object DeserializeObject(string json)
        {
            return PlayFabSimpleJson.DeserializeObject(json);
        }

        public string SerializeObject(object json)
        {
            return PlayFabSimpleJson.SerializeObject(json);
        }

        public string SerializeObject(object json, object jsonSerializerStrategy)
        {
            return PlayFabSimpleJson.SerializeObject(json, (IJsonSerializerStrategy)jsonSerializerStrategy);
        }
    }
}

#region Delete this whole section after a few months
namespace PlayFab.Json
{
    [Obsolete("Use PlayFab.SimpleJson")]
    public static class JsonConvert
    {
        [Obsolete("Use PlayFab.Json.JsonWrapper.SerializeObject()")]
        public static string SerializeObject(object obj)
        {
            return JsonWrapper.SerializeObject(obj, PlayFabUtil.ApiSerializerStrategy);
        }

        [Obsolete("Use PlayFab.Json.JsonWrapper.SerializeObject()")]
        public static string SerializeObject(object obj, IJsonSerializerStrategy strategy)
        {
            return JsonWrapper.SerializeObject(obj, strategy);
        }


        [Obsolete("Use PlayFab.Json.JsonWrapper.DeserializeObject<t>()")]
        public static T DeserializeObject<T>(string json)
        {
            return JsonWrapper.DeserializeObject<T>(json, PlayFabUtil.ApiSerializerStrategy);
        }

        [Obsolete("Use PlayFab.Json.JsonWrapper.DeserializeObject()")]
        public static object DeserializeObject(string json)
        {
            return JsonWrapper.DeserializeObject(json);
        }
    }

    public static class SimpleJson
    {
        [Obsolete("Use PlayFab.Json.JsonWrapper.SerializeObject()")]
        public static string SerializeObject(object obj)
        {
            return JsonWrapper.SerializeObject(obj, PlayFabUtil.ApiSerializerStrategy);
        }

        [Obsolete("Use PlayFab.Json.JsonWrapper.DeserializeObject<t>()")]
        public static T DeserializeObject<T>(string json)
        {
            return JsonWrapper.DeserializeObject<T>(json, PlayFabUtil.ApiSerializerStrategy);
        }

        [Obsolete("Use PlayFab.Json.JsonWrapper.DeserializeObject<t>()")]
        public static T DeserializeObject<T>(string json, IJsonSerializerStrategy strategy)
        {
            return JsonWrapper.DeserializeObject<T>(json, strategy);
        }

        [Obsolete("Use PlayFab.Json.JsonWrapper.DeserializeObject()")]
        public static object DeserializeObject(string json)
        {
            return JsonWrapper.DeserializeObject(json);
        }
    }
}

namespace PlayFab
{
    public static class SimpleJson
    {
        [Obsolete("Use PlayFab.Json.JsonWrapper.SerializeObject()")]
        public static string SerializeObject(object obj)
        {
            return JsonWrapper.SerializeObject(obj, PlayFabUtil.ApiSerializerStrategy);
        }

        [Obsolete("Use PlayFab.Json.JsonWrapper.SerializeObject()")]
        public static string SerializeObject(object obj, IJsonSerializerStrategy strategy)
        {
            return JsonWrapper.SerializeObject(obj, strategy);
        }

        [Obsolete("Use PlayFab.Json.JsonWrapper.DeserializeObject<t>()")]
        public static T DeserializeObject<T>(string json)
        {
            return JsonWrapper.DeserializeObject<T>(json, PlayFabUtil.ApiSerializerStrategy);
        }

        [Obsolete("Use PlayFab.Json.JsonWrapper.DeserializeObject<t>()")]
        public static T DeserializeObject<T>(string json, IJsonSerializerStrategy strategy)
        {
            return JsonWrapper.DeserializeObject<T>(json, strategy);
        }


        [Obsolete("Use PlayFab.Json.JsonWrapper.DeserializeObject()")]
        public static object DeserializeObject(string json)
        {
            return JsonWrapper.DeserializeObject(json);
        }
    }
}
#endregion Delete this whole section after a few months

