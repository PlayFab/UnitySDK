#if !DISABLE_PLAYFABCLIENT_API

using System;
using PlayFab.ClientModels;

namespace PlayFab.Authentication.Strategies
{
    internal sealed class GameCenterAuthStrategy : IAuthenticationStrategy
    {
        public AuthTypes AuthType
        {
            get { return AuthTypes.GameCenter; }
        }

        public void Authenticate(PlayFabAuthService authService, Action<LoginResult> resultCallback, Action<PlayFabError> errorCallback, AuthKeys authKeys)
        {
            if (authKeys == null || string.IsNullOrEmpty(authKeys.AuthTicket))
            {
                authService.InvokeDisplayAuthentication();
                return;
            }

            PlayFabClientAPI.LoginWithGameCenter(new LoginWithGameCenterRequest
            {
                Signature = authKeys.AuthTicket,
                InfoRequestParameters = authService.InfoRequestParams,
                CreateAccount = true
            }, resultCallback, errorCallback);
        }

        public void Link(PlayFabAuthService authService, AuthKeys authKeys)
        {
            PlayFabClientAPI.LinkGameCenterAccount(new LinkGameCenterAccountRequest
            {
                GameCenterId = authKeys.AuthTicket,
                AuthenticationContext = authService.AuthenticationContext,
                ForceLink = authService.ForceLink
            }, resultCallback =>
            {
                authService.InvokeLink(AuthTypes.GameCenter);
            }, errorCallback =>
            {
                authService.InvokeLink(AuthTypes.GameCenter, errorCallback);
            });
        }

        public void Unlink(PlayFabAuthService authService, AuthKeys authKeys)
        {
            PlayFabClientAPI.UnlinkGameCenterAccount(new UnlinkGameCenterAccountRequest
            {
                AuthenticationContext = authService.AuthenticationContext,
            }, resultCallback =>
            {
                authService.InvokeUnlink(AuthTypes.GameCenter);
            }, errorCallback =>
            {
                authService.InvokeUnlink(AuthTypes.GameCenter, errorCallback);
            });
        }
    }
}

#endif
