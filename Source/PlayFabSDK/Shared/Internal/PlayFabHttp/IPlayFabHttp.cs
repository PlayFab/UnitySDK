using System;
using PlayFab.SharedModels;

namespace PlayFab.Internal
{
    public interface IPlayFabHttp
    {
        string AuthKey { get; set; }
        string DevKey { get; set; }
        void InitializeHttp();
        void Update();

        void MakeApiCall<TRequest, TResult>(string api, string apiEndpoint, TRequest request,
            string authType,
            Action<TResult> resultCallback, Action<PlayFabError> errorCallback,
            object customData = null)
            where TRequest : PlayFabRequestCommon where TResult : PlayFabResultCommon;

        int GetPendingMessages();
    }
}
