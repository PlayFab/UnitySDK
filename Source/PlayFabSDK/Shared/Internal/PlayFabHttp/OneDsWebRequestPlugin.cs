using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

namespace PlayFab.Internal
{
    public class OneDsWebRequestPlugin : IOneDSTransportPlugin
    {
        public void DoPost(object request, Dictionary<string, string> extraHeaders, Action<object> callback)
        {
            var thread = new Thread(() =>
            {
                string currentTimestampString = Microsoft.Applications.Events.Utils.MsFrom1970().ToString();
                var httpRequest = (HttpWebRequest) WebRequest.Create(OneDsUtility.ONEDS_SERVICE_URL);

                httpRequest.Method = "POST";
                httpRequest.ContentType = "application/bond-compact-binary";
                httpRequest.Headers.Add("sdk-version", "OCT_C#-0.11.1.0");
#if !UNITY_WSA && !UNITY_WP8 && !UNITY_WEBGL
                httpRequest.Headers.Add("Content-Encoding", "gzip");
#endif
                httpRequest.Headers.Add("Upload-Time", currentTimestampString);
                httpRequest.Headers.Add("client-time-epoch-millis", currentTimestampString);
                httpRequest.Headers.Add("Client-Id", "NO_AUTH");

                foreach (var header in extraHeaders)
                    httpRequest.Headers.Add(header.Key, header.Value);

                var payload = request as byte[];

                if (payload != null)
                {
                    httpRequest.ContentLength = payload.Length;
                    using (var stream = httpRequest.GetRequestStream())
                    {
                        stream.Write(payload, 0, payload.Length);
                    }
                }

                try
                {
                    var response = (HttpWebResponse)httpRequest.GetResponse();

                    OneDsUtility.ParseResponse((long)response.StatusCode, () =>
                    {
                        string json;
                        using (var responseStream = new StreamReader(response.GetResponseStream()))
                        {
                            json = responseStream.ReadToEnd();
                        }
                        return json;
                    }, null, callback);
                }
                catch (WebException webException)
                {
                    if (callback == null)
                    {
                        return;
                    }

                    try
                    {
                        using (var responseStream = webException.Response.GetResponseStream())
                        {
                            if (responseStream != null)
                            {
                                using (var stream = new StreamReader(responseStream))
                                {
                                    callback.Invoke(new OneDsError
                                    {
                                        Error = PlayFabErrorCode.Unknown,
                                        ErrorMessage = stream.ReadToEnd()
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        callback.Invoke(new OneDsError
                        {
                            Error = PlayFabErrorCode.Unknown,
                            ErrorMessage = exception.Message
                        });
                    }
                }
                catch (Exception e)
                {
                    callback.Invoke(new OneDsError
                    {
                        Error = PlayFabErrorCode.Unknown,
                        ErrorMessage = e.Message
                    });
                }
            });

            thread.Start();
        }
    }
}
