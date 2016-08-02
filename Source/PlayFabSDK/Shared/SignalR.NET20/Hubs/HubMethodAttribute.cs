#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System;

namespace SignalR.Client._20.Hubs
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class HubMethodAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        private readonly string m_method;

        // This is a positional argument
        public HubMethodAttribute(string method)
        {
            m_method = method;
        }

        public string Method
        {
            get { return m_method; }
        }
    }
}

#endif