#if !DISABLE_PLAYFABCLIENT_API

using System;
using PlayFab.ClientModels;

namespace PlayFab.Authentication.Strategies
{
    internal sealed class WindowsHelloAuthStrategy : IAuthenticationStrategy
    {
        public AuthTypes AuthType
        {
            get { return AuthTypes.WindowsHello; }
        }

        public void Authenticate(PlayFabAuthService authService, Action<LoginResult> resultCallback, Action<PlayFabError> errorCallback, AuthKeys authKeys = null)
        {
            if (authKeys == null || string.IsNullOrEmpty(authKeys.WindowsHelloPublicKeyHint) || string.IsNullOrEmpty(authKeys.WindowsHelloChallengeSignature))
            {
                authService.InvokeDisplayAuthentication();
                return;
            }

            PlayFabClientAPI.LoginWithWindowsHello(new LoginWithWindowsHelloRequest
            {
                ChallengeSignature = authKeys.WindowsHelloChallengeSignature,
                PublicKeyHint = authKeys.WindowsHelloPublicKeyHint,
                InfoRequestParameters = authService.InfoRequestParams
            }, resultCallback, errorCallback);
        }

        public void Link(PlayFabAuthService authService, AuthKeys authKeys)
        {
            PlayFabClientAPI.LinkWindowsHello(new LinkWindowsHelloAccountRequest
            {
                PublicKey = authKeys.AuthTicket,
                AuthenticationContext = authService.AuthenticationContext,
                ForceLink = authService.ForceLink,
                UserName = authService.Username
            }, resultCallback =>
            {
                authService.InvokeLink(AuthTypes.WindowsHello);
            }, errorCallback =>
            {
                authService.InvokeLink(AuthTypes.WindowsHello, errorCallback);
            });
        }

        public void Unlink(PlayFabAuthService authService, AuthKeys authKeys)
        {
            PlayFabClientAPI.UnlinkWindowsHello(new UnlinkWindowsHelloAccountRequest
            {
                AuthenticationContext = authService.AuthenticationContext,
                PublicKeyHint = authKeys.AuthTicket
            }, resultCallback =>
            {
                authService.InvokeUnlink(AuthTypes.WindowsHello);
            }, errorCallback =>
            {
                authService.InvokeUnlink(AuthTypes.WindowsHello, errorCallback);
            });
        }
    }
}

#endif
