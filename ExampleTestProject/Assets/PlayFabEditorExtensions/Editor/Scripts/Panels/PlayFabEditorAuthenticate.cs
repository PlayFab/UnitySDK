using Microsoft.Identity.Client;
using PlayFab.PfEditor.EditorModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using UnityEditor;
using UnityEngine;

namespace PlayFab.PfEditor
{
    public class PlayFabEditorAuthenticate : UnityEditor.Editor
    {
        #region panel variables
        private static string _userEmail = string.Empty;
        private static string _userPass = string.Empty;
        private static string _2FaCode = string.Empty;
        private static string _studio = string.Empty;
        private static int focusIndex;
        private static bool isShiftKeyPressed = false;
        private static bool isInitialized = false;

        public enum PanelDisplayStates { Login, TwoFactorPrompt }
        private static PanelDisplayStates activeState = PanelDisplayStates.Login;
        #endregion

#region draw calls
private static void shiftKeyHandler()
        {
            var e = Event.current;
            if (e.keyCode == KeyCode.LeftShift || e.keyCode == KeyCode.RightShift)
            {
                isShiftKeyPressed = true;
            }

            if (e.type == EventType.KeyUp && (e.keyCode == KeyCode.LeftShift || e.keyCode == KeyCode.RightShift))
            {
                isShiftKeyPressed = false;
            }
        }
        //changes local
        public static void InputHandler()
        {
            var e = Event.current;
            shiftKeyHandler(); // method calling
            if (e.type == EventType.KeyUp && e.keyCode == KeyCode.Tab)
            {
                if (!isShiftKeyPressed)
                {
                    switch (focusIndex)
                    {
                        case 0:
                            EditorGUI.FocusTextInControl("email");
                            focusIndex = 1;
                            break;
                        case 1:
                            EditorGUI.FocusTextInControl("password");
                            focusIndex = 2;
                            break;
                        case 2:
                            EditorGUI.FocusTextInControl("login");
                            focusIndex = 3;
                            break;
                        case 3:
                            EditorGUI.FocusTextInControl("login_microsoft");
                            focusIndex = 4;
                            break;
                        case 4:
                            GUI.FocusControl("view_readme");
                            focusIndex = 0;
                            break;
                    }
                }
                else
                {
                    switch (focusIndex)
                    {
                        case 0:
                            EditorGUI.FocusTextInControl("login_microsoft");
                            focusIndex = 4;
                            break;
                        case 1:
                            GUI.FocusControl("view_readme");
                            focusIndex = 0;
                            break;
                        case 2:
                            EditorGUI.FocusTextInControl("email");
                            focusIndex = 1;
                            break;
                        case 3:
                            EditorGUI.FocusTextInControl("password");
                            focusIndex = 2;
                            break;
                        case 4:
                            EditorGUI.FocusTextInControl("login");
                            focusIndex = 3;
                            break;
                    }
                }
            }
        }

        public static void DrawAuthPanels()
        {
            //capture enter input for login
            var e = Event.current;
            if (e.type == EventType.KeyUp && e.keyCode == KeyCode.Return)
            {
                switch (activeState)
                {
                    case PanelDisplayStates.Login:
                        OnLoginButtonClicked();
                        break;
                    case PanelDisplayStates.TwoFactorPrompt:
                        OnContinueButtonClicked();
                        break;
                }
            }

            if (PlayFabEditorHelper.uiStyle == null)
                return;

            if (activeState == PanelDisplayStates.TwoFactorPrompt)
            {
                using (new UnityVertical(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
                {
                    using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                        EditorGUILayout.LabelField("Enter your 2-factor authorization code.", PlayFabEditorHelper.uiStyle.GetStyle("cGenTxt"), GUILayout.MinWidth(EditorGUIUtility.currentViewWidth));

                    using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
                    {
                        GUILayout.FlexibleSpace();
                        _2FaCode = EditorGUILayout.TextField(_2FaCode, PlayFabEditorHelper.uiStyle.GetStyle("TextField"), GUILayout.MinHeight(25), GUILayout.MinWidth(200));
                        GUILayout.FlexibleSpace();
                    }

                    using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("labelStyle")))
                    {
                        var buttonWidth = 100;
                        GUILayout.FlexibleSpace();
                        if (GUILayout.Button("CONTINUE", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MinHeight(32), GUILayout.MaxWidth(buttonWidth)))
                        {
                            OnContinueButtonClicked();
                            _2FaCode = string.Empty;

                        }
                        GUILayout.FlexibleSpace();
                    }

                    using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("labelStyle")))
                    {
                        GUILayout.FlexibleSpace();
                        if (GUILayout.Button("CANCEL", PlayFabEditorHelper.uiStyle.GetStyle("textButton")))
                        {
                            activeState = PanelDisplayStates.Login;
                        }
                        GUILayout.FlexibleSpace();
                    }
                }
                return;
            }

            if (!string.IsNullOrEmpty(PlayFabEditorPrefsSO.Instance.DevAccountEmail) && !isInitialized)
            {
                _userEmail = PlayFabEditorPrefsSO.Instance.DevAccountEmail;
                PlayFabEditorPrefsSO.Save();
            }
            
            isInitialized = true;

            using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
                EditorGUILayout.LabelField("Welcome to PlayFab!", PlayFabEditorHelper.uiStyle.GetStyle("titleLabel"), GUILayout.MinWidth(EditorGUIUtility.currentViewWidth));

            if (activeState == PanelDisplayStates.Login)
            {
                // login mode, this state either logged out, or did not have auto-login checked.
                DrawLogin();
                InputHandler();
            }

            using (new UnityVertical(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
            {
                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                {
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("VIEW README ->", PlayFabEditorHelper.uiStyle.GetStyle("textButton")))
                    {
                        Application.OpenURL("https://github.com/PlayFab/UnityEditorExtensions#setup");
                    }
                    GUILayout.FlexibleSpace();
                }
            }
        }

        private static void DrawLogin()
        {
            float labelWidth = 120;

            using (new UnityVertical(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
            {
                var labelStyle = PlayFabEditorHelper.uiStyle.GetStyle("labelStyle");
                GUILayout.Space(5);

                using (new UnityHorizontal(labelStyle))
                {
                    GUILayout.FlexibleSpace();
                    
                    GUI.SetNextControlName("login_microsoft");
                    var msftTexture = Resources.Load("ms-symbollockup_signin_dark") as Texture2D;
                    var msftStyle = new GUIStyle();
                    msftStyle.normal.background = msftTexture;
                    if (GUILayout.Button("", msftStyle, GUILayout.Width(msftTexture.width), GUILayout.Height(msftTexture.height)))
                    {
                        OnAADLoginButtonClicked();
                    }

                    GUILayout.FlexibleSpace();
                }

                GUILayout.Space(10);

                using (new UnityHorizontal(labelStyle))
                {
                    var separator = new GUIStyle(GUI.skin.horizontalScrollbar);
                    separator.normal.background = Texture2D.grayTexture;
                    separator.fixedHeight = 1;

                    GUILayout.FlexibleSpace();
                    EditorGUILayout.LabelField("", separator, GUILayout.MaxWidth(EditorGUIUtility.currentViewWidth / 3));
                    using (new UnityVertical())
                    {
                        var spaceHeight = (separator.fixedHeight - labelStyle.CalcHeight(new GUIContent("or"), EditorGUIUtility.currentViewWidth)) / 2;
                        GUILayout.Space(spaceHeight);
                        var label = new GUIContent(" or ");
                        EditorGUILayout.LabelField(label, labelStyle, GUILayout.Width(labelStyle.CalcSize(label).x));
                        GUILayout.Space(spaceHeight);
                    }
                    EditorGUILayout.LabelField("", separator, GUILayout.MaxWidth(EditorGUIUtility.currentViewWidth / 3));
                    GUILayout.FlexibleSpace();
                }

                using (var fwl = new FixedWidthLabel("EMAIL: "))
                {
                    GUILayout.Space(labelWidth - fwl.fieldWidth);
                    GUI.SetNextControlName("email");
                    _userEmail = EditorGUILayout.TextField(_userEmail, PlayFabEditorHelper.uiStyle.GetStyle("TextField"), GUILayout.MinHeight(25));
                }

                using (var fwl = new FixedWidthLabel("PASSWORD: "))
                {
                    GUILayout.Space(labelWidth - fwl.fieldWidth);
                    GUI.SetNextControlName("password");
                    _userPass = EditorGUILayout.PasswordField(_userPass, PlayFabEditorHelper.uiStyle.GetStyle("TextField"), GUILayout.MinHeight(25));
                }

                using (new UnityHorizontal(labelStyle))
                {
                    var buttonWidth = 100;
                    GUILayout.FlexibleSpace();
                    GUI.SetNextControlName("login");
                    if (GUILayout.Button("LOG IN", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MinHeight(32), GUILayout.MaxWidth(buttonWidth)))
                    {
                        OnLoginButtonClicked();
                    }
                }
            }
        }
        #endregion

        #region menu and helper methods
        public static bool IsAuthenticated()
        {
            return !string.IsNullOrEmpty(PlayFabEditorPrefsSO.Instance.DevAccountToken);
        }

        public static void Logout()
        {
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnLogout);

            PlayFabEditorApi.Logout(new LogoutRequest
            {
                DeveloperClientToken = PlayFabEditorPrefsSO.Instance.DevAccountToken
            }, null, PlayFabEditorHelper.SharedErrorCallback);

            _userPass = string.Empty;

            activeState = PanelDisplayStates.Login;

            PlayFabEditorPrefsSO.Instance.StudioList = null;
            PlayFabEditorPrefsSO.Instance.DevAccountToken = string.Empty;
            PlayFabEditorPrefsSO.Save();

            PlayFabEditorPrefsSO.Instance.TitleDataCache.Clear();
            PlayFabEditorDataService.SaveEnvDetails();
        }

        private static void OnLoginButtonClicked()
        {
            PlayFabEditorApi.Login(new LoginRequest()
            {
                DeveloperToolProductName = PlayFabEditorHelper.EDEX_NAME,
                DeveloperToolProductVersion = PlayFabEditorHelper.EDEX_VERSION,
                Email = _userEmail,
                Password = _userPass
            }, (result) =>
            {
                PlayFabEditorPrefsSO.Instance.DevAccountToken = result.DeveloperClientToken;
                PlayFabEditorPrefsSO.Instance.DevAccountEmail = _userEmail;
                PlayFabEditorDataService.RefreshStudiosList();
                PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnLogin);
                PlayFabEditorPrefsSO.Save();
                PlayFabEditorMenu._menuState = PlayFabEditorMenu.MenuStates.Sdks;

            }, (error) =>
            {
                if ((int)error.Error == 1246 || error.ErrorMessage.Contains("TwoFactor"))
                {
                    // pop 2FA dialog
                    PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnWarning, "This account requires 2-Factor Authentication.");
                    activeState = PanelDisplayStates.TwoFactorPrompt;
                }
                else
                {
                    PlayFabEditorHelper.SharedErrorCallback(error);
                }
            });
        }

        private static async void OnAADLoginButtonClicked()
        {
            string[] scopes = new string[] { PlayFabEditorHelper.ED_EX_AAD_SCOPES };

            AuthenticationResult authResult = null;

            var app = PublicClientApplicationBuilder.Create(PlayFabEditorHelper.ED_EX_AAD_SIGNIN_CLIENTID)
                           .WithAuthority($"{PlayFabEditorHelper.AAD_SIGNIN_URL}{PlayFabEditorHelper.ED_EX_AAD_SIGNNIN_TENANT}")
                           .WithRedirectUri("http://localhost")
                           .Build();

            var accounts = await app.GetAccountsAsync();

            var firstAccount = accounts.GetEnumerator().Current;

            try
            {
                // Always first try to acquire a token silently.
                authResult = await app.AcquireTokenSilent(scopes, firstAccount).ExecuteAsync();
            }
            catch (MsalUiRequiredException)
            {
                try
                {
                    SystemWebViewOptions options = new SystemWebViewOptions();
                    authResult = await app.AcquireTokenInteractive(scopes).WithSystemWebViewOptions(options).ExecuteAsync();
                }
                catch (MsalException msalex)
                {
                    Debug.Log($"Error acquiring Token:{System.Environment.NewLine}{msalex}");
                }
            }
            catch (Exception ex)
            {
                Debug.Log($"Error acquiring token silently:{System.Environment.NewLine}{ex}");
                return;
            }

            if (authResult != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(authResult.AccessToken);

                foreach(var audience in jwtToken.Audiences)
                {
                    if (audience.Contains(PlayFabEditorHelper.ED_EX_AAD_SCOPE))
                    {
                        PlayFabEditorPrefsSO.Instance.AadAuthorization = authResult.AccessToken;
                        
                        PlayFabEditorApi.LoginWithAAD(new LoginWithAADRequest() {
                            DeveloperToolProductName = PlayFabEditorHelper.EDEX_NAME,
                            DeveloperToolProductVersion = PlayFabEditorHelper.EDEX_VERSION
                        }, (result) =>
                        {
                            PlayFabEditorPrefsSO.Instance.DevAccountToken = result.DeveloperClientToken;
                            PlayFabEditorDataService.RefreshStudiosList();
                            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnLogin);
                            PlayFabEditorPrefsSO.Save();
                            PlayFabEditorMenu._menuState = PlayFabEditorMenu.MenuStates.Sdks;

                        }, PlayFabEditorHelper.SharedErrorCallback);
                    }
                    else
                    {
                        Debug.Log($"Token acquired but for wrong audience: {audience}");
                    } 
                }
            }
        }

        private static void OnContinueButtonClicked()
        {
            PlayFabEditorApi.Login(new LoginRequest()
            {
                DeveloperToolProductName = PlayFabEditorHelper.EDEX_NAME,
                DeveloperToolProductVersion = PlayFabEditorHelper.EDEX_VERSION,
                TwoFactorAuth = _2FaCode,
                Email = _userEmail,
                Password = _userPass
            }, (result) =>
            {
                PlayFabEditorPrefsSO.Instance.DevAccountToken = result.DeveloperClientToken;
                PlayFabEditorPrefsSO.Instance.DevAccountEmail = _userEmail;
                PlayFabEditorDataService.RefreshStudiosList();
                PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnLogin);
                PlayFabEditorPrefsSO.Save();
                PlayFabEditorMenu._menuState = PlayFabEditorMenu.MenuStates.Sdks;

            }, PlayFabEditorHelper.SharedErrorCallback);
        }
        #endregion
    }
}
