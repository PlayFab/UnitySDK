using UnityEngine;

namespace PlayFab.PfEditor
{
    public class PlayFabEditorMenu : UnityEditor.Editor
    {
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
                _menuState = (MenuStates)PlayFabEditorPrefsSO.Instance.curMainMenuIdx;

            var sdksButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            var settingsButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            var dataButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            var helpButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
            var logoutButtonStyle = PlayFabEditorHelper.uiStyle.GetStyle("textButton");
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

                if (GUILayout.Button("SDK", sdksButtonStyle, GUILayout.MaxWidth(35)))
                {
                    OnSdKsClicked();
                }

                if (PlayFabEditorSDKTools.IsInstalled && PlayFabEditorSDKTools.isSdkSupported)
                {
                    if (GUILayout.Button("SETTINGS", settingsButtonStyle, GUILayout.MaxWidth(65)))
                        OnSettingsClicked();
                    if (GUILayout.Button("DATA", dataButtonStyle, GUILayout.MaxWidth(45)))
                        OnDataClicked();
                    if (GUILayout.Button("TOOLS", toolsButtonStyle, GUILayout.MaxWidth(45)))
                        OnToolsClicked();
                    if(GUILayout.Button("PACKAGES", packagesButtonStyle, GUILayout.MaxWidth(72)))
                        OnPackagesClicked();
                }

                if (GUILayout.Button("HELP", helpButtonStyle, GUILayout.MaxWidth(45)))
                    OnHelpClicked();
                GUILayout.FlexibleSpace();

                if (GUILayout.Button("LOGOUT", logoutButtonStyle, GUILayout.MaxWidth(55)))
                    OnLogoutClicked();
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
