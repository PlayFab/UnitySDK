#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System;

namespace SignalR.Client._20
{
    internal class DisposableAction : IDisposable
    {
        private readonly Action m_action;

        public DisposableAction(System.Action action)
        {
            m_action = action;
        }

        public void Dispose()
        {
            m_action();
        }
    }
}

#endif