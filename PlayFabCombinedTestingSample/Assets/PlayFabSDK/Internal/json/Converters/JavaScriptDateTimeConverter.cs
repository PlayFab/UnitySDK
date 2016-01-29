#if !UNITY_WINRT || UNITY_EDITOR || (UNITY_WP8 &&  !UNITY_WP_8_1)
using System;

namespace PlayFab.Json.Converters
{
    /// <summary>
    /// Converts a <see cref="DateTime"/> to and from a JavaScript date constructor (e.g. new Date(52231943)).
    /// </summary>
    public class JavaScriptDateTimeConverter : DateTimeConverterBase
    {
    }
}
#endif
