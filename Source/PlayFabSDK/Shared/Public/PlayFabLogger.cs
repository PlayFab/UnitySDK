using System.Net;

namespace PlayFab
{
    public class PlayFabLogger : IPlayFabTailLogger
    {
        public IPAddress ip { get; set; }
        public int port { get; set; }
        public string url { get; set; }

        public PlayFabLogger(string url, int port)
        {

        }

        public void Open()
        {
            
        }

        public void Close()
        {
            
        }

        public void Log(string message)
        {
            
        }
    }
}
