using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEditor;

namespace PlayFab.PfEditor
{
    public class PlayFabEditorMenu : UnityEditor.Editor
    {
        private static int focusIndex;

        #region panel variables
        internal enum MenuStates
        {
            Sdks = 0,
            Settings = 1,
            Data = 2,
            Help = 3,
            Tools = 4,
            Packages = 5,
            Logout = 6
        }

        internal static MenuStates _menuState = MenuStates.Sdks;
        #endregion
        public static void DrawMenu()
        { 
            if (PlayFabEditorSDKTools.IsInstalled && PlayFabEditorSDKTools.isSdkSupported)
            {
                mainMenuHandler(); 
            }
            else
            {
                subMenuHandler();
            }


            if (PlayFabEditorSDKTools.IsInstalled && PlayFabEditorSDKTools.isSdkSupported)
                _menuState = (MenuStates)PlayFabEditorPrefsSO.Instance.curMainMenuIdx;

            var sdksButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            var settingsButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            var dataButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            var helpButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            var logoutButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("Button");
            var toolsButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            var packagesButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            if (_menuState == MenuStates.Sdks)
            sdksButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton_selected");
            if (_menuState == MenuStates.Settings)
            settingsButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton_selected");
            if (_menuState == MenuStates.Logout)
            logoutButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton_selected");
            if (_menuState == MenuStates.Data)
            dataButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton_selected");
            if (_menuState == MenuStates.Help)
            helpButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton_selected");
            if (_menuState == MenuStates.Packages)
            packagesButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton_selected");
            if (_menuState == MenuStates.Tools)
            toolsButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton_selected");

            using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1"), GUILayout.Height(25), GUILayout.ExpandWidth(true)))
            {
                GUILayout.Space(5); 
                GUI.SetNextControlName("sdk"); 
                if (GUILayout.Button("SDK", sdksButtonStyle, GUILayout.MaxWidth(35)))
                {
                    OnSdKsClicked();
                }
                if (PlayFabEditorSDKTools.IsInstalled && PlayFabEditorSDKTools.isSdkSupported)
                {
                    
                    GUI.SetNextControlName("settings");
                    if (GUILayout.Button("SETTINGS", settingsButtonStyle, GUILayout.MaxWidth(65)))
                    {
                        OnSettingsClicked();
                    }
                    GUI.SetNextControlName("data");
                    if (GUILayout.Button("DATA", dataButtonStyle, GUILayout.MaxWidth(45)))
                    {
                        OnDataClicked();
                    }
                    GUI.SetNextControlName("tools");
                    if (GUILayout.Button("TOOLS", toolsButtonStyle, GUILayout.MaxWidth(45)))
                    {
                        OnToolsClicked();
                    }
                    GUI.SetNextControlName("packages");
                    if (GUILayout.Button("PACKAGES", packagesButtonStyle, GUILayout.MaxWidth(72)))
                    {
                        OnPackagesClicked();
                    }
                }
                GUI.SetNextControlName("help");
                if (GUILayout.Button("HELP", helpButtonStyle, GUILayout.MaxWidth(45)))
                {
                    OnHelpClicked();
                }
                GUILayout.FlexibleSpace();
                GUI.SetNextControlName("logOut");
                if (GUILayout.Button("LOGOUT", logoutButtonStyle, GUILayout.MaxWidth(85)))
                {
                    OnLogoutClicked();
                }
            }
        }

        public static void mainMenuHandler()
        {
            var e = Event.current;
            if (e.type == EventType.KeyUp && (e.keyCode == KeyCode.RightArrow))
            {
                string[] controlNames = { "sdk", "settings", "data", "tools", "packages", "help", "logOut" };
                int direction = e.keyCode == KeyCode.RightArrow ? 1 : -1;
                for (int i = 0; i < controlNames.Length; i++)
                {
                    focusIndex = (focusIndex + direction + controlNames.Length) % controlNames.Length;
                    if (IsControlVisible(controlNames[focusIndex]))
                    {
                        EditorGUI.FocusTextInControl(controlNames[focusIndex]);
                        break;
                    }
                }
            }
            else if (e.type == EventType.KeyUp && (e.keyCode == KeyCode.LeftArrow))
            {
                string[] controlNames = { "logOut", "help", "packages", "tools", "data", "settings", "sdk" };
                int direction = e.keyCode == KeyCode.LeftArrow ? 1 : -1;
                for (int i = 0; i < controlNames.Length; i++)
                {
                    focusIndex = (focusIndex + direction + controlNames.Length) % controlNames.Length;
                    if (IsControlVisible(controlNames[focusIndex]))
                    {
                        EditorGUI.FocusTextInControl(controlNames[focusIndex]);
                        break;
                    }
                }
            }
        }

        private static bool IsControlVisible(string controlName)
        {
            Rect controlRect = GetControlRectByName(controlName);
            return controlRect.xMin < Screen.width && controlRect.xMax > 0 &&
            controlRect.yMin < Screen.height && controlRect.yMax > 0;
        }
        private static Rect GetControlRectByName(string controlName)
        {
            return new Rect(0, 0, 100, 20);
        }

        public static void subMenuHandler()
        {
            var e = Event.current;
            if (e.type == EventType.KeyUp && (e.keyCode == KeyCode.RightArrow))
            {
                string[] controlNamesnoSDK = { "sdk", "help", "logOut" };
                int direction = e.keyCode == KeyCode.RightArrow ? 1 : -1;
                for (int i = 0; i < controlNamesnoSDK.Length; i++)
                {
                    focusIndex = (focusIndex + direction + controlNamesnoSDK.Length) % controlNamesnoSDK.Length;
                    if (IsControlVisible(controlNamesnoSDK[focusIndex]))
                    {
                        EditorGUI.FocusTextInControl(controlNamesnoSDK[focusIndex]);
                        break;
                    }
                }
            }
            else if (e.type == EventType.KeyUp && (e.keyCode == KeyCode.LeftArrow))
            {
                string[] controlNamesnoSDK = { "logOut", "help", "sdk" };
                int direction = e.keyCode == KeyCode.RightArrow ? 1 : -1;
                for (int i = 0; i < controlNamesnoSDK.Length; i++)
                {
                    focusIndex = (focusIndex + direction + controlNamesnoSDK.Length) % controlNamesnoSDK.Length;
                    if (IsControlVisible(controlNamesnoSDK[focusIndex]))
                    {
                        EditorGUI.FocusTextInControl(controlNamesnoSDK[focusIndex]);
                        break;
                    }
                }
            }

        }

        public static void OnToolsClicked()
        {
            _menuState = MenuStates.Tools;
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnMenuItemClicked, MenuStates.Tools.ToString());
            PlayFabEditorPrefsSO.Instance.curMainMenuIdx = (int)_menuState;
        }
        
        public static void OnDataClicked()
        {
            _menuState = MenuStates.Data;
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnMenuItemClicked, MenuStates.Data.ToString());
            PlayFabEditorPrefsSO.Instance.curMainMenuIdx = (int)_menuState;
        }

        public static void OnHelpClicked()
        {
            _menuState = MenuStates.Help;
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnMenuItemClicked, MenuStates.Help.ToString());
            PlayFabEditorPrefsSO.Instance.curMainMenuIdx = (int)_menuState;
        }

        public static void OnSdKsClicked()
        {
            _menuState = MenuStates.Sdks;
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnMenuItemClicked, MenuStates.Sdks.ToString());
            PlayFabEditorPrefsSO.Instance.curMainMenuIdx = (int)_menuState;
        }

        public static void OnSettingsClicked()
        {
            _menuState = MenuStates.Settings;
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnMenuItemClicked, MenuStates.Settings.ToString());
            PlayFabEditorPrefsSO.Instance.curMainMenuIdx = (int)_menuState;
        }

        public static void OnPackagesClicked()
        {
            _menuState = MenuStates.Packages;
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnMenuItemClicked, MenuStates.Packages.ToString());
            PlayFabEditorPrefsSO.Instance.curMainMenuIdx = (int)_menuState;
        }

        public static void OnLogoutClicked()
        {
            _menuState = MenuStates.Logout;
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnMenuItemClicked, MenuStates.Logout.ToString());
            PlayFabEditorAuthenticate.Logout();

            _menuState = MenuStates.Sdks;
            PlayFabEditorPrefsSO.Instance.curMainMenuIdx = (int)_menuState;
        }
    }
}
