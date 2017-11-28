#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System;

namespace SignalR.Client._20.Hubs
{
    public class Hubservable : IObservable<object[]>
    {
        private readonly string m_eventName;
        private readonly HubProxy m_proxy;

        public Hubservable(HubProxy proxy, string eventName)
        {
            m_proxy = proxy;
            m_eventName = eventName;
        }

        public IDisposable Subscribe(IObserver<object[]> observer)
        {
            var _subscription = m_proxy.Subscribe(m_eventName);
            _subscription.Data += observer.OnNext;

            return new DisposableAction(() =>
            {
                _subscription.Data -= observer.OnNext;
            });
        }
    }
}

#endif