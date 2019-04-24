using System;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// Interface of any transport SDK plugin.
    /// </summary>
    public interface ITransportPlugin: IPlayFabPlugin
    {
        bool IsInitialized { get; }
        void Initialize();

        // Mirroring MonoBehaviour - Relayed from PlayFabHTTP
        void Update();
        void OnDestroy();

        void SimpleGetCall(string fullUrl, Action<byte[]> successCallback, Action<string> errorCallback);
        void SimplePutCall(string fullUrl, byte[] payload, Action<byte[]> successCallback, Action<string> errorCallback);

        void SimplePostCall(string fullUrl, byte[] payload, Action<byte[]> successCallback, Action<string> errorCallback);

        void MakeApiCall(object reqContainer);

        int GetPendingMessages();
    }
    /// <summary>
    /// Interface of any OneDS transport SDK plugin.
    /// </summary>
    public interface IOneDSTransportPlugin : IPlayFabPlugin
    {
        void DoPost(object request, Dictionary<string, string> extraHeaders, Action<object> callback);
    }
}
