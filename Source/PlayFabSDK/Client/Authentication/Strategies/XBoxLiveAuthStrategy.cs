#if !DISABLE_PLAYFABCLIENT_API

using System;
using PlayFab.ClientModels;

namespace PlayFab.Authentication.Strategies
{
    internal sealed class XBoxLiveAuthStrategy : IAuthenticationStrategy
    {
        public AuthTypes AuthType
        {
            get { return AuthTypes.XBoxLive; }
        }

        public void Authenticate(PlayFabAuthService authService, Action<LoginResult> resultCallback, Action<PlayFabError> errorCallback, AuthKeys authKeys = null)
        {
            if (authKeys == null || string.IsNullOrEmpty(authKeys.AuthTicket))
            {
                authService.InvokeDisplayAuthentication();
                return;
            }

            PlayFabClientAPI.LoginWithXbox(new LoginWithXboxRequest
            {
                XboxToken = authKeys.AuthTicket,
                InfoRequestParameters = authService.InfoRequestParams,
                CreateAccount = true
            }, resultCallback, errorCallback);
        }

        public void Link(PlayFabAuthService authService, AuthKeys authKeys)
        {
            PlayFabClientAPI.LinkXboxAccount(new LinkXboxAccountRequest
            {
                XboxToken = authKeys.AuthTicket,
                AuthenticationContext = authService.AuthenticationContext,
                ForceLink = authService.ForceLink
            }, resultCallback =>
            {
                authService.InvokeLink(AuthTypes.XBoxLive);
            }, errorCallback =>
            {
                authService.InvokeLink(AuthTypes.XBoxLive, errorCallback);
            });
        }

        public void Unlink(PlayFabAuthService authService, AuthKeys authKeys)
        {
            PlayFabClientAPI.UnlinkXboxAccount(new UnlinkXboxAccountRequest
            {
                AuthenticationContext = authService.AuthenticationContext,
                XboxToken = authKeys.AuthTicket
            }, resultCallback =>
            {
                authService.InvokeUnlink(AuthTypes.XBoxLive);
            }, errorCallback =>
            {
                authService.InvokeUnlink(AuthTypes.XBoxLive, errorCallback);
            });
        }
    }
}

#endif
