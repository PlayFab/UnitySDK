using System.Collections.Generic;
using PlayFab.Json;
using System;
using System.Net;

namespace PlayFab.Internal
{
    public class PlayFabResultCommon
    {
        public object Request;
        public object CustomData;
    }

    internal class ResultContainer<TResultType> where TResultType : PlayFabResultCommon
    {
        public int code;
        public string status;
        public int? errorCode;
        public string errorMessage;
        public Dictionary<string, List<string>> errorDetails;
        public TResultType data;

        private static ResultContainer<TResultType> KillWarnings()
        {
            // Unity doesn't recognize decoding json as assigning variables, so we have to assign them here
            return new ResultContainer<TResultType>
            {
                code = (int)HttpStatusCode.OK,
                status = "",
                errorCode = (int)PlayFabErrorCode.Success,
                errorMessage = "",
                errorDetails = null,
                data = null
            };
        }

        private static readonly object[] _invokeParams = new object[1];
        public static TResultType HandleResults(CallRequestContainer callRequest, Delegate resultCallback, ErrorCallback errorCallback, Action<TResultType, CallRequestContainer> resultAction)
        {
            if (callRequest.Error == null) // Some other error earlier in the process, just report it below
            {
                try
                {
                    ResultContainer<TResultType> resultEnvelope = new ResultContainer<TResultType>();
                    JsonConvert.PopulateObject(callRequest.ResultStr, resultEnvelope, Util.JsonSettings);
                    if (!resultEnvelope.errorCode.HasValue || resultEnvelope.errorCode.Value == (int)PlayFabErrorCode.Success)
                    {
                        resultEnvelope.data.Request = callRequest.Request;
                        resultEnvelope.data.CustomData = callRequest.CustomData;
                        if (resultAction != null)
                            resultAction(resultEnvelope.data, callRequest);
                        if (resultCallback != null)
                        {
                            _invokeParams[0] = resultEnvelope.data;
                            resultCallback.DynamicInvoke(_invokeParams);
                        }
                        PlayFabSettings.InvokeResponse(callRequest.Url, callRequest.CallId, callRequest.Request, resultEnvelope.data, callRequest.Error, callRequest.CustomData); // Do the globalMessage callback
                        return resultEnvelope.data; // This is the expected output path for successful api call
                    }

                    // Successful HTTP interaction, but PlayFab server returned an error
                    callRequest.Error = new PlayFabError
                    {
                        HttpCode = resultEnvelope.code,
                        HttpStatus = resultEnvelope.status,
                        Error = (PlayFabErrorCode)resultEnvelope.errorCode.Value,
                        ErrorMessage = resultEnvelope.errorMessage,
                        ErrorDetails = resultEnvelope.errorDetails
                    };
                }
                catch (Exception e)
                {
                    // Failed to decode the result
                    callRequest.Error = new PlayFabError
                    {
                        HttpCode = (int)HttpStatusCode.OK, // Technically the server returned a result, the sdk just didn't parse it correctly
                        HttpStatus = "Client failed to parse response from server",
                        Error = PlayFabErrorCode.Unknown,
                        ErrorMessage = e.ToString(),
                        ErrorDetails = null
                    };
                }
            }

            if (errorCallback != null)
                errorCallback(callRequest.Error);
            if (PlayFabSettings.GlobalErrorHandler != null)
                PlayFabSettings.GlobalErrorHandler(callRequest.Error);
            return null;
        }
    }
}
