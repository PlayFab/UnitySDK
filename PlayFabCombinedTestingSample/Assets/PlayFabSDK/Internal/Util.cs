using System;
using PlayFab.Json.Converters;
using PlayFab.SimpleJson;

namespace PlayFab.Internal
{
    internal static class Util
    {
        public static string timeStamp
        {
            get { return DateTime.Now.ToString(IsoDateTimeConverter._defaultDateTimeFormats[IsoDateTimeConverter.DEFAULT_LOCAL_OUTPUT_INDEX]); }
        }

        public static string utcTimeStamp
        {
            get { return DateTime.UtcNow.ToString(IsoDateTimeConverter._defaultDateTimeFormats[IsoDateTimeConverter.DEFAULT_UTC_OUTPUT_INDEX]); }
        }

        public static string Format(string text, params object[] args)
        {
            return args.Length > 0 ? string.Format(text, args) : text;
        }

        public static MyJsonSerializerStrategy ApiSerializerStrategy = new MyJsonSerializerStrategy();
        public class MyJsonSerializerStrategy : PocoJsonSerializerStrategy
        {
            public override object DeserializeObject(object value, Type type)
            {
                if (type.IsEnum)
                {
                    if (value is string)
                        return Enum.Parse(type, (string) value, true);
                    return Enum.ToObject(type, value);
                }
                return base.DeserializeObject(value, type);
            }

            protected override bool TrySerializeKnownTypes(object input, out object output)
            {
                if (input.GetType().IsEnum) { output = input.ToString(); return true; }
                return base.TrySerializeKnownTypes(input, out output);
            }
        }
    }
}
