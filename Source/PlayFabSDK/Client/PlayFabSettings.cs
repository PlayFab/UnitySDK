#if !DISABLE_PLAYFABCLIENT_API
using System;
using UnityEngine;
using System.Collections;
using PlayFab.Internal;

namespace PlayFab
{
    public static partial class PlayFabSettings
    {
        //Client only
        internal static string LogicServerUrl = null; // Deprecated
        public static string AdvertisingIdType = null; // Set this to the appropriate AD_TYPE_X constant below
        public static string AdvertisingIdValue = null;
    }
}
#endif