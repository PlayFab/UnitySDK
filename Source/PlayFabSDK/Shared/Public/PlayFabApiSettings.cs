using System.Collections.Generic;
using System.Text;

namespace PlayFab
{
    public class PlayFabApiSettings
    {
        public readonly Dictionary<string, string> RequestGetParams = new Dictionary<string, string> {
            { "sdk", PlayFabSettings.VersionString }
        };

        /// <summary> This is only for customers running a private cluster.  Generally you shouldn't touch this </summary>
        public string ProductionEnvironmentUrl = "playfabapi.com";
        /// <summary> The name of a customer vertical. This is only for customers running a private cluster.  Generally you shouldn't touch this </summary>
        public string VerticalName = null;
        /// <summary> Session token for Entity API. Auto-Populated by GetEntityToken method. </summary>
        internal string EntityToken = null;
        /// <summary> Session ticket for Client API. Auto-Populated by any login or registration call. </summary>
        internal string ClientSessionTicket = null;
        /// <summary> You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website) </summary>
        public string DeveloperSecretKey = null;
        /// <summary> You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website) </summary>
        public string TitleId;

        public virtual string GetFullUrl(string apiCall, Dictionary<string, string> getParams)
        {
            return PlayFabSettings.GetFullUrl(apiCall, getParams, this);
        }
    }
}
