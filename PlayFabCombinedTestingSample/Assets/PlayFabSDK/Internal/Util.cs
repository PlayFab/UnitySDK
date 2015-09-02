using PlayFab.Json;
using PlayFab.Json.Converters;
using System;

namespace PlayFab.Internal
{
    internal class Util
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

        public static JsonSerializerSettings JsonSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            Converters = { new IsoDateTimeConverter(), new StringEnumConverter() },
        };

        public static Formatting JsonFormatting = Formatting.None;

    }
}
