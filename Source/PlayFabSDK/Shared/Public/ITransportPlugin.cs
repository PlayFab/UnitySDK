using System;

namespace PlayFab
{
    /// <summary>
    /// Interface of any transport SDK plugin.
    /// This interface is meant to be more generic and free of assumptions specific to current PlayFab implementations (see IPlayFabTransportPlugin).
    /// While our ultimate goal is to have users implement this interface it will require some refactoring in PlayFabHTTP. As a temporary solution
    /// users can implement IPlayFabTransportPlugin if they want to use their own custom transport.
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
}