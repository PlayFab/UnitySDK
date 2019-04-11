#if !DISABLE_PLAYFABCLIENT_API

using System;
using PlayFab.ClientModels;

namespace PlayFab.Authentication.Strategies
{
    internal sealed class GooglePlayGamesAuthStrategy : IAuthenticationStrategy
    {
        public AuthTypes AuthType
        {
            get { return AuthTypes.GooglePlayGames; }
        }

        public void Authenticate(PlayFabAuthService authService, Action<LoginResult> resultCallback, Action<PlayFabError> errorCallback, AuthKeys authKeys)
        {
            if (authKeys == null || string.IsNullOrEmpty(authKeys.AuthTicket))
            {
                authService.InvokeDisplayAuthentication();
                return;
            }

            PlayFabClientAPI.LoginWithGoogleAccount(new LoginWithGoogleAccountRequest
            {
                ServerAuthCode = authKeys.AuthTicket,
                InfoRequestParameters = authService.InfoRequestParams,
                CreateAccount = true
            }, resultCallback, errorCallback);
        }

        public void Link(PlayFabAuthService authService, AuthKeys authKeys)
        {
            PlayFabClientAPI.LinkGoogleAccount(new LinkGoogleAccountRequest
            {
                ServerAuthCode = authKeys.AuthTicket,
                AuthenticationContext = authService.AuthenticationContext,
                ForceLink = authService.ForceLink
            }, resultCallback =>
            {
                authService.InvokeLink(AuthTypes.GooglePlayGames);
            }, errorCallback =>
            {
                authService.InvokeLink(AuthTypes.GooglePlayGames, errorCallback);
            });
        }

        public void Unlink(PlayFabAuthService authService, AuthKeys authKeys)
        {
            PlayFabClientAPI.UnlinkGoogleAccount(new UnlinkGoogleAccountRequest
            {
                AuthenticationContext = authService.AuthenticationContext,
            }, resultCallback =>
            {
                authService.InvokeUnlink(AuthTypes.GooglePlayGames);
            }, errorCallback =>
            {
                authService.InvokeUnlink(AuthTypes.GooglePlayGames, errorCallback);
            });
        }
    }
}

#endif
