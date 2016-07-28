﻿using System.Net;
using SignalR.Client._20.Infrastructure;

namespace SignalR.Client._20.Http
{
    public class HttpWebRequestWrapper : IRequest
    {
        private readonly HttpWebRequest m_request;

        public HttpWebRequestWrapper(HttpWebRequest request)
        {
            m_request = request;
        }

        public string UserAgent
        {
            get
            {
                return m_request.UserAgent;
            }
            set
            {
                m_request.UserAgent = value;
            }
        }

        public ICredentials Credentials
        {
            get
            {
                return m_request.Credentials;
            }
            set
            {
                m_request.Credentials = value;
            }
        }

        public CookieContainer CookieContainer
        {
            get
            {
                return m_request.CookieContainer;
            }
            set
            {
                m_request.CookieContainer = value;
            }
        }

        public string Accept
        {
            get
            {
                return m_request.Accept;
            }
            set
            {
                m_request.Accept = value;
            }
        }

        public void Abort()
        {
            m_request.Abort();
        }
    }
}
