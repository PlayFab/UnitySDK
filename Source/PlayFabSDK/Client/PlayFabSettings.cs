#if !DISABLE_PLAYFABCLIENT_API
using System;
using UnityEngine;
using System.Collections;
using PlayFab.Internal;

namespace PlayFab
{
    public static partial class PlayFabSettings
    {
        public const string AD_TYPE_IDFA = "Idfa";
        public const string AD_TYPE_ANDROID_ID = "Adid";

        public static string AdvertisingIdType = null; // Set this to the appropriate AD_TYPE_X constant above
        public static string AdvertisingIdValue = null;
        public static bool DisableAdvertising = false;
    }
}
#endif
