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

        void MakeApiCall<TRequest, TResult>(string apiEndpoint, TRequest request,
            AuthType authType,
            Action<TResult> resultCallback, Action<PlayFabError> errorCallback,
            object customData = null)
            where TRequest : PlayFabRequestCommon where TResult : PlayFabResultCommon;

        int GetPendingMessages();
    }

    public enum AuthType
    {
        None,
        PreLoginSession, // Not yet defined
        LoginSession, // "X-Authorization"
        DevSecretKey, // "X-SecretKey"
    }
}
