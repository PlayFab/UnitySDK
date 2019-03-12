#if NET_4_6
using System;

namespace PlayFab.Internal
{
    public static class OneDsUtility
    {
        // public const string ONEDS_SERVICE_URL = "https://mobile.events.data.microsoft.com/OneCollector/1.0/";
        public const string ONEDS_SERVICE_URL = "https://self.events.data.microsoft.com/OneCollector/1.0/";
        
        public static void ParseResponse(long httpCode, Func<string> getText, string errorString, Action<object> callback)
        {
            if (!string.IsNullOrEmpty(errorString))
            {
                callback.Invoke(new PlayFabError
                {
                    Error = PlayFabErrorCode.Unknown,
                    ErrorMessage = errorString
                });
            }
            else
            {
                string httpResponseString;
                try
                {
                    httpResponseString = getText.Invoke();
                }
                catch (Exception exception)
                {
                    var error = new PlayFabError();
                    error.Error = PlayFabErrorCode.ConnectionError;
                    error.ErrorMessage = exception.Message;
                    callback?.Invoke(error);
                    return;
                }

                if (httpCode >= 200 && httpCode < 300)
                {
                    var responseObj = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject(httpResponseString) as Json.JsonObject;

                    try
                    {
                        ulong oneDsResult = ulong.Parse(responseObj["acc"].ToString());

                        if (oneDsResult > 0)
                        {
                            callback?.Invoke(httpResponseString);
                        }
                        else
                        {
                            var error = new PlayFabError();
                            error.HttpCode = (int) httpCode;
                            error.HttpStatus = httpResponseString;
                            error.Error = PlayFabErrorCode.PartialFailure;
                            error.ErrorMessage = "OneDS server did not accept events";
                            callback?.Invoke(error);
                        }
                    }
                    catch (Exception e)
                    {
                        var error = new PlayFabError();
                        error.HttpCode = (int) httpCode;
                        error.HttpStatus = httpResponseString;
                        error.Error = PlayFabErrorCode.JsonParseError;
                        error.ErrorMessage = "Failed to parse response from OneDS server: " + e.Message;
                        callback?.Invoke(error);
                    }
                }
                else if ((httpCode >= 500 && httpCode != 501 && httpCode != 505) || httpCode == 408 || httpCode == 429)
                {
                    // following One-DS recommendations, HTTP response codes in this range (excluding and including specific codes)
                    // are eligible for retries

                    // TODO implement a retry policy
                    // As a placeholder, return an immediate error

                    var error = new PlayFabError();
                    error.HttpCode = (int) httpCode;
                    error.HttpStatus = httpResponseString;
                    error.Error = PlayFabErrorCode.UnknownError;
                    error.ErrorMessage = "Failed to send a batch of events to OneDS";
                    callback?.Invoke(error);
                }
                else
                {
                    // following One-DS recommendations, all other HTTP response codes are errors that should not be retried
                    var error = new PlayFabError();
                    error.HttpCode = (int) httpCode;
                    error.HttpStatus = httpResponseString;
                    error.Error = PlayFabErrorCode.UnknownError;
                    error.ErrorMessage = "Failed to send a batch of events to OneDS";
                    callback?.Invoke(error);
                }
            }
        }
    }
}
#endif