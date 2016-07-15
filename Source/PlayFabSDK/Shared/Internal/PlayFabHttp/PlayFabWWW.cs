using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
#if !UNITY_WSA && !UNITY_WP8
using Ionic.Zlib;
#endif
using PlayFab.SharedModels;
#if !DISABLE_PLAYFABCLIENT_API
using PlayFab.ClientModels;
#endif
using PlayFab.Json;

namespace PlayFab.Internal
{
    public class PlayFabWWW : IPlayFabHttp
    {
        private readonly object _eventLock = new object();
        private int _pendingWwwMessages = 0;
        public string AuthKey { get; set; }
        public string DevKey { get; set; }

        public void Awake() { }
        public void Update() { }

        public void MakeApiCall<TRequestType, TResultType>(string api, string apiEndpoint, TRequestType request,
            string authType,
            Action<TResultType> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            //serialize the request;
            var req = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            var url = PlayFabSettings.GetFullUrl(apiEndpoint);

            //Set headers
            var headers = new Dictionary<string, string> { { "Content-Type", "application/json" } };
            if (authType != null)
            {
                if (authType == "X-SecretKey")
                {
                    headers.Add("X-SecretKey", DevKey);
                }
                else
                {
                    headers.Add(authType, AuthKey);
                }
            }

            headers.Add("X-ReportErrorAsSuccess", "true");
            headers.Add("X-PlayFabSDK", PlayFabSettings.VersionString);

            //Encode Payload
            var payload = System.Text.Encoding.UTF8.GetBytes(req.Trim());

#if !UNITY_WSA && !UNITY_WP8
            if (PlayFabSettings.CompressApiData)
            {
                headers.Add("Content-Encoding", "GZIP");
                headers.Add("Accept-Encoding", "GZIP");

                using (var stream = new MemoryStream())
                {
                    using (GZipStream zipstream = new GZipStream(stream, CompressionMode.Compress, CompressionLevel.BestCompression))
                    {
                        zipstream.Write(payload, 0, payload.Length);
                    }
                    payload = stream.ToArray();
                }
            }
#endif

            //Debug.LogFormat("Posting {0} to Url: {1}", req.Trim(), url);
            var www = new WWW(url, payload, headers);

#if PLAYFAB_REQUEST_TIMING
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
#endif

            //Start the www corouting to Post, and get a response or error which is 
            //then passed to the callbacks.
            PlayFabHttp.instance.StartCoroutine(Post(www, (response) =>
            {
                try
                {
#if PLAYFAB_REQUEST_TIMING
                    var startTime = DateTime.UtcNow;
#endif
                    //Debug.Log(response);
                    var httpResult = JsonWrapper.DeserializeObject<PlayFabHttp.HttpResponseObject>(response,
                        PlayFabUtil.ApiSerializerStrategy);

                    if (httpResult.code == 200)
                    {
                        //We have a good response from the server
                        var dataJson = JsonWrapper.SerializeObject(httpResult.data, PlayFabUtil.ApiSerializerStrategy);
                        var result = JsonWrapper.DeserializeObject<TResultType>(dataJson,
                            PlayFabUtil.ApiSerializerStrategy);

                        var resultCommon = result as PlayFabResultCommon;
                        if (resultCommon != null)
                        {
                            resultCommon.Request = request;
                            resultCommon.CustomData = customData;
                        }

#if !DISABLE_PLAYFABCLIENT_API
                        UserSettings userSettings = null;
                        var res = result as LoginResult;
                        var regRes = result as RegisterPlayFabUserResult;
                        if (res != null)
                        {
                            userSettings = res.SettingsForUser;
                            AuthKey = res.SessionTicket;
                        }
                        else if (regRes != null)
                        {
                            userSettings = res.SettingsForUser;
                            AuthKey = regRes.SessionTicket;
                        }

                        if (userSettings != null)
                        {
                            AuthKey = res.SessionTicket;
                            #region Track IDFA

#if !DISABLE_IDFA
#if UNITY_IOS || UNITY_ANDROID
                            if (userSettings.NeedsAttribution)
                            {
                                Application.RequestAdvertisingIdentifierAsync(
                                    (advertisingId, trackingEnabled, error) =>
                                    {
                                        if (trackingEnabled)
                                        {
                                            var attribRequest = new AttributeInstallRequest();
#if UNITY_ANDROID
                                            attribRequest.Android_Id = advertisingId;
#elif UNITY_IOS
                                            attribRequest.Idfa = advertisingId;
#endif
                                            PlayFabClientAPI.AttributeInstall(attribRequest, (attribResult) =>
                                            {
                                                //This is for internal testing tools.
                                                PlayFabSettings.AdvertisingIdType += "_Successful";
                                            }, null);
                                        }
                                    });
                            }
#endif
#endif

                            #endregion
                        }

                        var cloudScriptUrl = result as GetCloudScriptUrlResult;
                        if (cloudScriptUrl != null)
                        {
                            PlayFabSettings.LogicServerUrl = cloudScriptUrl.Url;
                        }
#endif
                        lock (_eventLock)
                        {
                            try
                            {
                                PlayFabHttp.SendEvent(request, result, ApiProcessingEventType.Post);
                            }
                            catch (Exception e)
                            {
                                Debug.LogException(e);
                            }
                        }

#if PLAYFAB_REQUEST_TIMING
                        stopwatch.Stop();
                        var timing = new PlayFabHttp.RequestTiming {
                            StartTimeUtc = startTime,
                            ApiEndpoint = apiEndpoint,
                            WorkerRequestMs = (int)stopwatch.ElapsedMilliseconds,
                            MainThreadRequestMs = (int)stopwatch.ElapsedMilliseconds
                        };
                        PlayFabHttp.SendRequestTiming(timing);
#endif

                        if (resultCallback != null)
                        {
                            try
                            {
                                resultCallback(result);
                            }
                            catch (Exception e)
                            {
                                Debug.LogException(e);
                            }
                        }
                    }
                    else
                    {
                        if (errorCallback != null)
                        {
                            var playFabError = PlayFabHttp.GeneratePlayFabError(response, customData);
                            PlayFabHttp.SendErrorEvent(request, playFabError);
                            errorCallback(playFabError);
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }

            }, (errorCb) =>
            {
                if (errorCallback != null)
                {
                    var playFabError = PlayFabHttp.GeneratePlayFabErrorGeneric(errorCb, null, customData);
                    PlayFabHttp.SendErrorEvent(request, playFabError);
                    errorCallback(playFabError);
                }
            }));
        }

        private IEnumerator Post(WWW www, Action<string> callBack, Action<string> errorCallback)
        {
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            {
                errorCallback(www.error);
            }
            else
            {
#if !UNITY_WSA && !UNITY_WP8
                if (PlayFabSettings.CompressApiData)
                {
                    try
                    {
                        var stream = new MemoryStream(www.bytes);
                        using (var gZipStream = new GZipStream(stream, CompressionMode.Decompress, false))
                        {
                            var buffer = new byte[4096];
                            using (var output = new MemoryStream())
                            {
                                var read = 0;
                                while ((read = gZipStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    output.Write(buffer, 0, read);
                                }
                                output.Seek(0, SeekOrigin.Begin);
                                var streamReader = new System.IO.StreamReader(output);
                                var jsonResponse = streamReader.ReadToEnd();
                                //Debug.Log(jsonResponse);
                                callBack(jsonResponse);
                            }
                        }
                    }
                    catch
                    {
                        //if this was not a valid GZip response, then send the message back as text to the call back.
                        callBack(www.text);
                    }
                }
                else
                {
#endif
                    callBack(www.text);
#if !UNITY_WSA && !UNITY_WP8
                }
#endif
            }
        }

        public int GetPendingMessages()
        {
            return _pendingWwwMessages;
        }

    }
}
