using System;
using System.Globalization;
using System.Reflection;
using PlayFab.Internal;

namespace PlayFab.Json
{
    [Obsolete("This interface is deprecated, please use PlayFab.Internal.ISerializerPlugin instead.", false)]
    public interface ISerializer: ISerializerPlugin
    {
    }

    public static class JsonWrapper
    {
        /// <summary>
        /// Use this property to override the Serialization for the SDK.
        /// </summary>
        public static ISerializerPlugin Instance
        {
            get { return PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer); }
        }

        public static T DeserializeObject<T>(string json)
        {
            return Instance.DeserializeObject<T>(json);
        }

        public static T DeserializeObject<T>(string json, object jsonSerializerStrategy)
        {
            return Instance.DeserializeObject<T>(json, jsonSerializerStrategy);
        }

        public static object DeserializeObject(string json)
        {
            return Instance.DeserializeObject(json);
        }

        public static string SerializeObject(object json)
        {
            return Instance.SerializeObject(json);
        }

        public static string SerializeObject(object json, object jsonSerializerStrategy)
        {
            return Instance.SerializeObject(json, jsonSerializerStrategy);
        }
    }

    public class SimpleJsonInstance : ISerializerPlugin
    {
        /// <summary>
        /// Most users shouldn't access this
        /// JsonWrapper.Serialize, and JsonWrapper.Deserialize will always use it automatically (Unless you deliberately mess with them)
        /// Any Serialization of an object in the PlayFab namespace should just use JsonWrapper
        /// </summary>
        public static PlayFabSimpleJsonCuztomization ApiSerializerStrategy = new PlayFabSimpleJsonCuztomization();
        public class PlayFabSimpleJsonCuztomization : PocoJsonSerializerStrategy
        {
            /// <summary>
            /// Convert the json value into the destination field/property
            /// </summary>
            public override object DeserializeObject(object value, Type type)
            {
                var valueStr = value as string;
                if (valueStr == null) // For all of our custom conversions, value is a string
                    return base.DeserializeObject(value, type);

                var underType = Nullable.GetUnderlyingType(type);
                if (underType != null)
                    return DeserializeObject(value, underType);
                else if (type.GetTypeInfo().IsEnum)
                    return Enum.Parse(type, (string)value, true);
                else if (type == typeof(DateTime))
                {
                    DateTime output;
                    var result = DateTime.TryParseExact(valueStr, PlayFabUtil._defaultDateTimeFormats, CultureInfo.CurrentCulture, PlayFabUtil.DateTimeStyles, out output);
                    if (result)
                        return output;
                }
                else if (type == typeof(DateTimeOffset))
                {
                    DateTimeOffset output;
                    var result = DateTimeOffset.TryParseExact(valueStr, PlayFabUtil._defaultDateTimeFormats, CultureInfo.CurrentCulture, PlayFabUtil.DateTimeStyles, out output);
                    if (result)
                        return output;
                }
                else if (type == typeof(TimeSpan))
                {
                    double seconds;
                    if (double.TryParse(valueStr, out seconds))
                        return TimeSpan.FromSeconds(seconds);
                }
                return base.DeserializeObject(value, type);
            }

            /// <summary>
            /// Set output to a string that represents the input object
            /// </summary>
            protected override bool TrySerializeKnownTypes(object input, out object output)
            {
                if (input.GetType().GetTypeInfo().IsEnum)
                {
                    output = input.ToString();
                    return true;
                }
                else if (input is DateTime)
                {
                    output = ((DateTime)input).ToString(PlayFabUtil._defaultDateTimeFormats[PlayFabUtil.DEFAULT_UTC_OUTPUT_INDEX], CultureInfo.CurrentCulture);
                    return true;
                }
                else if (input is DateTimeOffset)
                {
                    output = ((DateTimeOffset)input).ToString(PlayFabUtil._defaultDateTimeFormats[PlayFabUtil.DEFAULT_UTC_OUTPUT_INDEX], CultureInfo.CurrentCulture);
                    return true;
                }
                else if (input is TimeSpan)
                {
                    output = ((TimeSpan)input).TotalSeconds;
                    return true;
                }
                return base.TrySerializeKnownTypes(input, out output);
            }
        }

        public T DeserializeObject<T>(string json)
        {
            return PlayFabSimpleJson.DeserializeObject<T>(json, ApiSerializerStrategy);
        }

        public T DeserializeObject<T>(string json, object jsonSerializerStrategy)
        {
            return PlayFabSimpleJson.DeserializeObject<T>(json, (IJsonSerializerStrategy)jsonSerializerStrategy);
        }

        public object DeserializeObject(string json)
        {
            return PlayFabSimpleJson.DeserializeObject(json, typeof(object), ApiSerializerStrategy);
        }

        public string SerializeObject(object json)
        {
            return PlayFabSimpleJson.SerializeObject(json, ApiSerializerStrategy);
        }

        public string SerializeObject(object json, object jsonSerializerStrategy)
        {
            return PlayFabSimpleJson.SerializeObject(json, (IJsonSerializerStrategy)jsonSerializerStrategy);
        }
    }
}
