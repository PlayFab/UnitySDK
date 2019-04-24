#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.AuthenticationModels
{
    [Serializable]
    public class ActivateAPIKeyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the entity API key to activate.
        /// </summary>
        public string APIKeyId;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class ActivateAPIKeyResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class CreateAPIKeyDetails : PlayFabBaseModel
    {
        /// <summary>
        /// Whether the key is active for authentication. Inactive keys cannot be used to authenticate.Keys can be activated or
        /// deactivate using the ActivateKey and DeactivateKey APIs.Deactivating a key is a way to verify that the key is not in use
        /// before deleting it.
        /// </summary>
        public bool Active;
        /// <summary>
        /// Unique identifier for the entity API key. Set in the "X - EntityAPIKeyId" in authentication requests.
        /// </summary>
        public string APIKeyId;
        /// <summary>
        /// Secret used to authenticate requests with the key. Set in the "X - EntityAPIKeyId" in authentication requests.The secret
        /// value is returned only once in this response and cannot be retrieved afterward, either via API or in Game Manager.API
        /// key secrets should be stored securely only on trusted servers and never distributed in code or configuration to
        /// untrusted clients.
        /// </summary>
        public string APIKeySecret;
        /// <summary>
        /// The time the API key was generated, in UTC.
        /// </summary>
        public DateTime Created;
    }

    [Serializable]
    public class CreateAPIKeyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class CreateAPIKeyResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The entity id and type.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The created API key
        /// </summary>
        public CreateAPIKeyDetails Key;
    }

    [Serializable]
    public class DeactivateAPIKeyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the entity API key to activate.
        /// </summary>
        public string APIKeyId;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class DeactivateAPIKeyResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeleteAPIKeyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the entity API key to delete.
        /// </summary>
        public string APIKeyId;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class DeleteAPIKeyResponse : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Combined entity type and ID structure which uniquely identifies a single entity.
    /// </summary>
    [Serializable]
    public class EntityKey : PlayFabBaseModel
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

    [Serializable]
    public class GetAPIKeyDetails : PlayFabBaseModel
    {
        /// <summary>
        /// Whether the key is active for authentication. Inactive keys cannot be used to authenticate.Keys can be activated or
        /// deactivate using the SetAPIActivation API.Deactivating a key is a way to verify that the key is not in use be before
        /// deleting it.
        /// </summary>
        public bool Active;
        /// <summary>
        /// Unique identifier for the entity API key. Set in the "X - EntityAPIKeyId" in authentication requests.
        /// </summary>
        public string APIKeyId;
        /// <summary>
        /// The time the API key was generated, in UTC.
        /// </summary>
        public DateTime Created;
    }

    [Serializable]
    public class GetAPIKeysRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class GetAPIKeysResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The entity id and type.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The API keys associated with the given entity.
        /// </summary>
        public List<GetAPIKeyDetails> Keys;
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
