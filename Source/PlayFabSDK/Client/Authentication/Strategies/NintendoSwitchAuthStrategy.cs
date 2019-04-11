#if !DISABLE_PLAYFABCLIENT_API

using System;
using PlayFab.ClientModels;

namespace PlayFab.Authentication.Strategies
{
    internal sealed class NintendoSwitchAuthStrategy : IAuthenticationStrategy
    {
        public AuthTypes AuthType
        {
            get { return AuthTypes.NintendoSwitch; }
        }

        public void Authenticate(PlayFabAuthService authService, Action<LoginResult> resultCallback, Action<PlayFabError> errorCallback, AuthKeys authKeys)
        {
            PlayFabClientAPI.LoginWithNintendoSwitchDeviceId(new LoginWithNintendoSwitchDeviceIdRequest
            {
                NintendoSwitchDeviceId = PlayFabSettings.DeviceUniqueIdentifier,
                InfoRequestParameters = authService.InfoRequestParams,
                CreateAccount = true
            }, resultCallback, errorCallback);
        }

        public void Link(PlayFabAuthService authService, AuthKeys authKeys)
        {
            PlayFabClientAPI.LinkNintendoSwitchDeviceId(new LinkNintendoSwitchDeviceIdRequest
            {
                NintendoSwitchDeviceId = PlayFabSettings.DeviceUniqueIdentifier,
                AuthenticationContext = authService.AuthenticationContext,
                ForceLink = authService.ForceLink
            }, resultCallback =>
            {
                authService.InvokeLink(AuthTypes.NintendoSwitch);
            }, errorCallback =>
            {
                authService.InvokeLink(AuthTypes.NintendoSwitch, errorCallback);
            });
        }

        public void Unlink(PlayFabAuthService authService, AuthKeys authKeys)
        {
            PlayFabClientAPI.UnlinkNintendoSwitchDeviceId(new UnlinkNintendoSwitchDeviceIdRequest
            {
                AuthenticationContext = authService.AuthenticationContext,
                NintendoSwitchDeviceId = PlayFabSettings.DeviceUniqueIdentifier
            }, resultCallback =>
            {
                authService.InvokeUnlink(AuthTypes.NintendoSwitch);
            }, errorCallback =>
            {
                authService.InvokeUnlink(AuthTypes.NintendoSwitch, errorCallback);
            });
        }
    }
}

#endif
