using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using PlayFab.PfEditor.Json;
using UnityEngine.Networking;

namespace PlayFab.PfEditor
{
    public class PlayFabEditorHttp : UnityEditor.Editor
    {
        internal static void MakeDownloadCall(string url, Action<string> resultCallback)
        {
#if UNITY_2018_2_OR_NEWER
            UnityWebRequest www = UnityWebRequest.Get(url);
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnHttpReq, url, PlayFabEditorHelper.MSG_SPIN_BLOCK);
            EditorCoroutine.Start(PostDownload(www, (response) => { WriteResultFile(url, resultCallback, response); }, PlayFabEditorHelper.SharedErrorCallback), www);
#else
            var www = new WWW(url);
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnHttpReq, url, PlayFabEditorHelper.MSG_SPIN_BLOCK);
            EditorCoroutine.Start(PostDownload(www, (response) => { WriteResultFile(url, resultCallback, response); }, PlayFabEditorHelper.SharedErrorCallback), www);
#endif
        }

        private static void WriteResultFile(string url, Action<string> resultCallback, byte[] response)
        {
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnHttpRes, url);

            string fileName;
            if (url.IndexOf("unity-edex") > -1)
                fileName = PlayFabEditorHelper.EDEX_UPGRADE_PATH;
            else if (url.IndexOf("unity-via-edex") > -1)
                fileName = PlayFabEditorHelper.SDK_DOWNLOAD_PATH;
            else
                fileName = PlayFabEditorHelper.EDEX_PACKAGES_PATH;

            var fileSaveLocation = PlayFabEditorHelper.EDEX_ROOT + fileName;
            var fileSaveDirectory = Path.GetDirectoryName(fileSaveLocation);
            Debug.Log("Saving " + response.Length + " bytes to: " + fileSaveLocation);
            if (!Directory.Exists(fileSaveDirectory))
                Directory.CreateDirectory(fileSaveDirectory);
            File.WriteAllBytes(fileSaveLocation, response);
            resultCallback(fileSaveLocation);
        }

        internal static void MakeGitHubApiCall(string url, Action<string> resultCallback)
        {
#if UNITY_2018_2_OR_NEWER
            UnityWebRequest webReq = UnityWebRequest.Get(url);
            EditorCoroutine.Start(Post(webReq, (response) => { OnGitHubSuccess(resultCallback, response); }, PlayFabEditorHelper.SharedErrorCallback), webReq);
#else
            var www = new WWW(url);
            EditorCoroutine.Start(Post(www, (response) => { OnGitHubSuccess(resultCallback, response); }, PlayFabEditorHelper.SharedErrorCallback), www);
#endif
        }

        private static void OnGitHubSuccess(Action<string> resultCallback, string response)
        {
            if (resultCallback == null)
                return;

            var jsonResponse = JsonWrapper.DeserializeObject<List<object>>(response);
            if (jsonResponse == null || jsonResponse.Count == 0)
                return;

            // list seems to come back in ascending order (oldest -> newest)
            var latestSdkTag = (JsonObject)jsonResponse[jsonResponse.Count - 1];
            object tag;
            if (latestSdkTag.TryGetValue("ref", out tag))
            {
                var startIndex = tag.ToString().LastIndexOf('/') + 1;
                var length = tag.ToString().Length - startIndex;
                resultCallback(tag.ToString().Substring(startIndex, length));
            }
            else
            {
                resultCallback(null);
            }
        }
#if UNITY_2018_2_OR_NEWER

        private static IEnumerator Post(UnityWebRequest www, Action<string> callBack, Action<string> errorCallback)
        {
            if (www != null)
            {
                yield return www.SendWebRequest();

                if (!string.IsNullOrEmpty(www.error))
                    errorCallback(www.error);
                else
                    callBack(www.downloadHandler.text);
            }
            else
            {
                UnityEngine.Debug.Log("UnityWebRequest was null");
                errorCallback("UnityWebRequest Object was null");
            }
        }

        private static IEnumerator PostDownload(UnityWebRequest www, Action<byte[]> callBack, Action<string> errorCallback)
        {
            if (www != null)
            {
                yield return www.SendWebRequest();

#if UNITY_2020_1_OR_NEWER
                if (!string.IsNullOrEmpty(www.error) || www.result == UnityWebRequest.Result.ProtocolError)
#else
                if (!string.IsNullOrEmpty(www.error) || www.isHttpError)
#endif
                {
                    errorCallback(www.error);
                }
                else
                {
                    callBack(www.downloadHandler.data);
                }
            }
            else
            {
                UnityEngine.Debug.Log("UnityWebRequest was null");
                errorCallback("UnityWebRequest Object was null");
            }
        }
#else 
        private static IEnumerator Post(WWW www, Action<string> callBack, Action<string> errorCallback)
        {
            yield return www;

            if (!string.IsNullOrEmpty(www.error))
                errorCallback(www.error);
            else
                callBack(www.text);
        }

        private static IEnumerator PostDownload(WWW www, Action<byte[]> callBack, Action<string> errorCallback)
        {
            yield return www;

            if (!string.IsNullOrEmpty(www.error))
                errorCallback(www.error);
            else
                callBack(www.bytes);
        }
#endif
    }
}
