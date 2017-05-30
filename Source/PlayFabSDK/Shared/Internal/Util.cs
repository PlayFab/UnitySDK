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
        static PlayFabUtil() { }

        public static readonly string[] _defaultDateTimeFormats = new string[]{ // All parseable ISO 8601 formats for DateTime.[Try]ParseExact - Lets us deserialize any legacy timestamps in one of these formats
            // These are the standard format with ISO 8601 UTC markers (T/Z)
            "yyyy-MM-ddTHH:mm:ss.FFFFFFZ",
            "yyyy-MM-ddTHH:mm:ss.FFFFZ",
            "yyyy-MM-ddTHH:mm:ss.FFFZ", // DEFAULT_UTC_OUTPUT_INDEX
            "yyyy-MM-ddTHH:mm:ss.FFZ",
            "yyyy-MM-ddTHH:mm:ssZ",
            "yyyy-MM-dd HH:mm:ssZ", // Added for Android Push Plugin

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
        public const int DEFAULT_LOCAL_OUTPUT_INDEX = 9; // The default format if you want to use local time (This doesn't have universal support in all PlayFab code)
        public static DateTimeStyles DateTimeStyles = DateTimeStyles.RoundtripKind;

        /// <summary>
        /// This field has moved!
        /// However, most users shouldn't access this at all
        /// JsonWrapper.Serialize, and JsonWrapper.Deserialize will always use it automatically (Unless you deliberately mess with them)
        /// Any Serialization of an object in the PlayFab namespace should just use JsonWrapper
        /// </summary>
        [Obsolete(@"This field has moved to SimpleJsonInstance.ApiSerializerStrategy", false)]
        public static SimpleJsonInstance.PlayFabSimpleJsonCuztomization ApiSerializerStrategy { get { return SimpleJsonInstance.ApiSerializerStrategy; } }

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
