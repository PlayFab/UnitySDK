using PlayFab.Json;
using System;
using System.Globalization;
using System.IO;
using System.Text;
#if NETFX_CORE
using System.Reflection;
#endif

namespace PlayFab.Internal
{
    internal static class PlayFabUtil
    {
        public static readonly string[] _defaultDateTimeFormats = new string[]{ // All parseable ISO 8601 formats for DateTime.[Try]ParseExact - Lets us deserialize any legacy timestamps in one of these formats
            // These are the standard format with ISO 8601 UTC markers (T/Z)
            "yyyy-MM-ddTHH:mm:ss.FFFFFFZ",
            "yyyy-MM-ddTHH:mm:ss.FFFFZ",
            "yyyy-MM-ddTHH:mm:ss.FFFZ", // DEFAULT_UTC_OUTPUT_INDEX
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
        public const int DEFAULT_UTC_OUTPUT_INDEX = 2; // The default format everybody should use
        public const int DEFAULT_LOCAL_OUTPUT_INDEX = 8; // The default format if you want to use local time (This doesn't have universal support in all PlayFab code)
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
                else if (type.GetTypeInfo().IsEnum)
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
                    output = ((DateTime)input).ToString(_defaultDateTimeFormats[DEFAULT_UTC_OUTPUT_INDEX], CultureInfo.CurrentCulture);
                    return true;
                }
                else if (input is DateTimeOffset)
                {
                    output = ((DateTimeOffset)input).ToString(_defaultDateTimeFormats[DEFAULT_UTC_OUTPUT_INDEX], CultureInfo.CurrentCulture);
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

        [ThreadStatic]
        private static StringBuilder _sb;
        /// <summary>
        /// A threadsafe way to block and load a text file
        /// 
        /// Load a text file, and return the file as text.
        /// Used for small (usually json) files.
        /// </summary>
        public static string ReadAllFileText(string filename)
        {
            if (_sb == null)
                _sb = new StringBuilder();
            _sb.Length = 0;

            var fs = new FileStream(filename, FileMode.Open);
            var br = new BinaryReader(fs);
            while (br.BaseStream.Position != br.BaseStream.Length)
                _sb.Append(br.ReadChar());

            return _sb.ToString();
        }
    }
}
