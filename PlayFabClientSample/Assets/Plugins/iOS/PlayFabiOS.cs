// #define DISABLE_IDFA // If you need to disable IDFA for your game, uncomment this

using System;
using System.Runtime.InteropServices;

namespace PlayFab
{
    public static class PlayFabiOSPlugin
    {

#if UNITY_IOS && !DISABLE_IDFA
        [DllImport("__Internal")]
        public static extern string getIdfa();
        [DllImport("__Internal")]
        public static extern bool getAdvertisingDisabled();
#elif UNITY_IOS
        public static string getIdfa() { return "invalid"; }

        public static bool getAdvertisingDisabled() { return true; }
#endif
        
    }
}
