#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
namespace SignalR.Client._20.Transports
{
    internal class CancellationTokenSource
    {
        public bool IsCancellationRequested { get; private set; }

        public void Cancel()
        {
            IsCancellationRequested = true;
        }
    }
}

#endif