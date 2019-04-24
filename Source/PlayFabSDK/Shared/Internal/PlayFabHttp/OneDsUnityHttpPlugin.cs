using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace PlayFab.Internal
{
    public class OneDsUnityHttpPlugin : IOneDSTransportPlugin
    {
        public void DoPost(object request, Dictionary<string, string> extraHeaders, Action<object> callback)
        {
            PlayFabHttp.instance.InjectInUnityThread(Post(request, extraHeaders, callback));
        }

        public IEnumerator Post(object request, Dictionary<string, string> extraHeaders, Action<object> callback)
        {
            var webRequest = new UnityWebRequest(OneDsUtility.ONEDS_SERVICE_URL, "POST");
            webRequest.uploadHandler = new UploadHandlerRaw(request as byte[]);
            webRequest.downloadHandler = new DownloadHandlerBuffer();

            string currentTimestampString = Microsoft.Applications.Events.Utils.MsFrom1970().ToString();
            extraHeaders.Add("sdk-version", "OCT_C#-0.11.1.0");
#if !UNITY_WSA && !UNITY_WP8 && !UNITY_WEBGL
            extraHeaders.Add("Content-Encoding", "gzip");
#endif
            extraHeaders.Add("Content-Type", "application/bond-compact-binary");
            extraHeaders.Add("Upload-Time", currentTimestampString);
            extraHeaders.Add("client-time-epoch-millis", currentTimestampString);
            extraHeaders.Add("Client-Id", "NO_AUTH");

            foreach (var header in extraHeaders)
                webRequest.SetRequestHeader(header.Key, header.Value);

#if UNITY_2017_2_OR_NEWER
            webRequest.chunkedTransfer = false; // can be removed after Unity's PUT will be more stable
            yield return webRequest.SendWebRequest();
#else
            yield return webRequest.Send();
#endif
            OneDsUtility.ParseResponse(webRequest.responseCode, () => webRequest.downloadHandler.text, webRequest.error, callback);
        }
    }
}
