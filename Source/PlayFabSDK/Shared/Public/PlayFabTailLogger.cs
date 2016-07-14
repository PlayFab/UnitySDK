using UnityEngine;
using System.Collections;
using System.Net;

namespace PlayFab
{
    public interface IPlayFabTailLogger
    {
        IPAddress ip { get; set; }
        int port { get; set; }
        string url { get; set; }

        void Open();
        void Close();
        void Log(string message);
    }
}