#if ENABLE_PLAYFABSERVER_API
using System;
using System.Collections.Generic;
using PlayFab.MatchmakerModels;
using PlayFab.Internal;
using PlayFab.Json;
using PlayFab.Public;

namespace PlayFab
{
    /// <summary>
    /// Enables the use of an external match-making service in conjunction with PlayFab hosted Game Server instances
    /// </summary>
    public class PlayFabMatchmakerInstanceAPI
    {
        public PlayFabApiSettings ApiSettings = null;
        private PlayFabAuthenticationContext authenticationContext = null;

        public PlayFabMatchmakerInstanceAPI() {}

        public PlayFabMatchmakerInstanceAPI(PlayFabApiSettings settings) 
        {
            ApiSettings = settings;
        }

        public PlayFabMatchmakerInstanceAPI(PlayFabAuthenticationContext context) 
        {
            authenticationContext = context;
        }

        public PlayFabMatchmakerInstanceAPI(PlayFabApiSettings settings, PlayFabAuthenticationContext context) 
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
        /// Validates a user with the PlayFab service
        /// </summary>

        public void AuthUser(AuthUserRequest request, Action<AuthUserResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Matchmaker/AuthUser", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Informs the PlayFab game server hosting service that the indicated user has joined the Game Server Instance specified
        /// </summary>

        public void PlayerJoined(PlayerJoinedRequest request, Action<PlayerJoinedResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Matchmaker/PlayerJoined", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Informs the PlayFab game server hosting service that the indicated user has left the Game Server Instance specified
        /// </summary>

        public void PlayerLeft(PlayerLeftRequest request, Action<PlayerLeftResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Matchmaker/PlayerLeft", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Instructs the PlayFab game server hosting service to instantiate a new Game Server Instance
        /// </summary>

        public void StartGame(StartGameRequest request, Action<StartGameResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Matchmaker/StartGame", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Retrieves the relevant details for a specified user, which the external match-making service can then use to compute
        /// effective matches
        /// </summary>

        public void UserInfo(UserInfoRequest request, Action<UserInfoResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Matchmaker/UserInfo", request, AuthType.DevSecretKey, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 

    }
}
#endif
