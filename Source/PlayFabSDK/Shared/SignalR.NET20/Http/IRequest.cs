#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System.Net;

namespace SignalR.Client._20.Http
{
    public interface IRequest
    {
        string UserAgent { get; set; }

        ICredentials Credentials { get; set; }

        CookieContainer CookieContainer { get; set; }

        string Accept { get; set; }

        void Abort();
    }
}

#endif