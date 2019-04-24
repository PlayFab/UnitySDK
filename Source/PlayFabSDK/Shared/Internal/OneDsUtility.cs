using System;
using System.Threading.Tasks;

namespace PlayFab.Internal
{
    public static class OneDsUtility
    {
        // public const string ONEDS_SERVICE_URL = "https://mobile.events.data.microsoft.com/OneCollector/1.0/";
        public const string ONEDS_SERVICE_URL = "https://self.events.data.microsoft.com/OneCollector/1.0/";

        public static void ParseResponse(long httpCode, Func<string> getText, string errorString, Action<object> callback)
        {
            if (callback == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(errorString))
            {
                callback(new OneDsError
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
                    httpResponseString = getText();
                }
                catch (Exception exception)
                {
                    callback(new OneDsError
                    {
                        Error = PlayFabErrorCode.ConnectionError,
                        ErrorMessage = exception.Message
                    });
                    return;
                }

                if (httpCode >= 200 && httpCode < 300)
                {
                    var responseObj = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject(httpResponseString) as Json.JsonObject;
                    ulong oneDsResult = 0;

                    try
                    {
                        oneDsResult = ulong.Parse(responseObj["acc"].ToString());
                    }
                    catch (NullReferenceException e)
                    {
                        callback(new OneDsError
                        {
                            HttpCode = (int)httpCode,
                            HttpStatus = httpResponseString,
                            Error = PlayFabErrorCode.JsonParseError,
                            ErrorMessage = "Failed to parse response from OneDS server: " + e.Message
                        });

                        return;
                    }
                    catch (Exception e)
                    {
                        UnityEngine.Debug.LogException(e);
                        return;
                    }

                    try
                    {
                        if (oneDsResult > 0)
                        {
                            callback(httpResponseString);
                        }
                        else
                        {
                            callback(new OneDsError
                            {
                                HttpCode = (int)httpCode,
                                HttpStatus = httpResponseString,
                                Error = PlayFabErrorCode.PartialFailure,
                                ErrorMessage = "OneDS server did not accept events"
                            });
                        }
                    }
                    catch (Exception e)
                    {
                        UnityEngine.Debug.LogException(e);
                    }
                }
                else if ((httpCode >= 500 && httpCode != 501 && httpCode != 505) || httpCode == 408 || httpCode == 429)
                {
                    // following One-DS recommendations, HTTP response codes in this range (excluding and including specific codes)
                    // are eligible for retries

                    // TODO implement a retry policy
                    // As a placeholder, return an immediate error

                    callback(new OneDsError
                    {
                        HttpCode = (int)httpCode,
                        HttpStatus = httpResponseString,
                        Error = PlayFabErrorCode.UnknownError,
                        ErrorMessage = "Failed to send a batch of events to OneDS"
                    });
                }
                else
                {
                    // following One-DS recommendations, all other HTTP response codes are errors that should not be retried
                    callback(new OneDsError
                    {
                        HttpCode = (int)httpCode,
                        HttpStatus = httpResponseString,
                        Error = PlayFabErrorCode.UnknownError,
                        ErrorMessage = "Failed to send a batch of events to OneDS"
                    });
                }
            }
        }
        
        private const int WaitWhileFrequencyDefault = 25;
        private const int WaitWhileTimeoutDefault = -1;
        
#if !NET_4_6 && (NET_2_0_SUBSET || NET_2_0)
        public static Task WaitWhile(Func<bool> condition, int frequency = WaitWhileFrequencyDefault, int timeout = WaitWhileTimeoutDefault)
        {
            return Task.Run(() =>
            {
                var waitTask = Task.Run(() =>
                {
                    while (condition())
                    {
                        Task.Delay(frequency).Await();
                    }
                });

                if(waitTask != Task.WhenAny(waitTask, Task.Delay(timeout)).Await())
                    throw new TimeoutException();
            });
        }
#else
        public static async Task WaitWhile(Func<bool> condition, int frequency = WaitWhileFrequencyDefault, int timeout = WaitWhileTimeoutDefault)
        {
            var waitTask = Task.Run(async () =>
            {
                while (condition())
                {
                    await Task.Delay(frequency);
                }
            });

            if(waitTask != await Task.WhenAny(waitTask, Task.Delay(timeout)))
                throw new TimeoutException();
        }
#endif
    }

    public class OneDsError
    {
        public int HttpCode;
        public string HttpStatus;
        public PlayFabErrorCode Error;
        public string ErrorMessage;
    }
}
