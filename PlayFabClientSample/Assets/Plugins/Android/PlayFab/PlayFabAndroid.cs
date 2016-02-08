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

		public static void UpdateRouting(bool routeToNotificationArea){
			AndroidPlugin.CallStatic("updateRouting", routeToNotificationArea);
        }
#else
        public static bool IsPlayServicesAvailable()
        {
            return false;
        }
        
		public static void UpdateRouting(bool routeToNotificationArea)
		{
			
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

		public static PlayFabNotificationPackage GetPushCache()
        {
			AndroidJavaObject package = new AndroidJavaObject("com.playfab.unityplugin.GCM.PlayFabNotificationPackage");
			package = PlayFabPushCacheClass.CallStatic<AndroidJavaObject>("getPushCache");
			
			PlayFabNotificationPackage cache = new PlayFabNotificationPackage();
			if(package != null)
			{
				cache.Title = package.Get<string>("Title");
				cache.Message = package.Get<string>("Message");
				cache.Icon = package.Get<string>("Icon");
				cache.Sound = package.Get<string>("Sound");
				cache.CustomData = package.Get<string>("CustomData");
			}
			else
			{
				Debug.Log("Package was null");
			}
			
			return cache;
        }

#else

        public static void Init()
        {
			
        }

        public static string GetToken()
        {
            return null;
        }

        public static string GetPushCacheData()
        {
            return null;
        }

		public static PlayFabNotificationPackage GetPushCache()
        {
            return new PlayFabNotificationPackage();
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


// c# wrapper that matches our native com.playfab.unityplugin.GCM.PlayFabNotificationPackage
public struct PlayFabNotificationPackage 
{
	public string Sound;                // do not set this to use the default device sound; otherwise the sound you provide needs to exist in Android/res/raw/_____.mp3, .wav, .ogg
	public string Title;                // title of this message
	public string Icon;                 // to use the default app icon use app_icon, otherwise send the name of the custom image. Image must be in Android/res/drawable/_____.png, .jpg
	public string Message;              // the actual message to transmit (this is what will be displayed in the notification area
	public string CustomData;           // arbitrary key value pairs for game specific usage
}


