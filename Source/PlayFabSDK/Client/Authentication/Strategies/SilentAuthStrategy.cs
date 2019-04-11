#if !DISABLE_PLAYFABCLIENT_API

using System;
using UnityEngine;
using PlayFab.ClientModels;

namespace PlayFab.Authentication.Strategies
{
    internal sealed class SilentAuthStrategy : IAuthenticationStrategy
    {
        public AuthTypes AuthType
        {
            get { return AuthTypes.Silent; }
        }

        public void Authenticate(PlayFabAuthService authService, Action<LoginResult> resultCallback, Action<PlayFabError> errorCallback, AuthKeys authKeys)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest
            {
                AndroidDevice = SystemInfo.deviceModel,
                OS = SystemInfo.operatingSystem,
                AndroidDeviceId = PlayFabSettings.DeviceUniqueIdentifier,
                CreateAccount = true,
                InfoRequestParameters = authService.InfoRequestParams
            }, resultCallback, errorCallback);
#elif UNITY_IPHONE || UNITY_IOS && !UNITY_EDITOR
            PlayFabClientAPI.LoginWithIOSDeviceID(new LoginWithIOSDeviceIDRequest
            {
                DeviceModel = SystemInfo.deviceModel,
                OS = SystemInfo.operatingSystem,
                DeviceId = PlayFabSettings.DeviceUniqueIdentifier,
                CreateAccount = true,
                InfoRequestParameters = authService.InfoRequestParams
            }, resultCallback, errorCallback);
#else
            PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest
            {
                CustomId = authService.GetOrCreateRememberMeId(),
                CreateAccount = true,
                InfoRequestParameters = authService.InfoRequestParams
            }, resultCallback, errorCallback);
#endif
        }

        public void Link(PlayFabAuthService authService, AuthKeys authKeys)
        {
            Authenticate(authService, resultCallback =>
            {
#if UNITY_ANDROID && !UNITY_EDITOR
                PlayFabClientAPI.LinkAndroidDeviceID(new LinkAndroidDeviceIDRequest
                {
                    AndroidDeviceId = PlayFabSettings.DeviceUniqueIdentifier,
                    AuthenticationContext = authService.AuthenticationContext,
                    AndroidDevice = SystemInfo.deviceModel,
                    OS = SystemInfo.operatingSystem,
                    ForceLink = authService.ForceLink
                }, linkCallback =>
                {
                    authService.InvokeLink(AuthTypes.Silent);
                }, errorCallback =>
                {
                    authService.InvokeLink(AuthTypes.Silent, errorCallback);
                });
#elif UNITY_IPHONE || UNITY_IOS && !UNITY_EDITOR
                PlayFabClientAPI.LinkIOSDeviceID(new LinkIOSDeviceIDRequest
                {
                    DeviceId = PlayFabSettings.DeviceUniqueIdentifier,
                    AuthenticationContext = authService.AuthenticationContext,
                    DeviceModel = SystemInfo.deviceModel,
                    OS = SystemInfo.operatingSystem,
                    ForceLink = authService.ForceLink
                }, linkCallback =>
                {
                    authService.InvokeLink(AuthTypes.Silent);
                }, errorCallback =>
                {
                    authService.InvokeLink(AuthTypes.Silent, errorCallback);
                });
#else
                PlayFabClientAPI.LinkCustomID(new LinkCustomIDRequest
                {
                    CustomId = authService.GetOrCreateRememberMeId(),
                    AuthenticationContext = authService.AuthenticationContext,
                    ForceLink = authService.ForceLink
                }, linkCallback =>
                {
                    authService.InvokeLink(AuthTypes.Silent);
                }, errorCallback =>
                {
                    authService.InvokeLink(AuthTypes.Silent, errorCallback);
                });
#endif
            }, errorCallback =>
            {
                authService.InvokeLink(AuthTypes.Silent, errorCallback);
            }, authKeys);
        }

        public void Unlink(PlayFabAuthService authService, AuthKeys authKeys)
        {
            Authenticate(authService, resultCallback =>
            {
#if UNITY_ANDROID && !UNITY_EDITOR
                PlayFabClientAPI.UnlinkAndroidDeviceID(new UnlinkAndroidDeviceIDRequest()
                {
                    AndroidDeviceId = PlayFabSettings.DeviceUniqueIdentifier,
                    AuthenticationContext = authService.AuthenticationContext
                }, unlinkCallback =>
                {
                    authService.InvokeUnlink(AuthTypes.Silent);
                }, errorCallback =>
                {
                    authService.InvokeUnlink(AuthTypes.Silent, errorCallback);
                });
#elif UNITY_IPHONE || UNITY_IOS && !UNITY_EDITOR
                PlayFabClientAPI.UnlinkIOSDeviceID(new UnlinkIOSDeviceIDRequest()
                {
                    DeviceId = PlayFabSettings.DeviceUniqueIdentifier,
                    AuthenticationContext = authService.AuthenticationContext
                }, unlinkCallback =>
                {
                    authService.InvokeUnlink(AuthTypes.Silent);
                }, errorCallback =>
                {
                    authService.InvokeUnlink(AuthTypes.Silent, errorCallback);
                });
#else
                PlayFabClientAPI.UnlinkCustomID(new UnlinkCustomIDRequest
                {
                    CustomId = authService.GetOrCreateRememberMeId(),
                    AuthenticationContext = authService.AuthenticationContext
                }, unlinkCallback =>
                {
                    authService.InvokeUnlink(AuthTypes.Silent);
                }, errorCallback =>
                {
                    authService.InvokeUnlink(AuthTypes.Silent, errorCallback);
                });
#endif
            }, errorCallback => authService.InvokeUnlink(AuthTypes.Silent, errorCallback), authKeys);
        }
    }
}

#endif
