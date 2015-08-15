#if !UNITY_WINRT || UNITY_EDITOR || (UNITY_WP8 &&  !UNITY_WP_8_1)
using System;
using System.Globalization;

namespace PlayFab.Json.Utilities
{
  internal static class DateTimeUtils
  {
    public static string GetLocalOffset(this DateTime d)
    {
      TimeSpan utcOffset;
#if (UNITY_IOS || UNITY_WEBGL || UNITY_XBOXONE || UNITY_XBOX360 || UNITY_PS4 || UNITY_PS3 || UNITY_WII || UNITY_IPHONE)
      utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(d);
#else
      utcOffset = TimeZoneInfo.Local.GetUtcOffset(d);
#endif

      return utcOffset.Hours.ToString("+00;-00", CultureInfo.InvariantCulture) + ":" + utcOffset.Minutes.ToString("00;00", CultureInfo.InvariantCulture);
    }
  }
}

#endif