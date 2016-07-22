#if ENABLE_PLAYSTREAM_REALTIME

using System;

namespace PlayFab.Internal
{
    public interface IPlayFabRealtime
    {
        string AuthToken { get; set; }
        string Uri { get; set; }
        string Controller { get; set; }

        void Start();
        void Update();
        void Close();

        event Action OnConnected;
        event Action<string> OnReceived;
        event Action OnReconnected;
        event Action OnDisconnected;
        event Action<Exception> OnError;
        
        void Invoke<TResult>(string api, Action<TResult> resultCallback, params object[] args);

        void Subscribe(string onInvoked, Action<object[]> resultCallback);

    }

}

#endif
