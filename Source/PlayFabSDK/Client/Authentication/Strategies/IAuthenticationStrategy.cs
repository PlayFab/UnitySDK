#if !DISABLE_PLAYFABCLIENT_API

using System;
using PlayFab.ClientModels;

namespace PlayFab.Authentication.Strategies
{
    public interface IAuthenticationStrategy
    {
        AuthTypes AuthType { get; }

        void Authenticate(PlayFabAuthService authService, Action<LoginResult> resultCallback, Action<PlayFabError> errorCallback, AuthKeys authKeys);
        void Link(PlayFabAuthService authService, AuthKeys authKeys);
        void Unlink(PlayFabAuthService authService, AuthKeys authKeys);
    }
}

#endif
