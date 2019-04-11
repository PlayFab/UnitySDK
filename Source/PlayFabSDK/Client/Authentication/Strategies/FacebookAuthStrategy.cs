#if !DISABLE_PLAYFABCLIENT_API

using System;
using PlayFab.ClientModels;

namespace PlayFab.Authentication.Strategies
{
    internal sealed class FacebookAuthStrategy : IAuthenticationStrategy
    {
        public AuthTypes AuthType
        {
            get { return AuthTypes.Facebook; }
        }

        public void Authenticate(PlayFabAuthService authService, Action<LoginResult> resultCallback, Action<PlayFabError> errorCallback, AuthKeys authKeys)
        {
            if (authKeys == null || string.IsNullOrEmpty(authKeys.AuthTicket))
            {
                authService.InvokeDisplayAuthentication();
                return;
            }

            PlayFabClientAPI.LoginWithFacebook(new LoginWithFacebookRequest
            {
                AccessToken = authKeys.AuthTicket,
                InfoRequestParameters = authService.InfoRequestParams,
                CreateAccount = true
            }, resultCallback, errorCallback);
        }

        public void Link(PlayFabAuthService authService, AuthKeys authKeys)
        {
            PlayFabClientAPI.LinkFacebookAccount(new LinkFacebookAccountRequest
            {
                AccessToken = authKeys.AuthTicket,
                AuthenticationContext = authService.AuthenticationContext,
                ForceLink = authService.ForceLink
            }, resultCallback =>
            {
                authService.InvokeLink(AuthTypes.Facebook);
            }, errorCallback =>
            {
                authService.InvokeLink(AuthTypes.Facebook, errorCallback);
            });
        }

        public void Unlink(PlayFabAuthService authService, AuthKeys authKeys)
        {
            PlayFabClientAPI.UnlinkFacebookAccount(new UnlinkFacebookAccountRequest
            {
                AuthenticationContext = authService.AuthenticationContext,
            }, resultCallback =>
            {
                authService.InvokeUnlink(AuthTypes.Facebook);
            }, errorCallback =>
            {
                authService.InvokeUnlink(AuthTypes.Facebook, errorCallback);
            });
        }
    }
}

#endif
