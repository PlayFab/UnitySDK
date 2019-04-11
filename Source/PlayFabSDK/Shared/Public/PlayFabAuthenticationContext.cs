namespace PlayFab
{
    public sealed class PlayFabAuthenticationContext
    {
        public string PlayFabId;

        public PlayFabAuthenticationContext()
        {
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
        public string ClientSessionTicket;
        public bool IsClientLoggedIn()
        {
            return !string.IsNullOrEmpty(ClientSessionTicket);
        }
#endif

#if !DISABLE_PLAYFABENTITY_API
        public string EntityToken;
        public bool IsEntityLoggedIn()
        {
            return !string.IsNullOrEmpty(EntityToken);
        }
#endif

        public void ForgetAllCredentials()
        {
#if !DISABLE_PLAYFABCLIENT_API
            ClientSessionTicket = null;
#endif
#if !DISABLE_PLAYFABENTITY_API
            EntityToken = null;
#endif
        }
    }
}
