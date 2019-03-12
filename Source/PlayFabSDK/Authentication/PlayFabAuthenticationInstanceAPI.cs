#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.AuthenticationModels;
using PlayFab.Internal;
using PlayFab.Json;
using PlayFab.Public;

namespace PlayFab
{
    /// <summary>
    /// The Authentication APIs provide a convenient way to convert classic authentication responses into entity authentication
    /// models. These APIs will provide you with the entity authentication token needed for subsequent Entity API calls.
    /// </summary>
    public class PlayFabAuthenticationInstanceAPI
    {
        public PlayFabApiSettings ApiSettings = null;
        private PlayFabAuthenticationContext authenticationContext = null;

        public PlayFabAuthenticationInstanceAPI() {}

        public PlayFabAuthenticationInstanceAPI(PlayFabApiSettings settings) 
        {
            ApiSettings = settings;
        }

        public PlayFabAuthenticationInstanceAPI(PlayFabAuthenticationContext context) 
        {
            authenticationContext = context;
        }

        public PlayFabAuthenticationInstanceAPI(PlayFabApiSettings settings, PlayFabAuthenticationContext context) 
        {
            ApiSettings = settings;
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
            if(authenticationContext != null)
            {
                authenticationContext.ForgetAllCredentials();
            }
        }

        /// <summary>
        /// Method to exchange a legacy AuthenticationTicket or title SecretKey for an Entity Token or to refresh a still valid
        /// Entity Token.
        /// </summary>

        public void GetEntityToken(GetEntityTokenRequest request, Action<GetEntityTokenResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            AuthType authType = AuthType.None;
#if !DISABLE_PLAYFABCLIENT_API
            string clientSessionTicket = null;
            if (request.AuthenticationContext != null && !string.IsNullOrEmpty(request.AuthenticationContext.ClientSessionTicket))
                clientSessionTicket = request.AuthenticationContext.ClientSessionTicket;
            if (clientSessionTicket == null && authenticationContext != null && !string.IsNullOrEmpty(authenticationContext.ClientSessionTicket))
                clientSessionTicket = authenticationContext.ClientSessionTicket;
            if (clientSessionTicket == null)
                clientSessionTicket = PluginManager.GetPlugin<IPlayFabTransportPlugin>(PluginContract.PlayFab_Transport).AuthKey;
            if (authType == AuthType.None && !string.IsNullOrEmpty(clientSessionTicket))
                authType = AuthType.LoginSession;
#endif
#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API || UNITY_EDITOR
            string developerSecretKey = null;
            if (request.AuthenticationContext != null && !string.IsNullOrEmpty(request.AuthenticationContext.DeveloperSecretKey))
                developerSecretKey = request.AuthenticationContext.DeveloperSecretKey;
            if (developerSecretKey == null && authenticationContext != null && !string.IsNullOrEmpty(authenticationContext.DeveloperSecretKey))
                developerSecretKey = authenticationContext.DeveloperSecretKey;
            if (developerSecretKey == null)
                developerSecretKey = PlayFabSettings.DeveloperSecretKey;
            if (authType == AuthType.None && !string.IsNullOrEmpty(developerSecretKey))
                authType = AuthType.DevSecretKey;
#endif
            PlayFabHttp.MakeApiCall("/Authentication/GetEntityToken", request, authType, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 

    }
}
#endif
