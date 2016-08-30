using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using PlayFab.Json;
using PlayFab.SharedModels;
using UnityEngine;

#if !UNITY_WSA && !UNITY_WP8
using Ionic.Zlib;
#endif

namespace PlayFab.Internal
{
    public class PlayFabWww : IPlayFabHttp
    {
        private int _pendingWwwMessages = 0;
        public bool SessionStarted { get; set; }
        public string AuthKey { get; set; }

        public void InitializeHttp() { }
        public void Update() { }
        public void OnDestroy() { }

        public void MakeApiCall(CallRequestContainer reqContainer)
        {
            //Set headers
            var headers = new Dictionary<string, string> { { "Content-Type", "application/json" } };
            if (reqContainer.AuthKey == AuthType.DevSecretKey)
            {
#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API
                headers.Add("X-SecretKey", PlayFabSettings.DeveloperSecretKey);
#endif
            }
            else if (reqContainer.AuthKey == AuthType.LoginSession)
            {
                headers.Add("X-Authorization", AuthKey);
            }

            headers.Add("X-ReportErrorAsSuccess", "true");
            headers.Add("X-PlayFabSDK", PlayFabSettings.VersionString);

#if !UNITY_WSA && !UNITY_WP8 && !UNITY_WEBGL
            if (PlayFabSettings.CompressApiData)
            {
                headers.Add("Content-Encoding", "GZIP");
                headers.Add("Accept-Encoding", "GZIP");

                using (var stream = new MemoryStream())
                {
                    using (GZipStream zipstream = new GZipStream(stream, CompressionMode.Compress, CompressionLevel.BestCompression))
                    {
                        zipstream.Write(reqContainer.Payload, 0, reqContainer.Payload.Length);
                    }
                    reqContainer.Payload = stream.ToArray();
                }
            }
#endif

            //Debug.LogFormat("Posting {0} to Url: {1}", req.Trim(), url);
            var www = new WWW(reqContainer.FullUrl, reqContainer.Payload, headers);

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
                    var httpResult = JsonWrapper.DeserializeObject<HttpResponseObject>(response, PlayFabUtil.ApiSerializerStrategy);

                    if (httpResult.code == 200)
                    {
                        // We have a good response from the server
                        reqContainer.JsonResponse = JsonWrapper.SerializeObject(httpResult.data, PlayFabUtil.ApiSerializerStrategy);
                        reqContainer.DeserializeResultJson();
                        reqContainer.ApiResult.Request = reqContainer.ApiRequest;
                        reqContainer.ApiResult.CustomData = reqContainer.CustomData;

#if !DISABLE_PLAYFABCLIENT_API
                        ClientModels.UserSettings userSettings = null;
                        var res = reqContainer.ApiResult as ClientModels.LoginResult;
                        var regRes = reqContainer.ApiResult as ClientModels.RegisterPlayFabUserResult;
                        if (res != null)
                        {
                            userSettings = res.SettingsForUser;
                            AuthKey = res.SessionTicket;
                        }
                        else if (regRes != null)
                        {
                            userSettings = regRes.SettingsForUser;
                            AuthKey = regRes.SessionTicket;
                        }

                        if (userSettings != null && AuthKey != null && userSettings.NeedsAttribution)
                        {
                            PlayFabIdfa.OnPlayFabLogin();
                        }

                        var cloudScriptUrl = reqContainer.ApiResult as ClientModels.GetCloudScriptUrlResult;
                        if (cloudScriptUrl != null)
                        {
                            PlayFabSettings.LogicServerUrl = cloudScriptUrl.Url;
                        }
#endif
                        try
                        {
                            PlayFabHttp.SendEvent(reqContainer.ApiRequest, reqContainer.ApiResult, ApiProcessingEventType.Post);
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
                            reqContainer.Error = PlayFabHttp.GeneratePlayFabError(response, reqContainer.CustomData);
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
                    reqContainer.Error = PlayFabHttp.GeneratePlayFabError(reqContainer.JsonResponse, reqContainer.CustomData);
                    PlayFabHttp.SendErrorEvent(reqContainer.ApiRequest, reqContainer.Error);
                    reqContainer.ErrorCallback(reqContainer.Error);
                }
            };

            PlayFabHttp.instance.StartCoroutine(Post(www, wwwSuccessCallback, wwwErrorCallback));
        }

        private IEnumerator Post(WWW www, Action<string> wwwSuccessCallback, Action<string> wwwErrorCallback)
        {
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            {
                wwwErrorCallback(www.error);
            }
            else
            {
#if !UNITY_WSA && !UNITY_WP8 && !UNITY_WEBGL
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
                                int read;
                                while ((read = gZipStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    output.Write(buffer, 0, read);
                                }
                                output.Seek(0, SeekOrigin.Begin);
                                var streamReader = new System.IO.StreamReader(output);
                                var jsonResponse = streamReader.ReadToEnd();
                                //Debug.Log(jsonResponse);
                                wwwSuccessCallback(jsonResponse);
                            }
                        }
                    }
                    catch
                    {
                        //if this was not a valid GZip response, then send the message back as text to the call back.
                        wwwSuccessCallback(www.text);
                    }
                }
                else
                {
#endif
                    wwwSuccessCallback(www.text);
#if !UNITY_WSA && !UNITY_WP8 && !UNITY_WEBGL
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
