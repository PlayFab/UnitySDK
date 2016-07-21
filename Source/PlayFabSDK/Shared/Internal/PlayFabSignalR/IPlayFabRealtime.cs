using System;

namespace PlayFab.Internal
{
    public interface IPlayFabRealtime
    {
        string AuthToken { get; set; }

        void Start();
        void Update();
        void Close();

        event Action OnConnected;
        event Action OnDisconnected;

        void Invoke<TResult>(string api, Action<TResult> resultCallback, params object[] args);

        void Subscribe(string onInvoked, Action<object[]> resultCallback);
        
    }
    
}
