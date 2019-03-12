namespace PlayFab
{
    public sealed class PlayFabAuthenticationContext
    {
#if !DISABLE_PLAYFABCLIENT_API
        public string ClientSessionTicket;
#endif

#if !DISABLE_PLAYFABENTITY_API
        public string EntityToken;
#endif

#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API || UNITY_EDITOR
        public string DeveloperSecretKey;
#endif
        public string PlayFabId;
            
        public PlayFabAuthenticationContext() 
        {        
#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API
            DeveloperSecretKey = PlayFabSettings.DeveloperSecretKey;
#endif
        }

        public PlayFabAuthenticationContext(string clientSessionTicket, string entityToken, string playFabId) : this()
        {
#if !DISABLE_PLAYFABCLIENT_API
            ClientSessionTicket = clientSessionTicket;
#endif
#if !DISABLE_PLAYFABENTITY_API
            EntityToken = entityToken;
#endif
            PlayFabId = playFabId;
        }

#if !DISABLE_PLAYFABCLIENT_API
        public bool IsClientLoggedIn()
        {
            return !string.IsNullOrEmpty(ClientSessionTicket);
        }
#endif

#if !DISABLE_PLAYFABENTITY_API
        public bool IsEntityLoggedIn()
        {
            return !string.IsNullOrEmpty(EntityToken);
        }
#endif

        public void ForgetAllCredentials()
        {
            ClientSessionTicket = null;
            EntityToken = null;       
        }
    }
}
