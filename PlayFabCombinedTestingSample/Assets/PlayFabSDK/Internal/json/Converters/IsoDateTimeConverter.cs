#if !UNITY_WINRT || UNITY_EDITOR || (UNITY_WP8 &&  !UNITY_WP_8_1)
using System;

namespace PlayFab.Json.Converters
{
    /// <summary>
    /// Converts a <see cref="DateTime"/> to and from the ISO 8601 date format (e.g. 2008-04-12T12:53Z).
    /// </summary>
    public class IsoDateTimeConverter : DateTimeConverterBase
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

        private string _dateTimeFormat;
    }
}
#endif
