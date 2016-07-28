using System;
using System.Collections.Generic;

namespace PlayFab.Internal
{
    public interface IPlayFabSignalR
    {
        string Uri { get; set; }
        string Controller { get; set; }
        Dictionary<string, string> QueryString { get; set; }

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

