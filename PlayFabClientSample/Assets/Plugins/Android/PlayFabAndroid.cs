using System;
using UnityEngine;

using PlayFab.Internal;
using PlayFab;

namespace PlayFab
{
    public class PlayFabAndroidPlugin
    {
        private static bool Initted = false;
#if UNITY_ANDROID && !UNITY_EDITOR

        private static AndroidJavaClass AndroidPlugin;
		private static AndroidJavaClass PlayServicesUtils;

		public static bool IsAvailable() { return true; }
#else
        public static bool IsAvailable() { return false; }
#endif

        public static void Init(string SenderID)
        {
            if (Initted)
                return;

            PlayFabPluginEventHandler.Init();

#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidPlugin = new AndroidJavaClass("com.playfab.unityplugin.PlayFabUnityAndroidPlugin");
			
			string applicationName = "PlayFab Application";
#if UNITY_5 || UNITY_5_1
				applicationName = Application.productName;
#endif
			var staticParams = new object[] { SenderID , applicationName};
			
            AndroidPlugin.CallStatic("initGCM", staticParams);

            PlayServicesUtils = new AndroidJavaClass("com.playfab.unityplugin.GCM.PlayServicesUtils");
#endif
            PlayFabGoogleCloudMessaging.Init();

            Initted = true;
        }

#if UNITY_ANDROID && !UNITY_EDITOR

        public static bool IsPlayServicesAvailable()
		{
			return PlayServicesUtils.CallStatic<bool> ("isPlayServicesAvailable");
		}

        public static void StopPlugin(){
            AndroidPlugin.CallStatic("stopPluginService");
        }

        public static void UpdatePaused(bool pausedState){
            AndroidPlugin.CallStatic("updatePausedState", pausedState);
        }
#else
        public static bool IsPlayServicesAvailable()
        {
            return false;
        }
#endif
    }

    public class PlayFabGoogleCloudMessaging
    {
        #region Events
        public delegate void GCMRegisterReady(bool status);
        public delegate void GCMRegisterComplete(string id, string error);
        public delegate void GCMMessageReceived(string message);

        public static GCMRegisterReady _RegistrationReadyCallback;
        public static GCMRegisterComplete _RegistrationCallback;
        public static GCMMessageReceived _MessageCallback;
        #endregion

#if UNITY_ANDROID && !UNITY_EDITOR

        private static AndroidJavaClass PlayFabGCMClass;
        private static AndroidJavaClass PlayFabPushCacheClass;

		public static void Init()
		{
			PlayFabGCMClass = new AndroidJavaClass("com.playfab.unityplugin.GCM.PlayFabGoogleCloudMessaging");
            PlayFabPushCacheClass = new AndroidJavaClass("com.playfab.unityplugin.GCM.PlayFabPushCache");
		}

		public static void GetToken()
		{
			PlayFabGCMClass.CallStatic("getToken");
		}

        public static string GetPushCacheData(){
            return PlayFabPushCacheClass.CallStatic<String>("getPushCacheData");
        }

#else

        public static void Init()
        {

        }

        public static string GetToken()
        {
            return null;
        }

        public static void UpdatePaused(bool pausedState)
        {

        }

        public static string GetPushCacheData()
        {
            return null;
        }
#endif

        internal static void RegistrationReady(bool status)
        {
            if (_RegistrationReadyCallback == null)
                return;

            _RegistrationReadyCallback(status);
            _RegistrationReadyCallback = null;
        }

        internal static void RegistrationComplete(string id, string error)
        {
            if (_RegistrationCallback == null)
                return;

            _RegistrationCallback(id, error);
            _RegistrationCallback = null;
        }

        internal static void MessageReceived(string message)
        {
            if (_MessageCallback == null)
                return;

            _MessageCallback(message);
        }

    }
}