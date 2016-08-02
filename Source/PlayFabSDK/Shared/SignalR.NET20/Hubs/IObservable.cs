#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System;

namespace SignalR.Client._20.Hubs
{
    public interface IObservable<T>
    {
        IDisposable Subscribe(IObserver<T> observer);
    }
}

#endif