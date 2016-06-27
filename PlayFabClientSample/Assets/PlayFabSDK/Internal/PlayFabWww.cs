using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PlayFab.Internal
{
    internal class PlayFabWww : IPlayFabHttp
    {
        private int _pendingWwwMessages = 0;

        public void Awake() { }
        public void Update() { }

        public void Post(CallRequestContainer requestContainer)
        {
            PlayFabHttp.instance.StartCoroutine(MakeRequestViaUnity(requestContainer));
        }

        public int GetPendingMessages()
        {
            return _pendingWwwMessages;
        }

        // This is the old Unity WWW class call.
        private IEnumerator MakeRequestViaUnity(CallRequestContainer requestContainer)
        {
            _pendingWwwMessages += 1;
            string fullUrl = PlayFabSettings.GetFullUrl(requestContainer.UrlPath);
            byte[] bData = Encoding.UTF8.GetBytes(requestContainer.Data);

#if UNITY_4_4 || UNITY_4_3 || UNITY_4_2 || UNITY_4_2 || UNITY_4_0 || UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5
            // Using hashtable for compatibility with Unity < 4.5
            Hashtable headers = new Hashtable ();
#else
            Dictionary<string, string> headers = new Dictionary<string, string>();
#endif
            headers.Add("Content-Type", "application/json");
            if (requestContainer.AuthType != null)
                headers.Add(requestContainer.AuthType, requestContainer.AuthKey);
            headers.Add("X-ReportErrorAsSuccess", "true");
            headers.Add("X-PlayFabSDK", PlayFabSettings.VersionString);
            WWW www = new WWW(fullUrl, bData, headers);

            PlayFabSettings.InvokeRequest(requestContainer.UrlPath, requestContainer.CallId, requestContainer.Request, requestContainer.CustomData);

            yield return www;

            requestContainer.ResultStr = null;
            requestContainer.Error = null;
            if (!string.IsNullOrEmpty(www.error))
                requestContainer.Error = PlayFabHttp.GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, www.error);
            else
                requestContainer.ResultStr = www.text;

            requestContainer.InvokeCallback();

            _pendingWwwMessages -= 1;
        }
    }
}
