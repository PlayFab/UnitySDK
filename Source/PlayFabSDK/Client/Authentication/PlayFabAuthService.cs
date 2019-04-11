#if !DISABLE_PLAYFABCLIENT_API

using System;
using System.Collections.Generic;
using PlayFab.Authentication.Strategies;
using PlayFab.ClientModels;
using PlayFab.Internal;
using UnityEngine;

namespace PlayFab
{
    /// <summary>
    /// Supported Authentication types
    /// Note: Add types to there to support more AuthTypes
    /// See - https://api.playfab.com/documentation/client#Authentication
    /// </summary>
    public enum AuthTypes
    {
        EmailPassword,
        Facebook,
        FacebookInstantGames,
        GameCenter,
        GooglePlayGames,
        Kongregate,
        NintendoSwitch,
        None,
        OpenId,
        PlayStation,
        Silent,
        Steam,
        Twitch,
        UsernamePassword,
        WindowsHello,
        XBoxLive
    }

    public class PlayFabAuthService
    {
        // Events to subscribe to for this service
        public delegate void DisplayAuthenticationEvent();
        public event DisplayAuthenticationEvent OnDisplayAuthentication;

        public delegate void LoginSuccessEvent(LoginResult success);
        public event LoginSuccessEvent OnLoginSuccess;

        public delegate void PlayFabErrorEvent(PlayFabError error);
        public event PlayFabErrorEvent OnPlayFabError;

        public delegate void PlayFabLink(AuthTypes authType, PlayFabError error = null);
        public event PlayFabLink OnPlayFabLink;
        public event PlayFabLink OnPlayFabUnlink;

        public string Email;
        public string Username;
        public string Password;
        public GetPlayerCombinedInfoRequestParams InfoRequestParams;
        public bool ForceLink;

        public PlayFabAuthenticationContext AuthenticationContext { get; private set; }

        // All PlayerPrefs keys incompatible with split-screen/multi-instance play (issue to be fixed).
        private const string _LoginRememberKey = "PlayFabLoginRemember";
        private const string _PlayFabRememberMeIdKey = "PlayFabIdPassGuid";
        private const string _PlayFabAuthTypeKey = "PlayFabAuthType";

        /// <summary>
        /// Remember me flag.
        /// Incompatible with split-screen/multi-instance play (issue to be fixed).
        /// </summary>
        public bool RememberMe
        {
            get { return PlayerPrefs.GetInt(_LoginRememberKey, 0) != 0; }
            set { PlayerPrefs.SetInt(_LoginRememberKey, value ? 1 : 0); }
        }

        /// <summary>
        /// Remember the type of authenticate for the user.
        /// Incompatible with split-screen/multi-instance play (issue to be fixed).
        /// </summary>
        public AuthTypes AuthType
        {
            get { return PlayFabUtil.TryEnumParse<AuthTypes>(PlayerPrefs.GetString(_PlayFabAuthTypeKey), AuthTypes.None); }
            set { PlayerPrefs.SetString(_PlayFabAuthTypeKey, value.ToString()); }
        }

        /// <summary>
        /// Generated Remember Me ID.
        /// Pass Null for a value to have one auto-generated.
        /// Incompatible with split-screen/multi-instance play (issue to be fixed).
        /// </summary>
        public string RememberMeId
        {
            get { return PlayerPrefs.GetString(_PlayFabRememberMeIdKey, ""); }
            set
            {
                var guid = string.IsNullOrEmpty(value) ? Guid.NewGuid().ToString() : value;
                PlayerPrefs.SetString(_PlayFabRememberMeIdKey, guid);
            }
        }

        /// <summary>
        /// Check PlayerPrefs, and create new remember me id if empty.
        /// </summary>
        public string GetOrCreateRememberMeId()
        {
            var rememberMeId = PlayerPrefs.GetString(_PlayFabRememberMeIdKey, "");

            if (string.IsNullOrEmpty(rememberMeId))
            {
                rememberMeId = Guid.NewGuid().ToString();
                PlayerPrefs.SetString(_PlayFabRememberMeIdKey, rememberMeId);
            }

            return rememberMeId;
        }

        private readonly Dictionary<AuthTypes, IAuthenticationStrategy> _authStrategies = new Dictionary<AuthTypes, IAuthenticationStrategy>();

        public PlayFabAuthService()
        {
            var assemblyTypes = typeof(IAuthenticationStrategy).Assembly.GetTypes();
            foreach (var eachType in assemblyTypes)
            {
                if (!eachType.IsInterface && typeof(IAuthenticationStrategy).IsAssignableFrom(eachType))
                {
                    var strategy = (IAuthenticationStrategy)Activator.CreateInstance(eachType);
                    _authStrategies.Add(strategy.AuthType, strategy);
                }
            }
        }

        public bool IsClientLoggedIn()
        {
            return AuthenticationContext != null && AuthenticationContext.IsClientLoggedIn();
        }

#if !DISABLE_PLAYFABENTITY_API
        public bool IsEntityLoggedIn()
        {
            return AuthenticationContext != null && AuthenticationContext.IsEntityLoggedIn();
        }
#endif

        public void ClearRememberMe()
        {
            PlayerPrefs.DeleteKey(_LoginRememberKey);
            PlayerPrefs.DeleteKey(_PlayFabRememberMeIdKey);
        }

        /// <summary>
        /// Kick off the authentication process by specific authType.
        /// </summary>
        /// <param name="authType"></param>
        /// <param name="authKeys"></param>
        public void Authenticate(AuthTypes authType, AuthKeys authKeys = null)
        {
            AuthType = authType;
            Authenticate(authKeys);
        }

        public void Authenticate(AuthKeys authKeys = null)
        {
            if (AuthType == AuthTypes.None)
            {
                if (OnDisplayAuthentication != null)
                    OnDisplayAuthentication.Invoke();

                return;
            }

            if (RememberMe && !string.IsNullOrEmpty(RememberMeId))
            {
                PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest
                {
                    CustomId = RememberMeId,
                    InfoRequestParameters = InfoRequestParams,
                    CreateAccount = true
                }, InvokeLoginSuccess, InvokePlayFabError);
                return;
            }

            var auth = _authStrategies[AuthType];

            auth.Authenticate(this, resultCallback =>
            {
                // Store Identity and session
                AuthenticationContext = resultCallback.AuthenticationContext;

                // Note: At this point, they already have an account with PlayFab using a Username (email) & Password
                // If RememberMe is checked, then generate a new Guid for Login with CustomId.
                if (RememberMe && string.IsNullOrEmpty(RememberMeId))
                {
                    //Fire and forget, but link a custom ID to this PlayFab Account.
                    PlayFabClientAPI.LinkCustomID(new LinkCustomIDRequest
                    {
                        CustomId = GetOrCreateRememberMeId(),
                        ForceLink = ForceLink,
                        AuthenticationContext = AuthenticationContext
                    }, null, null);
                }
                InvokeLoginSuccess(resultCallback);
            }, InvokePlayFabError, authKeys);
        }

        internal void InvokeLink(AuthTypes linkType, PlayFabError error = null)
        {
            if (OnPlayFabLink != null)
                OnPlayFabLink.Invoke(linkType, error);
        }

        internal void InvokeUnlink(AuthTypes unlinkType, PlayFabError error = null)
        {
            if (OnPlayFabUnlink != null)
                OnPlayFabUnlink.Invoke(unlinkType, error);
        }

        internal void InvokeDisplayAuthentication()
        {
            if (OnDisplayAuthentication != null)
                OnDisplayAuthentication.Invoke();
        }

        internal void InvokeLoginSuccess(LoginResult loginResult)
        {
            if (OnLoginSuccess != null)
                OnLoginSuccess.Invoke(loginResult);
        }

        internal void InvokePlayFabError(PlayFabError playFabError)
        {
            if (OnPlayFabError != null)
                OnPlayFabError.Invoke(playFabError);
        }

        public void Link(AuthKeys authKeys)
        {
            if (!IsClientLoggedIn())
            {
                InvokeLink(authKeys.AuthType, new PlayFabError
                {
                    Error = PlayFabErrorCode.NotAuthorized,
                    ErrorMessage = "You must log in before you can call L7ink."
                });
                return;
            }

            var auth = _authStrategies[authKeys.AuthType];

            if (auth == null)
            {
                Debug.LogError("Unhandled link type: " + authKeys.AuthType);
                return;
            }

            auth.Link(this, authKeys);
        }

        public void Unlink(AuthKeys authKeys)
        {
            if (!IsClientLoggedIn())
            {
                InvokeUnlink(authKeys.AuthType, new PlayFabError
                {
                    Error = PlayFabErrorCode.NotAuthorized,
                    ErrorMessage = "You must log in before you can call Unlink."
                });
                return;
            }

            var auth = _authStrategies[authKeys.AuthType];

            if (auth == null)
            {
                Debug.LogError("Unhandled unlink type: " + authKeys.AuthType);
                return;
            }

            auth.Unlink(this, authKeys);
        }
    }

    [Serializable]
    public sealed class AuthKeys
    {
        public AuthTypes AuthType;
        public string AuthTicket;
        public string OpenIdConnectionId;
        public string WindowsHelloChallengeSignature;
        public string WindowsHelloPublicKeyHint;
    }
}

#endif
