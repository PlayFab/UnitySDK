#if !DISABLE_PLAYFABCLIENT_API

using System;
using PlayFab.ClientModels;

namespace PlayFab.Authentication.Strategies
{
    internal sealed class UsernamePasswordAuthStrategy : IAuthenticationStrategy
    {
        public AuthTypes AuthType
        {
            get { return AuthTypes.UsernamePassword; }
        }

        public void Authenticate(PlayFabAuthService authService, Action<LoginResult> resultCallback, Action<PlayFabError> errorCallback, AuthKeys authKeys)
        {
            if (string.IsNullOrEmpty(authService.Username) || string.IsNullOrEmpty(authService.Password) || string.IsNullOrEmpty(authService.Email))
            {
                authService.InvokeDisplayAuthentication();
                return;
            }

            PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
            {
                InfoRequestParameters = authService.InfoRequestParams,
                Password = authService.Password,
                Username = authService.Username,
                TitleId = PlayFabSettings.TitleId
            },
            resultCallback,
            error =>
            {
                // If user not registered, create one.
                // Do it because LoginWithPlayFabRequest does not contains "CreateAccount" option.
                if (error.Error == PlayFabErrorCode.AccountNotFound)
                {
                    UnityEngine.Debug.LogWarning("Authentication failed. Try to register account.");
                    PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
                    {
                        Username = authService.Username,
                        Password = authService.Password,
                        Email = authService.Email,
                        InfoRequestParameters = authService.InfoRequestParams,
                        TitleId = PlayFabSettings.TitleId
                    },
                    (registerSuccess) =>
                    {
                        // convert RegisterResult to LoginResult
                        resultCallback.Invoke(new LoginResult
                        {
                            AuthenticationContext = registerSuccess.AuthenticationContext,
                            EntityToken = registerSuccess.EntityToken,
                            CustomData = registerSuccess.CustomData,
                            NewlyCreated = true,
                            PlayFabId = registerSuccess.PlayFabId,
                            SessionTicket = registerSuccess.SessionTicket,
                            SettingsForUser = registerSuccess.SettingsForUser,
                            Request = registerSuccess.Request,
                            LastLoginTime = DateTime.UtcNow
                        });
                    }, errorCallback);
                }
                // otherwise return error
                else errorCallback.Invoke(error);
            });
        }

        public void Link(PlayFabAuthService authService, AuthKeys authKeys)
        {
            throw new NotSupportedException();
        }

        public void Unlink(PlayFabAuthService authService, AuthKeys authKeys)
        {
            throw new NotSupportedException();
        }
    }
}

#endif
