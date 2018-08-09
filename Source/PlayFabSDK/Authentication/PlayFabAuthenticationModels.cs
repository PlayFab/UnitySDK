#if ENABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.AuthenticationModels
{
    /// <summary>
    /// Entity identifier class that contains both the ID and type.
    /// </summary>
    [Serializable]
    public class EntityKey
    {
        /// <summary>
        /// Entity profile ID.
        /// </summary>
        public string Id;
        /// <summary>
        /// Entity type. Optional to be used but one of EntityType or EntityTypeString must be set.
        /// </summary>
        public EntityTypes? Type;
        /// <summary>
        /// Entity type. Optional to be used but one of EntityType or EntityTypeString must be set.
        /// </summary>
        public string TypeString;
    }

    public enum EntityTypes
    {
        title,
        master_player_account,
        title_player_account,
        character,
        group,
        service
    }

    [Serializable]
    public class GetEntityTokenRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class GetEntityTokenResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The entity id and type.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The token used to set X-EntityToken for all entity based API calls.
        /// </summary>
        public string EntityToken;
        /// <summary>
        /// The time the token will expire, if it is an expiring token, in UTC.
        /// </summary>
        public DateTime? TokenExpiration;
    }
}
#endif
