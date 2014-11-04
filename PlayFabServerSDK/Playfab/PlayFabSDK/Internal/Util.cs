using System;
using PlayFab.Serialization.JsonFx;

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

		public static JsonReaderSettings GlobalJsonReaderSettings = new JsonReaderSettings
		{
			AllNumbersAsDouble = true
		};
		public static JsonWriterSettings GlobalJsonWriterSettings = new JsonWriterSettings
		{
			WriteNulls = false
		};
    }
}
