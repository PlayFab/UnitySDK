#if UNITY_EDITOR

#elif UNITY_ANDROID
#define PLAYFAB_ANDROID_PLUGIN
#endif

using System;
using UnityEngine;

using PlayFab.Internal;

namespace PlayFab
{
	public class PlayFabAndroidPlugin
	{
		private static bool Initted=false;
#if PLAYFAB_ANDROID_PLUGIN

		private static AndroidJavaClass AndroidPlugin;
		private static AndroidJavaClass PlayServicesUtils;

		public static bool isAvailable() { return true; }
#else
		public static bool isAvailable() { return false; }
#endif

		public static void init()
		{
			if (Initted)
				return;

			PlayFabPluginEventHandler.init ();

#if PLAYFAB_ANDROID_PLUGIN
			AndroidPlugin = new AndroidJavaClass("com.playfab.unity.plugin.AndroidPlugin");
			AndroidPlugin.CallStatic("init");

			PlayServicesUtils = new AndroidJavaClass("com.playfab.unity.plugin.PlayServicesUtils");
#endif
			PlayFabGoogleCloudMessaging.init ();

			Initted = true;
		}

#if PLAYFAB_ANDROID_PLUGIN

		public static bool isPlayServicesAvailable()
		{
			return PlayServicesUtils.CallStatic<bool> ("isPlayServicesAvailable");
		}
#else
		public static bool isPlayServicesAvailable()
		{
			return false;
		}
#endif
	}

	public class PlayFabGoogleCloudMessaging
	{
		public delegate void GCMRegisterComplete(string id, string error);
		public delegate void GCMMessageReceived(string message);

		private static GCMRegisterComplete RegistrationCallback;
		private static GCMMessageReceived MessageCallbackEvent;

		public static void addMessageListener (GCMMessageReceived listener)
		{
			MessageCallbackEvent += listener;
		}

		public static void removeMessageListener (GCMMessageReceived listener)
		{
			MessageCallbackEvent -= listener;
		}

#if PLAYFAB_ANDROID_PLUGIN

		private static AndroidJavaClass PlayFabGCMClass;

		public static void init()
		{
			PlayFabGCMClass = new AndroidJavaClass("com.playfab.unity.plugin.GoogleCloudMessaging"); 
		}

		public static void registerAsync(string senderId, GCMRegisterComplete callback)
		{
			if (RegistrationCallback != null)
				throw new Exception ("GCM Registration already in progress");

			RegistrationCallback = callback;
			PlayFabGCMClass.CallStatic ("registerInBackground", new object[] {senderId});
		}


		public static bool isRegistered()
		{
			return getRegistrationId() != null;
		}

		public static string getRegistrationId()
		{
			return PlayFabGCMClass.CallStatic<string> ("getRegistrationId");
		}

		public static void unregister()
		{
			PlayFabGCMClass.CallStatic ("unregister");
		}

		public static void cancelAllNotifications()
		{
			PlayFabGCMClass.CallStatic ("cancelAllNotifications");
		}

		public static void cancelNotification(int id)
		{
			PlayFabGCMClass.CallStatic ("cancelNotification", new object[] {id});
		}

	#else

		public static void init()
		{

		}
		
		public static void registerAsync(string senderId, GCMRegisterComplete callback)
		{
			registrationComplete(null, "Google Cloud Messaging not available");
		}

		public static bool isRegistered()
		{
			return false;
		}
		
		public static string getRegistrationId()
		{
			return null;
		}

		public static void unregister()
		{
		}

		public static void cancelAllNotifications()
		{

		}
		
		public static void cancelNotification(int id)
		{

		}

	#endif
		internal static void registrationComplete(string id, string error)
		{
			if (RegistrationCallback == null)
				return;

			RegistrationCallback (id, error);
			RegistrationCallback = null;
		}

		internal static void messageReceived(string message)
		{
			if (MessageCallbackEvent == null)
				return;

			MessageCallbackEvent(message);
		}

	}
}