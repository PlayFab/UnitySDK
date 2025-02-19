using UnityEditor;
using UnityEngine;

namespace PlayFab.PfEditor
{
    [InitializeOnLoad]
    public class PlayFabEditorSettings : UnityEditor.Editor
    {
        #region panel variables
        public enum SubMenuStates
        {
            StandardSettings,
            TitleSettings,
        }

        public enum WebRequestType
        {
#if !UNITY_2018_2_OR_NEWER // Unity has deprecated Www
            UnityWww, // High compatability Unity api calls
#endif
            UnityWebRequest, // Modern unity HTTP component
            HttpWebRequest, // High performance multi-threaded api calls
            CustomHttp //If this is used, you must set the Http to an IPlayFabHttp object.
        }

        private static SubMenuComponent _menu = null;
        #endregion

        #region draw calls
        public static void DrawSettingsPanel()
        {
            if (_menu != null)
            {
                _menu.DrawMenu();
                switch ((SubMenuStates)PlayFabEditorPrefsSO.Instance.curSubMenuIdx)
                {
                    case SubMenuStates.StandardSettings:
                        DrawStandardSettingsSubPanel();
                        break;
                }
            }
            else
            {
                RegisterMenu();
            }
        }

        private static void DrawStandardSettingsSubPanel()
        {
            float labelWidth = 160;

            using (new UnityVertical(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1"), GUILayout.ExpandWidth(true)))
            {
                // Override studio lets you set your own titleId
                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                {
                    EditorGUILayout.LabelField("TITLE ID: ", PlayFabEditorHelper.uiStyle.GetStyle("labelStyle"), GUILayout.Width(labelWidth));

                    var newTitleId = EditorGUILayout.TextField(PlayFabEditorDataService.SharedSettings.TitleId, PlayFabEditorHelper.uiStyle.GetStyle("TextField"), GUILayout.MinHeight(25));
                    if (newTitleId != PlayFabEditorDataService.SharedSettings.TitleId)
                        OnTitleIdChange(newTitleId);
                }

                DrawPfSharedSettingsOptions(labelWidth);
            }
        }

        private static void DrawPfSharedSettingsOptions(float labelWidth)
        {
            using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
            {
                EditorGUILayout.LabelField("REQUEST TYPE: ", PlayFabEditorHelper.uiStyle.GetStyle("labelStyle"), GUILayout.MaxWidth(labelWidth));
                PlayFabEditorDataService.SharedSettings.WebRequestType = (WebRequestType)EditorGUILayout.EnumPopup(PlayFabEditorDataService.SharedSettings.WebRequestType, PlayFabEditorHelper.uiStyle.GetStyle("TextField"), GUILayout.Height(25));
            }

            if (PlayFabEditorDataService.SharedSettings.WebRequestType == WebRequestType.HttpWebRequest)
            {
                using (var fwl = new FixedWidthLabel(new GUIContent("REQUEST TIMEOUT: "), PlayFabEditorHelper.uiStyle.GetStyle("labelStyle")))
                {
                    GUILayout.Space(labelWidth - fwl.fieldWidth);
                    PlayFabEditorDataService.SharedSettings.TimeOut = EditorGUILayout.IntField(PlayFabEditorDataService.SharedSettings.TimeOut, PlayFabEditorHelper.uiStyle.GetStyle("TextField"), GUILayout.MinHeight(25));
                }

                using (var fwl = new FixedWidthLabel(new GUIContent("KEEP ALIVE: "), PlayFabEditorHelper.uiStyle.GetStyle("labelStyle")))
                {
                    GUILayout.Space(labelWidth - fwl.fieldWidth);
                    PlayFabEditorDataService.SharedSettings.KeepAlive = EditorGUILayout.Toggle(PlayFabEditorDataService.SharedSettings.KeepAlive, PlayFabEditorHelper.uiStyle.GetStyle("Toggle"), GUILayout.MinHeight(25));
                }
            }
        }
        #endregion

        #region menu and helper methods
        private static void RegisterMenu()
        {
            if (_menu != null)
                return;

            _menu = CreateInstance<SubMenuComponent>();
            _menu.RegisterMenuItem("PROJECT", OnStandardSetttingsClicked);
        }

        private static void OnStandardSetttingsClicked()
        {
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnSubmenuItemClicked, SubMenuStates.StandardSettings.ToString(), "" + (int)SubMenuStates.StandardSettings);
        }

        private static void OnTitleIdChange(string newTitleId)
        {
            PlayFabEditorDataService.SharedSettings.TitleId = newTitleId;
            PlayFabEditorDataService.SaveEnvDetails();
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnSuccess);
        }
        #endregion
    }
}
