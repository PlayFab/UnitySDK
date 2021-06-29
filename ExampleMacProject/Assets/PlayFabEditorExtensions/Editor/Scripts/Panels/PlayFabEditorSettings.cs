using PlayFab.PfEditor.EditorModels;
using System;
using System.Collections.Generic;
using System.Text;
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
            ApiSettings,
        }

        public enum WebRequestType
        {
            UnityWww, // High compatability Unity api calls
            HttpWebRequest, // High performance multi-threaded api calls
#if UNITY_2017_2_OR_NEWER
            UnityWebRequest, // Modern unity HTTP component
#endif
        }

        private static float LABEL_WIDTH = 180;

        private static readonly StringBuilder Sb = new StringBuilder();

        private static SubMenuComponent _menu = null;

        private static readonly Dictionary<string, StudioDisplaySet> StudioFoldOutStates = new Dictionary<string, StudioDisplaySet>();
        private static Vector2 _titleScrollPos = Vector2.zero;
        #endregion

        #region draw calls
        private static void DrawApiSubPanel()
        {
            using (new UnityVertical(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
            {
                var curDefines = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
                var changedFlags = false;
                var allFlags = new Dictionary<string, PfDefineFlag>(PlayFabEditorHelper.FLAG_LABELS);
                var extraDefines = new HashSet<string>(curDefines.Split(' ', ';'));
                foreach (var eachFlag in extraDefines)
                    if (!string.IsNullOrEmpty(eachFlag) && !allFlags.ContainsKey(eachFlag))
                        allFlags.Add(eachFlag, new PfDefineFlag { Flag = eachFlag, Label = eachFlag, Category = PfDefineFlag.FlagCategory.Other, isInverted = false, isSafe = false });
                var allowUnsafe = extraDefines.Contains(PlayFabEditorHelper.ENABLE_BETA_FETURES);

                foreach (PfDefineFlag.FlagCategory activeFlagCategory in Enum.GetValues(typeof(PfDefineFlag.FlagCategory)))
                {
                    if (activeFlagCategory == PfDefineFlag.FlagCategory.Other && !allowUnsafe)
                        continue;

                    using (var fwl = new FixedWidthLabel(activeFlagCategory.ToString())) { }

                    foreach (var eachDefinePair in allFlags)
                    {
                        PfDefineFlag eachFlag = eachDefinePair.Value;
                        if (eachFlag.Category == activeFlagCategory && (eachFlag.isSafe || allowUnsafe))
                            DisplayDefineToggle(eachFlag.Label + ": ", eachFlag.isInverted, eachFlag.Flag, ref curDefines, ref changedFlags);
                    }
                }

                if (changedFlags)
                {
                    PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, curDefines);
                    Debug.Log("Updating Defines: " + curDefines);
                    AssetDatabase.Refresh();
                }
            }
        }

        private static void DisplayDefineToggle(string label, bool invertDisplay, string displayedDefine, ref string curDefines, ref bool changedFlag)
        {
            bool flagSet, flagGet = curDefines.Contains(displayedDefine);
            using (var fwl = new FixedWidthLabel(label))
            {
                GUILayout.Space(LABEL_WIDTH - fwl.fieldWidth);
                flagSet = EditorGUILayout.Toggle(invertDisplay ? !flagGet : flagGet, PlayFabEditorHelper.uiStyle.GetStyle("Toggle"), GUILayout.MinHeight(25));
                if (invertDisplay)
                    flagSet = !flagSet;
            }
            changedFlag |= flagSet != flagGet;

            Sb.Length = 0;
            if (flagSet && !flagGet)
            {
                Sb.Append(curDefines);
                if (Sb.Length > 0)
                    Sb.Append(";");
                Sb.Append(displayedDefine);
                curDefines = Sb.ToString();
            }
            else if (!flagSet && flagGet)
            {
                Sb.Append(curDefines);
                Sb.Replace(displayedDefine, "").Replace(";;", ";");
                if (Sb.Length > 0 && Sb[0] == ';')
                    Sb.Remove(0, 1);
                if (Sb.Length > 0 && Sb[Sb.Length - 1] == ';')
                    Sb.Remove(Sb.Length - 1, 1);
                curDefines = Sb.ToString();
            }
        }

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
                    case SubMenuStates.ApiSettings:
                        DrawApiSubPanel();
                        break;
                    case SubMenuStates.TitleSettings:
                        DrawTitleSettingsSubPanel();
                        break;
                }
            }
            else
            {
                RegisterMenu();
            }
        }

        private static void DrawTitleSettingsSubPanel()
        {
            float labelWidth = 100;

            if (PlayFabEditorPrefsSO.Instance.StudioList != null && PlayFabEditorPrefsSO.Instance.StudioList.Count != StudioFoldOutStates.Count + 1)
            {
                StudioFoldOutStates.Clear();
                foreach (var studio in PlayFabEditorPrefsSO.Instance.StudioList)
                {
                    if (string.IsNullOrEmpty(studio.Id))
                        continue;
                    if (!StudioFoldOutStates.ContainsKey(studio.Id))
                        StudioFoldOutStates.Add(studio.Id, new StudioDisplaySet { Studio = studio });
                    foreach (var title in studio.Titles)
                        if (!StudioFoldOutStates[studio.Id].titleFoldOutStates.ContainsKey(title.Id))
                            StudioFoldOutStates[studio.Id].titleFoldOutStates.Add(title.Id, new TitleDisplaySet { Title = title });
                }
            }

            _titleScrollPos = GUILayout.BeginScrollView(_titleScrollPos, PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1"));

            using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
            {
                EditorGUILayout.LabelField("STUDIOS:", PlayFabEditorHelper.uiStyle.GetStyle("labelStyle"), GUILayout.Width(labelWidth));
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("REFRESH", PlayFabEditorHelper.uiStyle.GetStyle("Button")))
                    PlayFabEditorDataService.RefreshStudiosList();
            }

            foreach (var studio in StudioFoldOutStates)
            {
                var style = new GUIStyle(EditorStyles.foldout);
                if (studio.Value.isCollapsed)
                    style.fontStyle = FontStyle.Normal;

                studio.Value.isCollapsed = EditorGUI.Foldout(EditorGUILayout.GetControlRect(), studio.Value.isCollapsed, string.Format("{0} ({1})", studio.Value.Studio.Name, studio.Value.Studio.Titles.Length), true, PlayFabEditorHelper.uiStyle.GetStyle("foldOut_std"));
                if (studio.Value.isCollapsed)
                    continue;

                EditorGUI.indentLevel = 2;

                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                {
                    EditorGUILayout.LabelField("TITLES:", PlayFabEditorHelper.uiStyle.GetStyle("labelStyle"), GUILayout.Width(labelWidth));
                }
                GUILayout.Space(5);

                // draw title foldouts
                foreach (var title in studio.Value.titleFoldOutStates)
                {
                    title.Value.isCollapsed = EditorGUI.Foldout(EditorGUILayout.GetControlRect(), title.Value.isCollapsed, string.Format("{0} [{1}]", title.Value.Title.Name, title.Value.Title.Id), true, PlayFabEditorHelper.uiStyle.GetStyle("foldOut_std"));
                    if (title.Value.isCollapsed)
                        continue;

                    EditorGUI.indentLevel = 3;
                    using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                    {
                        EditorGUILayout.LabelField("SECRET KEY:", PlayFabEditorHelper.uiStyle.GetStyle("labelStyle"), GUILayout.Width(labelWidth));
                        EditorGUILayout.TextField("" + title.Value.Title.SecretKey);
                    }

                    using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                    {
                        EditorGUILayout.LabelField("URL:", PlayFabEditorHelper.uiStyle.GetStyle("labelStyle"), GUILayout.Width(labelWidth));
                        GUILayout.FlexibleSpace();
                        if (GUILayout.Button("VIEW IN GAME MANAGER", PlayFabEditorHelper.uiStyle.GetStyle("textButton")))
                            Application.OpenURL(title.Value.Title.GameManagerUrl);
                        GUILayout.FlexibleSpace();
                    }
                    EditorGUI.indentLevel = 2;
                }

                EditorGUI.indentLevel = 0;
            }
            GUILayout.EndScrollView();
        }

        private static Studio GetStudioForTitleId(string titleId)
        {
            if (PlayFabEditorPrefsSO.Instance.StudioList == null)
                return Studio.OVERRIDE;
            foreach (var eachStudio in PlayFabEditorPrefsSO.Instance.StudioList)
                if (eachStudio.Titles != null)
                    foreach (var eachTitle in eachStudio.Titles)
                        if (eachTitle.Id == titleId)
                            return eachStudio;
            return Studio.OVERRIDE;
        }

        private static void DrawStandardSettingsSubPanel()
        {
            float labelWidth = 160;

            using (new UnityVertical(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1"), GUILayout.ExpandWidth(true)))
            {
                var studio = GetStudioForTitleId(PlayFabEditorDataService.SharedSettings.TitleId);
                if (string.IsNullOrEmpty(studio.Id))
                    using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                        EditorGUILayout.LabelField("You are using a TitleId to which you are not a member. A title administrator can approve access for your account.", PlayFabEditorHelper.uiStyle.GetStyle("orTxt"));

                PlayFabGuiFieldHelper.SuperFancyDropdown(labelWidth, "STUDIO: ", studio, PlayFabEditorPrefsSO.Instance.StudioList, eachStudio => eachStudio.Name, OnStudioChange, PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear"));
                studio = GetStudioForTitleId(PlayFabEditorDataService.SharedSettings.TitleId); // This might have changed above, so refresh it

                if (string.IsNullOrEmpty(studio.Id))
                {
                    // Override studio lets you set your own titleId
                    using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                    {
                        EditorGUILayout.LabelField("TITLE ID: ", PlayFabEditorHelper.uiStyle.GetStyle("labelStyle"), GUILayout.Width(labelWidth));

                        var newTitleId = EditorGUILayout.TextField(PlayFabEditorDataService.SharedSettings.TitleId, PlayFabEditorHelper.uiStyle.GetStyle("TextField"), GUILayout.MinHeight(25));
                        if (newTitleId != PlayFabEditorDataService.SharedSettings.TitleId)
                            OnTitleIdChange(newTitleId);
                    }
                }
                else
                {
                    PlayFabGuiFieldHelper.SuperFancyDropdown(labelWidth, "TITLE ID: ", studio.GetTitle(PlayFabEditorDataService.SharedSettings.TitleId), studio.Titles, GetTitleDisplayString, OnTitleChange, PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear"));
                }

                DrawPfSharedSettingsOptions(labelWidth);
            }
        }

        private static string GetTitleDisplayString(Title title)
        {
            return string.Format("[{0}] {1}", title.Id, title.Name);
        }

        private static void DrawPfSharedSettingsOptions(float labelWidth)
        {
#if ENABLE_PLAYFABADMIN_API || ENABLE_PLAYFABSERVER_API || UNITY_EDITOR
            // Set the title secret key, if we're using the dropdown
            var studio = GetStudioForTitleId(PlayFabEditorDataService.SharedSettings.TitleId);
            var correctKey = studio.GetTitleSecretKey(PlayFabEditorDataService.SharedSettings.TitleId);
            var setKey = !string.IsNullOrEmpty(studio.Id) && !string.IsNullOrEmpty(correctKey);
            if (setKey)
                PlayFabEditorDataService.SharedSettings.DeveloperSecretKey = correctKey;

            using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
            {
                EditorGUILayout.LabelField("DEVELOPER SECRET KEY: ", PlayFabEditorHelper.uiStyle.GetStyle("labelStyle"), GUILayout.Width(labelWidth));
                using (new UnityGuiToggler(!setKey))
                    PlayFabEditorDataService.SharedSettings.DeveloperSecretKey = EditorGUILayout.TextField(PlayFabEditorDataService.SharedSettings.DeveloperSecretKey, PlayFabEditorHelper.uiStyle.GetStyle("TextField"), GUILayout.MinHeight(25));
            }
#endif
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
            _menu.RegisterMenuItem("STUDIOS", OnTitleSettingsClicked);
            _menu.RegisterMenuItem("API", OnApiSettingsClicked);
        }

        private static void OnApiSettingsClicked()
        {
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnSubmenuItemClicked, SubMenuStates.ApiSettings.ToString(), "" + (int)SubMenuStates.ApiSettings);
        }

        private static void OnStandardSetttingsClicked()
        {
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnSubmenuItemClicked, SubMenuStates.StandardSettings.ToString(), "" + (int)SubMenuStates.StandardSettings);
        }

        private static void OnTitleSettingsClicked()
        {
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnSubmenuItemClicked, SubMenuStates.TitleSettings.ToString(), "" + (int)SubMenuStates.TitleSettings);
        }

        private static void OnStudioChange(Studio newStudio)
        {
            var newTitleId = (newStudio.Titles == null || newStudio.Titles.Length == 0) ? "" : newStudio.Titles[0].Id;
            OnTitleIdChange(newTitleId);
        }

        private static void OnTitleChange(Title newTitle)
        {
            OnTitleIdChange(newTitle.Id);
        }

        private static void OnTitleIdChange(string newTitleId)
        {
            var studio = GetStudioForTitleId(newTitleId);
            PlayFabEditorPrefsSO.Instance.SelectedStudio = studio.Name;
            PlayFabEditorDataService.SharedSettings.TitleId = newTitleId;
#if ENABLE_PLAYFABADMIN_API || ENABLE_PLAYFABSERVER_API || UNITY_EDITOR
            PlayFabEditorDataService.SharedSettings.DeveloperSecretKey = studio.GetTitleSecretKey(newTitleId);
#endif
            PlayFabEditorPrefsSO.Instance.TitleDataCache.Clear();
            if (PlayFabEditorDataMenu.tdViewer != null)
                PlayFabEditorDataMenu.tdViewer.items.Clear();
            PlayFabEditorDataService.SaveEnvDetails();
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnSuccess);
        }
        #endregion
    }
}
