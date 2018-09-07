namespace PlayFab.Internal
{
    public interface IPlayFabSignalR
    {
        event System.Action<string> OnReceived;
        event System.Action OnReconnected;
        event System.Action OnDisconnected;
        event System.Action<System.Exception> OnError;

        void Start(string url, string hubName);
        void Stop();

        void Update();

        void Invoke(string api, System.Action resultCallback, params object[] args);
        void Subscribe(string onInvoked, System.Action<object[]> resultCallback);
    }
}
