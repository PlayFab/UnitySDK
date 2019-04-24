#if !DISABLE_PLAYFABENTITY_API

using System;
using System.Collections.Generic;
using PlayFab.AuthenticationModels;
using PlayFab.Internal;
using PlayFab.SharedModels;

namespace PlayFab
{
    /// <summary>
    /// The Authentication APIs provide a convenient way to convert classic authentication responses into entity authentication
    /// models. These APIs will provide you with the entity authentication token needed for subsequent Entity API calls. Manage
    /// API keys for authenticating any entity.
    /// </summary>
    public class PlayFabAuthenticationInstanceAPI : IPlayFabInstanceApi
    {
        public PlayFabApiSettings apiSettings = null;
        private PlayFabAuthenticationContext authenticationContext = null;

        public PlayFabAuthenticationInstanceAPI() { }

        public PlayFabAuthenticationInstanceAPI(PlayFabApiSettings settings)
        {
            apiSettings = settings;
        }

        public PlayFabAuthenticationInstanceAPI(PlayFabAuthenticationContext context)
        {
            authenticationContext = context;
        }

        public PlayFabAuthenticationInstanceAPI(PlayFabApiSettings settings, PlayFabAuthenticationContext context)
        {
            apiSettings = settings;
            authenticationContext = context;
        }

        public void SetAuthenticationContext(PlayFabAuthenticationContext context)
        {
            authenticationContext = context;
        }

        public PlayFabAuthenticationContext GetAuthenticationContext()
        {
            return authenticationContext;
        }

        /// <summary>
        /// Check to See if the entity is logged in.
        /// </summary>
        public bool IsEntityLoggedIn()
        {
            return authenticationContext == null ? false : authenticationContext.IsEntityLoggedIn();
        }

        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public void ForgetAllCredentials()
        {
            if (authenticationContext != null)
            {
                authenticationContext.ForgetAllCredentials();
            }
        }

        /// <summary>
        /// Activates the given API key. Active keys may be used for authentication.
        /// </summary>
        public void ActivateKey(ActivateAPIKeyRequest request, Action<ActivateAPIKeyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? authenticationContext;
            PlayFabHttp.MakeApiCall("/APIKey/ActivateKey", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, apiSettings, this);
        }

        /// <summary>
        /// Creates an API key for the given entity.
        /// </summary>
        public void CreateKey(CreateAPIKeyRequest request, Action<CreateAPIKeyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? authenticationContext;
            PlayFabHttp.MakeApiCall("/APIKey/CreateKey", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, apiSettings, this);
        }

        /// <summary>
        /// Deactivates the given API key, causing subsequent authentication attempts with it to fail.Deactivating a key is a way to
        /// verify that the key is not in use before deleting it.
        /// </summary>
        public void DeactivateKey(DeactivateAPIKeyRequest request, Action<DeactivateAPIKeyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? authenticationContext;
            PlayFabHttp.MakeApiCall("/APIKey/DeactivateKey", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, apiSettings, this);
        }

        /// <summary>
        /// Deletes the given API key.
        /// </summary>
        public void DeleteKey(DeleteAPIKeyRequest request, Action<DeleteAPIKeyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? authenticationContext;
            PlayFabHttp.MakeApiCall("/APIKey/DeleteKey", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, apiSettings, this);
        }

        /// <summary>
        /// Method to exchange a legacy AuthenticationTicket or title SecretKey for an Entity Token or to refresh a still valid
        /// Entity Token.
        /// </summary>
        public void GetEntityToken(GetEntityTokenRequest request, Action<GetEntityTokenResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? authenticationContext;
            AuthType authType = AuthType.None;
#if !DISABLE_PLAYFABCLIENT_API
            if (context.ClientSessionTicket != null) { authType = AuthType.LoginSession; }
#endif
#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API
            if (PlayFabSettings.staticSettings.DeveloperSecretKey != null) { authType = AuthType.DevSecretKey; } // TODO: Need to get the correct settings first
#endif
#if !DISABLE_PLAYFABENTITY_API
            if (context.EntityToken != null) { authType = AuthType.EntityToken; }
#endif
            PlayFabHttp.MakeApiCall("/Authentication/GetEntityToken", request, authType, resultCallback, errorCallback, customData, extraHeaders, context, apiSettings, this);
        }

        /// <summary>
        /// Gets the API keys associated with the given entity.
        /// </summary>
        public void GetKeys(GetAPIKeysRequest request, Action<GetAPIKeysResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? authenticationContext;
            PlayFabHttp.MakeApiCall("/APIKey/GetKeys", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, apiSettings, this);
        }

    }
}

#endif
