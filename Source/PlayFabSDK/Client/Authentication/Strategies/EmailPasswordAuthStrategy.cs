#if !DISABLE_PLAYFABCLIENT_API

using System;
using PlayFab.ClientModels;

namespace PlayFab.Authentication.Strategies
{
    internal sealed class EmailPasswordAuthStrategy : IAuthenticationStrategy
    {
        public AuthTypes AuthType
        {
            get { return AuthTypes.EmailPassword; }
        }

        public void Authenticate(PlayFabAuthService authService, Action<LoginResult> resultCallback, Action<PlayFabError> errorCallback, AuthKeys authKeys)
        {
            // If username & password is empty, then do not continue, and Call back to Authentication UI Display
            if (!authService.RememberMe && string.IsNullOrEmpty(authService.Email) && string.IsNullOrEmpty(authService.Password))
            {
                authService.InvokeDisplayAuthentication();
                return;
            }

            // We have not opted for remember me in a previous session, so now we have to login the user with email & password.
            PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest
            {
                Email = authService.Email,
                Password = authService.Password,
                InfoRequestParameters = authService.InfoRequestParams,
                TitleId = PlayFabSettings.TitleId
            },
            resultCallback,
            error =>
            {
                // If user not registered, create one with RegisterPlayFabUser, because LoginWithEmailAddressRequest does not contains "CreateAccount" option.
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
