#if !DISABLE_PLAYFABCLIENT_API

using System;
using PlayFab.ClientModels;

namespace PlayFab.Authentication.Strategies
{
    internal sealed class OpenIdAuthStrategy : IAuthenticationStrategy
    {
        public AuthTypes AuthType
        {
            get { return AuthTypes.OpenId; }
        }

        public void Authenticate(PlayFabAuthService authService, Action<LoginResult> resultCallback, Action<PlayFabError> errorCallback, AuthKeys authKeys)
        {
            if (authKeys == null || string.IsNullOrEmpty(authKeys.AuthTicket) || string.IsNullOrEmpty(authKeys.OpenIdConnectionId))
            {
                authService.InvokeDisplayAuthentication();
                return;
            }

            PlayFabClientAPI.LoginWithOpenIdConnect(new LoginWithOpenIdConnectRequest
            {
                ConnectionId = authKeys.OpenIdConnectionId,
                IdToken = authKeys.AuthTicket,
                InfoRequestParameters = authService.InfoRequestParams,
                CreateAccount = true
            }, resultCallback, errorCallback);
        }

        public void Link(PlayFabAuthService authService, AuthKeys authKeys)
        {
            PlayFabClientAPI.LinkOpenIdConnect(new LinkOpenIdConnectRequest
            {
                IdToken = authKeys.AuthTicket,
                ConnectionId = authKeys.OpenIdConnectionId,
                AuthenticationContext = authService.AuthenticationContext,
                ForceLink = authService.ForceLink
            }, resultCallback =>
            {
                authService.InvokeLink(AuthTypes.OpenId);
            }, errorCallback =>
            {
                authService.InvokeLink(AuthTypes.OpenId, errorCallback);
            });
        }

        public void Unlink(PlayFabAuthService authService, AuthKeys authKeys)
        {
            PlayFabClientAPI.UnlinkOpenIdConnect(new UninkOpenIdConnectRequest
            {
                AuthenticationContext = authService.AuthenticationContext,
                ConnectionId = authKeys.OpenIdConnectionId
            }, resultCallback =>
            {
                authService.InvokeUnlink(AuthTypes.OpenId);
            }, errorCallback =>
            {
                authService.InvokeUnlink(AuthTypes.OpenId, errorCallback);
            });
        }
    }
}

#endif
