#if !UNITY_2018_2_OR_NEWER // Unity has deprecated Www
using System;
using System.Collections;
using System.IO;
using PlayFab.Json;
using PlayFab.SharedModels;
using UnityEngine;
#if UNITY_5_4_OR_NEWER
using UnityEngine.Networking;
#else
using UnityEngine.Experimental.Networking;
#endif

namespace PlayFab.Internal
{
    public class PlayFabWww : ITransportPlugin
    {
        private bool _isInitialized = false;
        private int _pendingWwwMessages = 0;

        public bool IsInitialized { get { return _isInitialized; } }

        public void Initialize()
        {
            _isInitialized = true;
        }

        public void Update() { }
        public void OnDestroy() { }

        public void SimpleGetCall(string fullUrl, Action<byte[]> successCallback, Action<string> errorCallback)
        {
            PlayFabHttp.instance.StartCoroutine(SimpleCallCoroutine("get", fullUrl, null, successCallback, errorCallback));
        }

        public void SimplePutCall(string fullUrl, byte[] payload, Action<byte[]> successCallback, Action<string> errorCallback)
        {
            PlayFabHttp.instance.StartCoroutine(SimpleCallCoroutine("put", fullUrl, payload, successCallback, errorCallback));
        }

        public void SimplePostCall(string fullUrl, byte[] payload, Action<byte[]> successCallback, Action<string> errorCallback)
        {
            PlayFabHttp.instance.StartCoroutine(SimpleCallCoroutine("post", fullUrl, payload, successCallback, errorCallback));
        }

        private static IEnumerator SimpleCallCoroutine(string method, string fullUrl, byte[] payload, Action<byte[]> successCallback, Action<string> errorCallback)
        {
            if (payload == null)
            {
                var www = new WWW(fullUrl);
                yield return www;
                if (!string.IsNullOrEmpty(www.error))
                    errorCallback(www.error);
                else
                    successCallback(www.bytes);
            }
            else
            {
                UnityWebRequest request;
                if (method == "put")
                {
                    request = UnityWebRequest.Put(fullUrl, payload);
                }
                else
                {
                    var strPayload = System.Text.Encoding.UTF8.GetString(payload, 0, payload.Length);
                    request = UnityWebRequest.Post(fullUrl, strPayload);
                }

#if UNITY_2017_2_OR_NEWER
                request.chunkedTransfer = false; // can be removed after Unity's PUT will be more stable
                request.SendWebRequest();
#else
                request.Send();
#endif

#if !UNITY_WEBGL
                while (request.uploadProgress < 1 || request.downloadProgress < 1)
                {
                    yield return 1;
                }
#else
                while (!request.isDone)
                {
                    yield return 1;
                }
#endif

                if (!string.IsNullOrEmpty(request.error))
                    errorCallback(request.error);
                else
                    successCallback(request.downloadHandler.data);
            }
        }

        public void MakeApiCall(object reqContainerObj)
        {
            CallRequestContainer reqContainer = (CallRequestContainer)reqContainerObj;
            reqContainer.RequestHeaders["Content-Type"] = "application/json";

            //Debug.LogFormat("Posting {0} to Url: {1}", req.Trim(), url);
            var www = new WWW(reqContainer.FullUrl, reqContainer.Payload, reqContainer.RequestHeaders);

#if PLAYFAB_REQUEST_TIMING
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
#endif

            // Start the www corouting to Post, and get a response or error which is then passed to the callbacks.
            Action<string> wwwSuccessCallback = (response) =>
            {
                try
                {
#if PLAYFAB_REQUEST_TIMING
                    var startTime = DateTime.UtcNow;
#endif
                    var serializer = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);
                    var httpResult = serializer.DeserializeObject<HttpResponseObject>(response);

                    if (httpResult.code == 200)
                    {
                        // We have a good response from the server
                        reqContainer.JsonResponse = serializer.SerializeObject(httpResult.data);
                        reqContainer.DeserializeResultJson();
                        reqContainer.ApiResult.Request = reqContainer.ApiRequest;
                        reqContainer.ApiResult.CustomData = reqContainer.CustomData;

                        PlayFabHttp.instance.OnPlayFabApiResult(reqContainer);
#if !DISABLE_PLAYFABCLIENT_API
                        PlayFabDeviceUtil.OnPlayFabLogin(reqContainer.ApiResult, reqContainer.settings, reqContainer.instanceApi);
#endif

                        try
                        {
                            PlayFabHttp.SendEvent(reqContainer.ApiEndpoint, reqContainer.ApiRequest, reqContainer.ApiResult, ApiProcessingEventType.Post);
                        }
                        catch (Exception e)
                        {
                            Debug.LogException(e);
                        }

#if PLAYFAB_REQUEST_TIMING
                        stopwatch.Stop();
                        var timing = new PlayFabHttp.RequestTiming {
                            StartTimeUtc = startTime,
                            ApiEndpoint = reqContainer.ApiEndpoint,
                            WorkerRequestMs = (int)stopwatch.ElapsedMilliseconds,
                            MainThreadRequestMs = (int)stopwatch.ElapsedMilliseconds
                        };
                        PlayFabHttp.SendRequestTiming(timing);
#endif
                        try
                        {
                            reqContainer.InvokeSuccessCallback();
                        }
                        catch (Exception e)
                        {
                            Debug.LogException(e);
                        }
                    }
                    else
                    {
                        if (reqContainer.ErrorCallback != null)
                        {
                            reqContainer.Error = PlayFabHttp.GeneratePlayFabError(reqContainer.ApiEndpoint, response, reqContainer.CustomData);
                            PlayFabHttp.SendErrorEvent(reqContainer.ApiRequest, reqContainer.Error);
                            reqContainer.ErrorCallback(reqContainer.Error);
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            };

            Action<string> wwwErrorCallback = (errorCb) =>
            {
                reqContainer.JsonResponse = errorCb;
                if (reqContainer.ErrorCallback != null)
                {
                    reqContainer.Error = PlayFabHttp.GeneratePlayFabError(reqContainer.ApiEndpoint, reqContainer.JsonResponse, reqContainer.CustomData);
                    PlayFabHttp.SendErrorEvent(reqContainer.ApiRequest, reqContainer.Error);
                    reqContainer.ErrorCallback(reqContainer.Error);
                }
            };

            PlayFabHttp.instance.StartCoroutine(PostPlayFabApiCall(www, wwwSuccessCallback, wwwErrorCallback));
        }

        private IEnumerator PostPlayFabApiCall(WWW www, Action<string> wwwSuccessCallback, Action<string> wwwErrorCallback)
        {
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            {
                wwwErrorCallback(www.error);
            }
            else
            {
                try
                {
                    byte[] responseBytes = www.bytes;
                    string responseText = System.Text.Encoding.UTF8.GetString(responseBytes, 0, responseBytes.Length);
                    wwwSuccessCallback(responseText);
                }
                catch (Exception e)
                {
                    wwwErrorCallback("Unhandled error in PlayFabWWW: " + e);
                }
            }
            www.Dispose();
        }

        public int GetPendingMessages()
        {
            return _pendingWwwMessages;
        }
    }
}
#endif
