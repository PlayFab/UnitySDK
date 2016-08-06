#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
namespace SignalR.Client._20.Hubs
{
    public interface IObserver<T>
    {
        void OnNext(T value);
    }
}

#endif