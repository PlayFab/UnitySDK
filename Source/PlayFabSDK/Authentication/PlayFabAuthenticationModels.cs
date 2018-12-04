#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.AuthenticationModels
{
    /// <summary>
    /// Combined entity type and ID structure which uniquely identifies a single entity.
    /// </summary>
    [Serializable]
    public class EntityKey
    {
        /// <summary>
        /// Unique ID of the entity.
        /// </summary>
        public string Id;
        /// <summary>
        /// Entity type. See https://api.playfab.com/docs/tutorials/entities/entitytypes
        /// </summary>
        public string Type;
    }

    /// <summary>
    /// This API must be called with X-SecretKey, X-Authentication or X-EntityToken headers. An optional EntityKey may be
    /// included to attempt to set the resulting EntityToken to a specific entity, however the entity must be a relation of the
    /// caller, such as the master_player_account of a character. If sending X-EntityToken the account will be marked as freshly
    /// logged in and will issue a new token. If using X-Authentication or X-EntityToken the header must still be valid and
    /// cannot be expired or revoked.
    /// </summary>
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
