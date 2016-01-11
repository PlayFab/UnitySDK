using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayFab.Internal
{
    public class PlayFabPluginEventHandler : MonoBehaviour
    {
        private static PlayFabPluginEventHandler _playFabEvtHandler;
        private static readonly Dictionary<int, CallRequestContainer> HttpHandlers = new Dictionary<int, CallRequestContainer>();

        public static void Init()
        {
            if (_playFabEvtHandler != null)
                return;

            GameObject playfabGo = GameObject.Find("_PlayFabGO");
            if (playfabGo == null)
                playfabGo = new GameObject("_PlayFabGO");
            DontDestroyOnLoad(playfabGo);

            _playFabEvtHandler = playfabGo.GetComponent<PlayFabPluginEventHandler>();
            if (_playFabEvtHandler == null)
                _playFabEvtHandler = playfabGo.AddComponent<PlayFabPluginEventHandler>();
        }

        public void GCMRegistrationReady(string status)
        {
            bool statusParam;
            bool.TryParse(status, out statusParam);
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

        public static void AddHttpDelegate(string url, int callId, object request, object customData, Action<string, PlayFabError> callback)
        {
            Init();
            HttpHandlers.Add(callId, new CallRequestContainer { Url = url, CallId = callId, Callback = callback, Error = null, Result = null, Request = request, CustomData = customData });
        }

        public static void OnHttpError(string response)
        {
            //Debug.Log ("Got HTTP error response: "+response);
            try
            {
                string[] args = response.Split(":".ToCharArray(), 2);
                int callId = int.Parse(args[0]);

                CallRequestContainer request;
                if (!HttpHandlers.TryGetValue(callId, out request))
                {
                    Debug.LogWarning(string.Format("PlayFab call returned an error, but could not find the request.  Id:{0}, Error:{1}", args[0], args[1]));
                    return;
                }

                request.Error = new PlayFabError { HttpStatus = "200", ErrorMessage = args[1] };
                request.InvokeCallback();
                HttpHandlers.Remove(callId);
            }
            catch (Exception e)
            {
                Debug.LogError("Error handling HTTP Error: " + e);
            }
        }

        public static void OnHttpResponse(string response)
        {
            //Debug.Log ("Got HTTP success response: "+response);
            try
            {
                string[] args = response.Split(":".ToCharArray(), 2);
                int callId = int.Parse(args[0]);

                CallRequestContainer request;
                if (!HttpHandlers.TryGetValue(callId, out request))
                {
                    Debug.LogWarning(string.Format("PlayFab call returned a result, but could not find the request.  Id:{0}, Result:{1}", args[0], args[1]));
                    return;
                }

                request.Result = args[1];
                request.InvokeCallback();
                HttpHandlers.Remove(callId);
            }
            catch (Exception e)
            {
                Debug.LogError("Error handling HTTP request: " + e);
            }
        }
    }

    /// <summary>
    /// This is a callback class for use with IOS - HttpWebRequest.
    /// </summary>
    internal class CallRequestContainer
    {
        public string Url;
        public int CallId;
        public object Request;
        public string Result;
        public object CustomData;
        public PlayFabError Error;
        public Action<string, PlayFabError> Callback;

        public void InvokeCallback()
        {
            PlayFabiOSPlugin.InvokeResponse(Url, CallId, Request, Result, Error, CustomData); // Do the globalMessage callback
            if (Callback != null)
                Callback(Result, Error); // Do the specific callback
        }
    }
}
