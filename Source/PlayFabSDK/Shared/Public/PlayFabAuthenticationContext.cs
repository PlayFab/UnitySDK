namespace PlayFab
{
    public sealed class PlayFabAuthenticationContext
    {
        public PlayFabAuthenticationContext()
        {
        }

        public PlayFabAuthenticationContext(string clientSessionTicket, string entityToken, string playFabId, string entityId, string entityType) : this()
        {
#if !DISABLE_PLAYFABCLIENT_API
            ClientSessionTicket = clientSessionTicket;
            PlayFabId = playFabId;
#endif
#if !DISABLE_PLAYFABENTITY_API
            EntityToken = entityToken;
            EntityId = entityId;
            EntityType = entityType;
#endif
        }

        public void CopyFrom(PlayFabAuthenticationContext other)
        {
#if !DISABLE_PLAYFABCLIENT_API
            ClientSessionTicket = other.ClientSessionTicket;
            PlayFabId = other.PlayFabId;
#endif
#if !DISABLE_PLAYFABENTITY_API
            EntityToken = other.EntityToken;
            EntityId = other.EntityId;
            EntityType = other.EntityType;
#endif
        }

#if !DISABLE_PLAYFABCLIENT_API
        /// <summary> Allows access to the ClientAPI </summary>
        public string ClientSessionTicket;
        /// <summary> The master player entity Id </summary>
        public string PlayFabId;
        public bool IsClientLoggedIn()
        {
            return !string.IsNullOrEmpty(ClientSessionTicket);
        }
#endif

#if !DISABLE_PLAYFABENTITY_API
        /// <summary> Allows access to most Entity APIs </summary>
        public string EntityToken;
        /// <summary>
        /// Clients: The title player entity Id (unless replaced with a related entity)
        /// Servers: The title id (unless replaced with a related entity)
        /// </summary>
        public string EntityId;
        /// <summary>
        /// Describes the type of entity identified by EntityId
        /// </summary>
        public string EntityType;
        public bool IsEntityLoggedIn()
        {
            return !string.IsNullOrEmpty(EntityToken);
        }
#endif

        public void ForgetAllCredentials()
        {
#if !DISABLE_PLAYFABCLIENT_API
            PlayFabId = null;
            ClientSessionTicket = null;
#endif
#if !DISABLE_PLAYFABENTITY_API
            EntityToken = null;
            EntityId = null;
            EntityType = null;
#endif
        }
    }
}
