#if ENABLE_PLAYFABSERVER_API
using System;
using UnityEngine;
using System.Collections;
using PlayFab.Internal;

namespace PlayFab
{
    public static partial class PlayFabSettings
    {
        //Future place for custom settings for Server API
#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
        public static string ProductionEnvironmentPlayStreamUrl
        {
            set { PlayFabShared.ProductionEnvironmentPlayStreamUrl = value; }
            internal get
            {
                return string.IsNullOrEmpty(PlayFabShared.ProductionEnvironmentPlayStreamUrl) ? "http://playstreamlive.playfab.com/signalr" : PlayFabShared.ProductionEnvironmentPlayStreamUrl;
            }
        }
#endif
    }
}
#endif