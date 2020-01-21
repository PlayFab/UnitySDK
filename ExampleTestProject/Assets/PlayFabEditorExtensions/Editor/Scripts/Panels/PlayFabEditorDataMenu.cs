using UnityEditor;
using UnityEngine;

namespace PlayFab.PfEditor
{
    [InitializeOnLoad]
    public class PlayFabEditorDataMenu : UnityEditor.Editor
    {
        #region panel variables
        public static TitleDataViewer tdViewer;
        public static TitleInternalDataViewer tdInternalViewer;

        public static SubMenuComponent menu = null;

        public enum DataMenuStates { TitleData, TitleDataInternal }
        public static DataMenuStates currentState = DataMenuStates.TitleData;

        private static Vector2 scrollPos = Vector2.zero;

        #endregion

        #region draw calls
        public static void DrawDataPanel()
        {
            if (menu == null)
            {
                RegisterMenu();
                return;
            }

            menu.DrawMenu();
            switch ((DataMenuStates)PlayFabEditorPrefsSO.Instance.curSubMenuIdx)
            {
                case DataMenuStates.TitleData:
                    if (tdViewer == null)
                    {
                        tdViewer = CreateInstance<TitleDataViewer>();
                        tdViewer.RefreshTitleData();
                    }
                    scrollPos = GUILayout.BeginScrollView(scrollPos, PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1"));
                    tdViewer.Draw();
                    GUILayout.EndScrollView();
                    break;

                case DataMenuStates.TitleDataInternal:
                    if (tdInternalViewer == null)
                    {
                        tdInternalViewer = CreateInstance<TitleInternalDataViewer>();
                        tdInternalViewer.RefreshInternalTitleData();
                    }
                    scrollPos = GUILayout.BeginScrollView(scrollPos, PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1"));
                    tdInternalViewer.Draw();
                    GUILayout.EndScrollView();
                    break;

                default:
                    using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
                    {
                        EditorGUILayout.LabelField("Coming Soon!", PlayFabEditorHelper.uiStyle.GetStyle("titleLabel"), GUILayout.MinWidth(EditorGUIUtility.currentViewWidth));
                    }
                    break;
            }
        }
        #endregion

        #region unity loops
        static PlayFabEditorDataMenu()
        {
            if (!PlayFabEditor.IsEventHandlerRegistered(StateUpdateHandler))
            {
                PlayFabEditor.EdExStateUpdate += StateUpdateHandler;
            }

            RegisterMenu();
        }

        public void OnDestroy()
        {
            if (PlayFabEditor.IsEventHandlerRegistered(StateUpdateHandler))
            {
                PlayFabEditor.EdExStateUpdate -= StateUpdateHandler;
            }
        }
        #endregion

        #region menu and helper methods
        public static void RegisterMenu()
        {
            if (menu != null)
                return;

            menu = CreateInstance<SubMenuComponent>();
            menu.RegisterMenuItem("TITLE", OnTitleDataClicked);
            menu.RegisterMenuItem("INTERNAL", OnInternalTitleDataClicked);
        }

        public static void StateUpdateHandler(PlayFabEditor.EdExStates state, string status, string json)
        {
            switch (state)
            {
                case PlayFabEditor.EdExStates.OnMenuItemClicked:
                    break;
                case PlayFabEditor.EdExStates.OnLogout:
                    if (tdViewer != null)
                    {
                        tdViewer.items.Clear();
                    }
                    break;
            }
        }

        public static void OnTitleDataClicked()
        {
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnSubmenuItemClicked, DataMenuStates.TitleData.ToString(), "" + (int)DataMenuStates.TitleData);
        }

        public static void OnInternalTitleDataClicked()
        {
            PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnSubmenuItemClicked, DataMenuStates.TitleDataInternal.ToString(), "" + (int)DataMenuStates.TitleDataInternal);
        }
    }
    #endregion
}
