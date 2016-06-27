using PlayFab.Json;
using System.Collections.Generic;
using System;
using System.Net;

namespace PlayFab.Internal
{
    public class PlayFabResultCommon
    {
        public delegate void ProcessApiCallback<in TResult>(TResult result) where TResult : PlayFabResultCommon;

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

        public static TResultType HandleResults(CallRequestContainer callRequest, Delegate resultCallback, ErrorCallback errorCallback, Action<TResultType, CallRequestContainer> resultAction)
        {
            if (callRequest.Error == null) // Some other error earlier in the process, just report it below
            {
                try
                {
                    ResultContainer<TResultType> resultEnvelope = JsonWrapper.DeserializeObject<ResultContainer<TResultType>>(callRequest.ResultStr, PlayFabUtil.ApiSerializerStrategy);
                    if (!resultEnvelope.errorCode.HasValue || resultEnvelope.errorCode.Value == (int)PlayFabErrorCode.Success)
                    {
                        resultEnvelope.data.Request = callRequest.Request;
                        resultEnvelope.data.CustomData = callRequest.CustomData;
                        if (resultAction != null)
                            resultAction(resultEnvelope.data, callRequest);
                        PlayFabSettings.InvokeResponse(callRequest.UrlPath, callRequest.CallId, callRequest.Request, resultEnvelope.data, callRequest.Error, callRequest.CustomData); // Do the globalMessage callback
                        WrapCallback(resultCallback, resultEnvelope.data);
                        return resultEnvelope.data; // This is the expected output path for successful api call
                    }

                    // Successful HTTP interaction, but PlayFab server returned an error
                    callRequest.Error = new PlayFabError
                    {
                        HttpCode = resultEnvelope.code,
                        HttpStatus = resultEnvelope.status,
                        Error = (PlayFabErrorCode)resultEnvelope.errorCode.Value,
                        ErrorMessage = resultEnvelope.errorMessage,
                        ErrorDetails = resultEnvelope.errorDetails,
                        CustomData = callRequest.CustomData
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
                        ErrorDetails = null,
                        CustomData = callRequest.CustomData
                    };
                }
            }

            WrapCallback(PlayFabSettings.GlobalErrorHandler, callRequest.Error);
            WrapCallback(errorCallback, callRequest.Error);
            return null;
        }
        private static readonly object[] _invokeParams = new object[1];
        private static void WrapCallback(Delegate callback, object singleParam)
        {
            if (callback == null)
                return;

            _invokeParams[0] = singleParam;
            try
            {
                callback.DynamicInvoke(_invokeParams);
            }
            catch (Exception e)
            {
                if (!PlayFabSettings.HideCallbackErrors)
                    UnityEngine.Debug.LogException(e);
            }
        }
    }
}
