using System;

namespace PlayFab.Internal
{

    public interface IPlayFabHttp
    {
        string AuthKey { get; set; }
        string DevKey { get; set; }
        void Awake();
        void Update();

        void MakeApiCall<TRequestType, TResultType>(string api, string apiEndpoint, TRequestType request,
            string authType,
            Action<TResultType> resultCallback, Action<PlayFabError> errorCallback, object customData = null);

        int GetPendingMessages();

    }
}