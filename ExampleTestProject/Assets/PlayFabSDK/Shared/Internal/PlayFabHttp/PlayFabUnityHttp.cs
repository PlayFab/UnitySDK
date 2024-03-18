#if UNITY_2017_2_OR_NEWER

using PlayFab.SharedModels;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace PlayFab.Internal
{
    public class PlayFabUnityHttp : ITransportPlugin
    {
        private bool _isInitialized = false;
        private readonly int _pendingWwwMessages = 0;

        public bool IsInitialized { get { return _isInitialized; } }

        public void Initialize() { _isInitialized = true; }

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
                using (UnityWebRequest www = UnityWebRequest.Get(fullUrl))
                {
                    if (PlayFabSettings.staticSettings.CompressResponses)
                    {
                        www.SetRequestHeader("Accept-Encoding", "gzip");

                        if (PlayFabSettings.staticSettings.DecompressWithDownloadHandler)
                        {
                            www.downloadHandler = new GzipDownloadHandler();
                        }
                    }

#if UNITY_2017_2_OR_NEWER
                    yield return www.SendWebRequest();
#else
                    yield return www.Send();
#endif

                    if (!string.IsNullOrEmpty(www.error))
                        errorCallback(www.error);
                    else
                        successCallback(www.downloadHandler.data);
                };
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
                    request = new UnityWebRequest(fullUrl, "POST");
                    request.uploadHandler = (UploadHandler)new UploadHandlerRaw(payload);
                    request.SetRequestHeader("Content-Type", "application/json");
                    
                    if (PlayFabSettings.staticSettings.CompressResponses)
                    {
                        request.SetRequestHeader("Accept-Encoding", "gzip");
                        request.downloadHandler = PlayFabSettings.staticSettings.DecompressWithDownloadHandler ? new GzipDownloadHandler() 
                                                                                                               : new DownloadHandlerBuffer();
                    }
                    else
                    {
                        request.downloadHandler = new DownloadHandlerBuffer();
                    }
                }


#if UNITY_2017_2_OR_NEWER
#if !UNITY_2019_1_OR_NEWER
                request.chunkedTransfer = false; // can be removed after Unity's PUT will be more stable
#endif
                yield return request.SendWebRequest();
#else
                yield return request.Send();
#endif

#if UNITY_2020_1_OR_NEWER
                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
#else
                if (request.isNetworkError || request.isHttpError)
#endif
                {
                    errorCallback(request.error);
                }
                else
                {
                    successCallback(request.downloadHandler.data);
                }

                request.Dispose();
            }
        }

        public void MakeApiCall(object reqContainerObj)
        {
            CallRequestContainer reqContainer = (CallRequestContainer)reqContainerObj;
            reqContainer.RequestHeaders["Content-Type"] = "application/json";

            // Start the www corouting to Post, and get a response or error which is then passed to the callbacks.
            PlayFabHttp.instance.StartCoroutine(Post(reqContainer));
        }

        private IEnumerator Post(CallRequestContainer reqContainer)
        {
#if PLAYFAB_REQUEST_TIMING
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var startTime = DateTime.UtcNow;
#endif

            using var www = new UnityWebRequest(reqContainer.FullUrl)
            {
                uploadHandler = new UploadHandlerRaw(reqContainer.Payload),
                method = "POST"
            };

            if (reqContainer.settings.CompressResponses)
            {
                www.SetRequestHeader("Accept-Encoding", "gzip");
                www.downloadHandler = reqContainer.settings.DecompressWithDownloadHandler ? new GzipDownloadHandler()
                                                                                          : new DownloadHandlerBuffer();
            }
            else
            {
                www.downloadHandler = new DownloadHandlerBuffer();
            }

            foreach (var headerPair in reqContainer.RequestHeaders)
            {
                if (!string.IsNullOrEmpty(headerPair.Key) && !string.IsNullOrEmpty(headerPair.Value))
                    www.SetRequestHeader(headerPair.Key, headerPair.Value);
                else
                    Debug.LogWarning("Null header: " + headerPair.Key + " = " + headerPair.Value);
            }

#if UNITY_2017_2_OR_NEWER
            yield return www.SendWebRequest();
#else
            yield return www.Send();
#endif

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

            if (!string.IsNullOrEmpty(www.error))
            {
                OnError(www.error, reqContainer);
            }
            else
            {
                try
                {
                    byte[] responseBytes = www.downloadHandler.data;
                    string responseText = System.Text.Encoding.UTF8.GetString(responseBytes, 0, responseBytes.Length);
                    OnResponse(responseText, reqContainer);
                }
                catch (Exception e)
                {
                    OnError("Unhandled error in PlayFabUnityHttp: " + e, reqContainer);
                }
            }
            www.Dispose();
        }

        public int GetPendingMessages()
        {
            return _pendingWwwMessages;
        }

        public void OnResponse(string response, CallRequestContainer reqContainer)
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
        }

        public void OnError(string error, CallRequestContainer reqContainer)
        {
            reqContainer.JsonResponse = error;
            if (reqContainer.ErrorCallback != null)
            {
                reqContainer.Error = PlayFabHttp.GeneratePlayFabError(reqContainer.ApiEndpoint, reqContainer.JsonResponse, reqContainer.CustomData);
                PlayFabHttp.SendErrorEvent(reqContainer.ApiRequest, reqContainer.Error);
                reqContainer.ErrorCallback(reqContainer.Error);
            }
        }
    }
}

#endif
