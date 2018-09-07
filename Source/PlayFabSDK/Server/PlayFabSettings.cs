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
            set { PlayFabSharedPrivate.ProductionEnvironmentPlayStreamUrl = value; }
            internal get
            {
                return string.IsNullOrEmpty(PlayFabSharedPrivate.ProductionEnvironmentPlayStreamUrl) ? "http://playstreamlive.playfab.com/signalr" : PlayFabSharedPrivate.ProductionEnvironmentPlayStreamUrl;
            }
        }
#endif
    }
}
#endif
