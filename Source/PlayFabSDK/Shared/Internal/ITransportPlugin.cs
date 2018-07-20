using System;

namespace PlayFab.Internal
{
    /// <summary>
    /// Interface of any transport SDK plugin.
    /// </summary>
    public interface ITransportPlugin: IPlayFabPlugin
    {
        bool SessionStarted { get; set; }
        string AuthKey { get; set; }
        string EntityToken { get; set; }
        void InitializeHttp();

        // Mirroring MonoBehaviour - Relayed from PlayFabHTTP
        void Update();
        void OnDestroy();

        void SimpleGetCall(string fullUrl, Action<byte[]> successCallback, Action<string> errorCallback);
        void SimplePutCall(string fullUrl, byte[] payload, Action successCallback, Action<string> errorCallback);
        void MakeApiCall(CallRequestContainer reqContainer);

        int GetPendingMessages();
    }
}