using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PlayFab.Internal
{
    internal class Util
    {
        public static string timeStamp
        {
            get { return DateTime.Now.ToString ("yyyy-MM-dd HH:mm.ss.ff"); }
        }

        public static string Format (string text, params object[] args)
        {
            return args.Length > 0 ? string.Format (text, args) : text;
        }

        public static JsonSerializerSettings JsonSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            Converters = { new IsoDateTimeConverter() { DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFF'Z'" } },
        };
        
        public static Formatting JsonFormatting = Formatting.None;

    }
}
