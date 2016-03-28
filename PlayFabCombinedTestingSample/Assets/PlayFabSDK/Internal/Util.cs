#if UNITY_EDITOR
#elif UNITY_ANDROID
#define PLAYFAB_ANDROID
#elif UNITY_IOS
#define PLAYFAB_IOS
#elif UNITY_WP8 || UNITY_WP8_1
#define PLAYFAB_WP
#elif UNITY_PS3 || UNITY_PS4
#define PLAYFAB_PS
#elif UNITY_WSA || UNITY_WSA_8_0 || UNITY_WSA_8_1 || UNITY_WSA_10_0
#define PLAYFAB_WIN_STORE
#endif

using System;
using System.Globalization;
using System.IO;

namespace PlayFab.Internal
{
    internal static class Util
    {
        public static readonly string[] _defaultDateTimeFormats = new string[]{ // All possible input time formats

            // These are the standard format with ISO 8601 UTC markers (T/Z)
            "yyyy-MM-ddTHH:mm:ss.FFFFFFZ", // DEFAULT_UTC_OUTPUT_INDEX
            "yyyy-MM-ddTHH:mm:ss.FFFFZ",
            "yyyy-MM-ddTHH:mm:ss.FFFZ",
            "yyyy-MM-ddTHH:mm:ss.FFZ",
            "yyyy-MM-ddTHH:mm:ssZ",

            // These are the standard format without ISO 8601 UTC markers (T/Z)
            "yyyy-MM-dd HH:mm:ss.FFFFFF",
            "yyyy-MM-dd HH:mm:ss.FFFF",
            "yyyy-MM-dd HH:mm:ss.FFF",
            "yyyy-MM-dd HH:mm:ss.FF", // DEFAULT_LOCAL_OUTPUT_INDEX
            "yyyy-MM-dd HH:mm:ss",

            // These are the result of an input bug, which we now have to support as long as the db has entries formatted like this
            "yyyy-MM-dd HH:mm.ss.FFFF",
            "yyyy-MM-dd HH:mm.ss.FFF",
            "yyyy-MM-dd HH:mm.ss.FF",
            "yyyy-MM-dd HH:mm.ss",
        };
        public const int DEFAULT_UTC_OUTPUT_INDEX = 0;
        public const int DEFAULT_LOCAL_OUTPUT_INDEX = 8;
        private static DateTimeStyles _dateTimeStyles = DateTimeStyles.RoundtripKind;

        public static string timeStamp
        {
            get { return DateTime.Now.ToString(_defaultDateTimeFormats[DEFAULT_LOCAL_OUTPUT_INDEX]); }
        }

        public static string utcTimeStamp
        {
            get { return DateTime.UtcNow.ToString(_defaultDateTimeFormats[DEFAULT_UTC_OUTPUT_INDEX]); }
        }

        public static string Format(string text, params object[] args)
        {
            return args.Length > 0 ? string.Format(text, args) : text;
        }

        public static MyJsonSerializerStrategy ApiSerializerStrategy = new MyJsonSerializerStrategy();
        public class MyJsonSerializerStrategy : PocoJsonSerializerStrategy
        {
            /// <summary>
            /// Convert the json value into the destination field/property
            /// </summary>
            public override object DeserializeObject(object value, Type type)
            {
                string valueStr = value as string;
                if (valueStr == null) // For all of our custom conversions, value is a string
                    return base.DeserializeObject(value, type);

                Type underType = Nullable.GetUnderlyingType(type);
                if (underType != null)
                    return DeserializeObject(value, underType);
                else if (type.IsEnum)
                    return Enum.Parse(type, (string)value, true);
                else if (type == typeof(DateTime))
                {
                    DateTime output;
                    bool result = DateTime.TryParseExact(valueStr, _defaultDateTimeFormats, CultureInfo.CurrentCulture, _dateTimeStyles, out output);
                    if (result)
                        return output;
                }
                else if (type == typeof(DateTimeOffset))
                {
                    DateTimeOffset output;
                    bool result = DateTimeOffset.TryParseExact(valueStr, _defaultDateTimeFormats, CultureInfo.CurrentCulture, _dateTimeStyles, out output);
                    if (result)
                        return output;
                }
                return base.DeserializeObject(value, type);
            }

            /// <summary>
            /// Set output to a string that represents the input object
            /// </summary>
            protected override bool TrySerializeKnownTypes(object input, out object output)
            {
                if (input.GetType().IsEnum)
                {
                    output = input.ToString();
                    return true;
                }
                else if (input is DateTime)
                {
                    output = ((DateTime)input).ToString(_defaultDateTimeFormats[DEFAULT_UTC_OUTPUT_INDEX], CultureInfo.CurrentCulture);
                    return true;
                }
                else if (input is DateTimeOffset)
                {
                    output = ((DateTimeOffset)input).ToString(_defaultDateTimeFormats[DEFAULT_UTC_OUTPUT_INDEX], CultureInfo.CurrentCulture);
                    return true;
                }
                return base.TrySerializeKnownTypes(input, out output);
            }
        }

        /// <summary>
        /// For PlayFab internal testing
        /// Load a text file, and return the file as text.
        /// Used for small json files.
        /// If your environment reports an error in this function, feel free to delete it locally.
        /// </summary>
        public static string ReadAllFileText(string filename)
        {
#if PLAYFAB_WP || UNITY_WEBPLAYER || PLAYFAB_PS || PLAYFAB_WIN_STORE
            return ""; // The File utility doesn't always exist
#else
            return File.ReadAllText(filename);
#endif
        }
    }
}
