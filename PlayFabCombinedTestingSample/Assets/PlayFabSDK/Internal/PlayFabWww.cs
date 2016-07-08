using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
#if !UNITY_WSA && !UNITY_WP8
using System.IO;
using Ionic.Zlib;
#endif

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
            byte[] payload = Encoding.UTF8.GetBytes(requestContainer.Data);

#if UNITY_4_4 || UNITY_4_3 || UNITY_4_2 || UNITY_4_2 || UNITY_4_0 || UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5
            // Using hashtable for compatibility with Unity < 4.5
            Hashtable headers = new Hashtable ();
#else
            Dictionary<string, string> headers = new Dictionary<string, string>();
#endif

#if !UNITY_WSA && !UNITY_WP8
            if (PlayFabSettings.CompressApiData)
            {
                headers.Add("Content-Encoding", "GZIP");
                headers.Add("Accept-Encoding", "GZIP");

                using (var stream = new MemoryStream())
                {
                    using (
                        GZipStream zipstream = new GZipStream(stream, CompressionMode.Compress,
                            CompressionLevel.BestCompression))
                    {
                        zipstream.Write(payload, 0, payload.Length);
                    }
                    payload = stream.ToArray();
                }
            }
#endif

            headers.Add("Content-Type", "application/json");
            if (requestContainer.AuthType != null)
                headers.Add(requestContainer.AuthType, requestContainer.AuthKey);
            headers.Add("X-ReportErrorAsSuccess", "true");
            headers.Add("X-PlayFabSDK", PlayFabSettings.VersionString);
            WWW www = new WWW(fullUrl, payload, headers);

            PlayFabSettings.InvokeRequest(requestContainer.UrlPath, requestContainer.CallId, requestContainer.Request, requestContainer.CustomData);

            yield return www;

            requestContainer.ResultStr = null;
            requestContainer.Error = null;
            if (!string.IsNullOrEmpty(www.error))
            {
                requestContainer.Error = PlayFabHttp.GeneratePfError(HttpStatusCode.ServiceUnavailable, PlayFabErrorCode.ServiceUnavailable, www.error, requestContainer.CustomData);
            }
            else
            {
                string finalWwwText = "";

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
                                finalWwwText = streamReader.ReadToEnd();
                            }
                        }
                    }
                    catch
                    {
                        // If this was not a valid GZip response, then the uncompressed result is probably a valid response
                        finalWwwText = www.text;
                    }
                }
                else
                {
#endif
                    finalWwwText = www.text;
#if !UNITY_WSA && !UNITY_WP8
                }
#endif

                requestContainer.ResultStr = finalWwwText;
            }

            requestContainer.InvokeCallback();

            _pendingWwwMessages -= 1;
        }
    }
}
