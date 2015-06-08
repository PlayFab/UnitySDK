#if UNITY_EDITOR

#elif UNITY_ANDROID
#define PLAYFAB_ANDROID_PLUGIN
#elif UNITY_IOS
#define PLAYFAB_IOS_PLUGIN
#endif

using System;
using System.Collections.Generic;

using UnityEngine;

namespace PlayFab.Internal
{
	public class PlayFabPluginEventHandler : MonoBehaviour
	{
		private static PlayFabPluginEventHandler PlayFabGO;

		private Dictionary<int, Action<string,string>> HttpHandlers = new Dictionary<int, Action<string,string>>();

		public static void init()
		{
			if (PlayFabGO != null)
				return;
			
			GameObject playfabHolder = GameObject.Find ("_PlayFabGO");
			if(playfabHolder == null)
				playfabHolder = new GameObject ("_PlayFabGO");
			UnityEngine.Object.DontDestroyOnLoad(playfabHolder);
			
			PlayFabGO = playfabHolder.GetComponent<PlayFabPluginEventHandler> ();
			if(PlayFabGO == null)
				PlayFabGO = playfabHolder.AddComponent<PlayFabPluginEventHandler> ();

		}

		public void GCMRegistered(string id)
		{
			PlayFabGoogleCloudMessaging.registrationComplete (id, null);
		}

		public void GCMRegisterError(string error)
		{
			PlayFabGoogleCloudMessaging.registrationComplete (null, error);
		}

		public void GCMMessageReceived(string message)
		{
			PlayFabGoogleCloudMessaging.messageReceived (message);
		}

		public static void addHttpDelegate(int id, Action<string,string> callback)
		{
			init ();

			if(callback != null)
				PlayFabGO.HttpHandlers.Add (id, callback);
		}


		public void OnHttpError(string response)
		{
			//Debug.Log ("Got HTTP error response: "+response);
			try
			{
				string[] args = response.Split(":".ToCharArray(), 2);
				int reqId = int.Parse(args[0]);
				Action<string,string> callback = HttpHandlers[reqId];
				if(callback != null)
					callback(null, args[1]);
				HttpHandlers.Remove(reqId);
			}
			catch(Exception e)
			{
				Debug.LogError("Error handling HTTP Error: "+e);
			}
		}

		public void OnHttpResponse(string response)
		{
			//Debug.Log ("Got HTTP success response: "+response);
			try
			{
				string[] args = response.Split(":".ToCharArray(), 2);
				int reqId = int.Parse(args[0]);
				Action<string,string> callback = HttpHandlers[reqId];
				if(callback != null)
					callback(args[1], null);
				HttpHandlers.Remove(reqId);
			}
			catch(Exception e)
			{
				Debug.LogError("Error handling HTTP request: "+e);
			}
		}
	}

}