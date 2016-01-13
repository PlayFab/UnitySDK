using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace PlayFab.Examples
{
    public class ExampleApiLog : MonoBehaviour
    {
        private static readonly Dictionary<int, DateTime> CallTimes_StGl = new Dictionary<int, DateTime>();
        private static readonly Dictionary<int, DateTime> CallTimes_InstGl = new Dictionary<int, DateTime>();
        private static readonly Dictionary<int, DateTime> CallTimes_StLogin = new Dictionary<int, DateTime>();
        private static readonly Dictionary<int, DateTime> CallTimes_InstLogin = new Dictionary<int, DateTime>();

        public void Awake()
        {
            PlayFabSettings.RegisterForRequests(null, GetType().GetMethod("OnApiRequest_StGl", BindingFlags.Static | BindingFlags.NonPublic), null);
            PlayFabSettings.RegisterForResponses(null, GetType().GetMethod("OnApiResponse_StGl", BindingFlags.Static | BindingFlags.NonPublic), null);
            PlayFabSettings.RegisterForRequests(null, GetType().GetMethod("OnApiRequest_InstGl", BindingFlags.Instance | BindingFlags.NonPublic), this);
            PlayFabSettings.RegisterForResponses(null, GetType().GetMethod("OnApiResponse_InstGl", BindingFlags.Instance | BindingFlags.NonPublic), this);

            PlayFabSettings.RegisterForRequests("/Client/LoginWithEmailAddress", GetType().GetMethod("OnApiRequest_StLogin", BindingFlags.Static | BindingFlags.NonPublic), null);
            PlayFabSettings.RegisterForResponses("/Client/LoginWithEmailAddress", GetType().GetMethod("OnApiResponse_StLogin", BindingFlags.Static | BindingFlags.NonPublic), null);
            PlayFabSettings.RegisterForRequests("/Client/LoginWithEmailAddress", GetType().GetMethod("OnApiRequest_InstLogin", BindingFlags.Instance | BindingFlags.NonPublic), this);
            PlayFabSettings.RegisterForResponses("/Client/LoginWithEmailAddress", GetType().GetMethod("OnApiResponse_InstLogin", BindingFlags.Instance | BindingFlags.NonPublic), this);

            PlayFabSettings.RegisterForRequests("/Client/LoginWithAndroidDeviceID", GetType().GetMethod("OnApiRequest_StLogin", BindingFlags.Static | BindingFlags.NonPublic), null);
            PlayFabSettings.RegisterForResponses("/Client/LoginWithAndroidDeviceID", GetType().GetMethod("OnApiResponse_StLogin", BindingFlags.Static | BindingFlags.NonPublic), null);
            PlayFabSettings.RegisterForRequests("/Client/LoginWithAndroidDeviceID", GetType().GetMethod("OnApiRequest_InstLogin", BindingFlags.Instance | BindingFlags.NonPublic), this);
            PlayFabSettings.RegisterForResponses("/Client/LoginWithAndroidDeviceID", GetType().GetMethod("OnApiResponse_InstLogin", BindingFlags.Instance | BindingFlags.NonPublic), this);

            PlayFabSettings.RegisterForRequests("/Client/LoginWithIOSDeviceID", GetType().GetMethod("OnApiRequest_StLogin", BindingFlags.Static | BindingFlags.NonPublic), null);
            PlayFabSettings.RegisterForResponses("/Client/LoginWithIOSDeviceID", GetType().GetMethod("OnApiResponse_StLogin", BindingFlags.Static | BindingFlags.NonPublic), null);
            PlayFabSettings.RegisterForRequests("/Client/LoginWithIOSDeviceID", GetType().GetMethod("OnApiRequest_InstLogin", BindingFlags.Instance | BindingFlags.NonPublic), this);
            PlayFabSettings.RegisterForResponses("/Client/LoginWithIOSDeviceID", GetType().GetMethod("OnApiResponse_InstLogin", BindingFlags.Instance | BindingFlags.NonPublic), this);
        }

        public void OnDestroy()
        {
            PlayFabSettings.UnregisterInstance(this); // Automatically unregisters all callbacks bound to this instance

            PlayFabSettings.UnregisterForRequests(null, GetType().GetMethod("OnApiRequest_StGl", BindingFlags.Static | BindingFlags.NonPublic), null);
            PlayFabSettings.UnregisterForResponses(null, GetType().GetMethod("OnApiResponse_StGl", BindingFlags.Static | BindingFlags.NonPublic), null);

            PlayFabSettings.UnregisterForRequests("/Client/LoginWithEmailAddress", GetType().GetMethod("OnApiRequest_StLogin", BindingFlags.Static | BindingFlags.NonPublic), null);
            PlayFabSettings.UnregisterForResponses("/Client/LoginWithEmailAddress", GetType().GetMethod("OnApiResponse_StLogin", BindingFlags.Static | BindingFlags.NonPublic), null);

            PlayFabSettings.UnregisterForRequests("/Client/LoginWithAndroidDeviceID", GetType().GetMethod("OnApiRequest_StLogin", BindingFlags.Static | BindingFlags.NonPublic), null);
            PlayFabSettings.UnregisterForResponses("/Client/LoginWithAndroidDeviceID", GetType().GetMethod("OnApiResponse_StLogin", BindingFlags.Static | BindingFlags.NonPublic), null);

            PlayFabSettings.UnregisterForRequests("/Client/LoginWithIOSDeviceID", GetType().GetMethod("OnApiRequest_StLogin", BindingFlags.Static | BindingFlags.NonPublic), null);
            PlayFabSettings.UnregisterForResponses("/Client/LoginWithIOSDeviceID", GetType().GetMethod("OnApiResponse_StLogin", BindingFlags.Static | BindingFlags.NonPublic), null);
        }

        private static void OnApiRequest_StGl(string url, int callId, object request, object customData)
        {
            CallTimes_StGl[callId] = DateTime.UtcNow;
        }

        private static void OnApiResponse_StGl(string url, int callId, object request, object result, PlayFabError error, object customData)
        {
            var delta = DateTime.UtcNow - CallTimes_StGl[callId];
            Debug.Log(url + " completed in " + delta.TotalMilliseconds + " - _StGl");
            CallTimes_StGl.Remove(callId);
        }

        private static void OnApiRequest_StLogin(string url, int callId, object request, object customData)
        {
            CallTimes_StLogin[callId] = DateTime.UtcNow;
        }

        private static void OnApiResponse_StLogin(string url, int callId, object request, object result, PlayFabError error, object customData)
        {
            var delta = DateTime.UtcNow - CallTimes_StLogin[callId];
            Debug.Log(url + " completed in " + delta.TotalMilliseconds + " - _StLogin");
            CallTimes_StLogin.Remove(callId);
        }

        private void OnApiRequest_InstGl(string url, int callId, object request, object customData)
        {
            CallTimes_InstGl[callId] = DateTime.UtcNow;
        }

        private void OnApiResponse_InstGl(string url, int callId, object request, object result, PlayFabError error, object customData)
        {
            var delta = DateTime.UtcNow - CallTimes_InstGl[callId];
            Debug.Log(url + " completed in " + delta.TotalMilliseconds + " - _InstGl");
            CallTimes_InstGl.Remove(callId);
        }

        private void OnApiRequest_InstLogin(string url, int callId, object request, object customData)
        {
            CallTimes_InstLogin[callId] = DateTime.UtcNow;
        }

        private void OnApiResponse_InstLogin(string url, int callId, object request, object result, PlayFabError error, object customData)
        {
            var delta = DateTime.UtcNow - CallTimes_InstLogin[callId];
            Debug.Log(url + " completed in " + delta.TotalMilliseconds + " - _InstLogin");
            CallTimes_InstLogin.Remove(callId);
        }
    }
}
