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

#if UNITY_IOS
		private Dictionary<int, Action<string,PlayFabError>> HttpHandlers = new Dictionary<int, Action<string,PlayFabError>>();
#else
        private Dictionary<int, Action<string, string>> HttpHandlers = new Dictionary<int, Action<string, string>>();
#endif

		public static void Init()
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


	    public void GCMRegistrationReady(string status)
	    {
	        bool statusParam; 
            bool.TryParse(status,out statusParam);
            PlayFabGoogleCloudMessaging.RegistrationReady(statusParam);
	    }

		public void GCMRegistered(string token)
		{
            var error = (string.IsNullOrEmpty(token)) ? token : null;
		    PlayFabGoogleCloudMessaging.RegistrationComplete(token, error);
		}

		public void GCMRegisterError(string error)
		{
		    PlayFabGoogleCloudMessaging.RegistrationComplete(null, error);
		}

		public void GCMMessageReceived(string message)
		{
		    PlayFabGoogleCloudMessaging.MessageReceived(message);
		}

#if UNITY_IOS
		public static void addHttpDelegate(int id, Action<string,PlayFabError> callback)
		{
		    Init();

		    if (callback != null)
		        PlayFabGO.HttpHandlers.Add(id, callback);
		}

#else
		public static void addHttpDelegate(int id, Action<string,string> callback)
		{
		    Init();

		    if (callback != null)
		        PlayFabGO.HttpHandlers.Add(id, callback);
		}
#endif
        public void OnHttpError(string response)
		{
			//Debug.Log ("Got HTTP error response: "+response);
			try
			{
				string[] args = response.Split(":".ToCharArray(), 2);
				int reqId = int.Parse(args[0]);
#if UNITY_IOS
				Action<string,PlayFabError> callback = HttpHandlers[reqId];
			    if (callback != null)
			    {
			        var cbError = new PlayFabError()
			        {
                        HttpStatus = "200",
			            ErrorMessage = args[1],
			        };
			        callback(null, cbError);
			    }

#else
                Action<string,string> callback = HttpHandlers[reqId];
                if (callback != null) {
					callback(null, args[1]);
                }
#endif
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
#if UNITY_IOS
                Action<string,PlayFabError> callback = HttpHandlers[reqId];
#else
                Action<string,string> callback = HttpHandlers[reqId];
#endif
                if (callback != null)
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