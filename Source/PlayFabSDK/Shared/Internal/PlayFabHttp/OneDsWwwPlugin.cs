#if !UNITY_2018_2_OR_NEWER
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace PlayFab.Internal
{
    public class OneDsWwwPlugin : IOneDSTransportPlugin
    {
        public void DoPost(object request, Dictionary<string, string> extraHeaders, Action<object> callback)
        {
            PlayFabHttp.instance.InjectInUnityThread(OneDsPost(request, extraHeaders, callback));
        }

        private IEnumerator OneDsPost(object request, Dictionary<string, string> extraHeaders, Action<object> callback)
        {
            var payload = request as byte[];

            if (payload == null && callback != null)
            {
                callback.Invoke(new OneDsError
                {
                    Error = PlayFabErrorCode.Unknown,
                    ErrorMessage = "Request is null."
                });

                yield break;
            }

            var www = new UnityWebRequest(OneDsUtility.ONEDS_SERVICE_URL)
            {
                uploadHandler = new UploadHandlerRaw(payload),
                downloadHandler = new DownloadHandlerBuffer(),
                method = UnityWebRequest.kHttpVerbPOST
            };

            string currentTimestampString = Microsoft.Applications.Events.Utils.MsFrom1970().ToString();
            www.SetRequestHeader("sdk-version", "OCT_C#-0.11.1.0");
#if !UNITY_WSA && !UNITY_WP8 && !UNITY_WEBGL
            www.SetRequestHeader("Content-Encoding", "gzip");
#endif
            www.SetRequestHeader("Content-Type", "application/bond-compact-binary");
            www.SetRequestHeader("Upload-Time", currentTimestampString);
            www.SetRequestHeader("client-time-epoch-millis", currentTimestampString);
            www.SetRequestHeader("Client-Id", "NO_AUTH");

            foreach (var header in extraHeaders)
            {
                if (!string.IsNullOrEmpty(header.Key) && !string.IsNullOrEmpty(header.Value))
                    www.SetRequestHeader(header.Key, header.Value);
                else
                    Debug.LogWarning("Null header: " + header.Key + " = " + header.Value);
            }

#if UNITY_2017_2_OR_NEWER
            www.chunkedTransfer = false;
            yield return www.SendWebRequest();
#else
            yield return www.Send();
#endif

            using (www)
            {
                OneDsUtility.ParseResponse(www.responseCode, () => www.downloadHandler.text, www.error, callback);
            }
        }
    }
}
#endif
