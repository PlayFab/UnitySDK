using UnityEditor;
using UnityEngine;

namespace PlayFab.PfEditor
{
    public class PlayFabEditorHelpMenu : UnityEditor.Editor
    {
        public static float buttonWidth = 200;
        public static Vector2 scrollPos = Vector2.zero;
        // chnages in local
        private static int focusIndex;
        private static bool isShiftKeyPressed = false;
        private static float scrollFactor = 20f;

        public static void KeyboardEventHandler()
        {
            var e = Event.current;
            if (e.type == EventType.KeyUp && e.keyCode == KeyCode.UpArrow)
            {
                scrollPos = new Vector2(0, scrollPos.y - scrollFactor);

            }
            if (e.type == EventType.KeyUp && e.keyCode == KeyCode.DownArrow)
            {
                scrollPos = new Vector2(0, scrollPos.y + scrollFactor);
            }
        }
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
        private static void HelpInputHandler()
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
                            EditorGUI.FocusTextInControl("beginners_guide");
                            focusIndex = 1;
                            break;
                        case 1:
                            EditorGUI.FocusTextInControl("recipes");
                            focusIndex = 2;
                            break;
                        case 2:
                            EditorGUI.FocusTextInControl("tutorials");
                            focusIndex = 3;
                            break;
                        case 3:
                            EditorGUI.FocusTextInControl("api_reference");
                            focusIndex = 4;
                            break;
                        case 4:
                            EditorGUI.FocusTextInControl("ask_questions");
                            focusIndex = 5;
                            break;
                        case 5:
                            EditorGUI.FocusTextInControl("view_service_availability");
                            focusIndex = 0;
                            break;
                    }
                }
                else
                {
                    switch (focusIndex)
                    {
                        case 0:
                            EditorGUI.FocusTextInControl("view_service_availability");
                            focusIndex = 5;
                            break;
                        case 1:
                            EditorGUI.FocusTextInControl("beginners_guide");
                            focusIndex = 0;
                            break;
                        case 2:
                            EditorGUI.FocusTextInControl("recipes");
                            focusIndex = 1;
                            break;
                        case 3:
                            EditorGUI.FocusTextInControl("tutorials");
                            focusIndex = 2;
                            break;
                        case 4:
                            EditorGUI.FocusTextInControl("api_reference");
                            focusIndex = 3;
                            break;
                        case 5:
                            EditorGUI.FocusTextInControl("ask_questions");
                            focusIndex = 4;
                            break;
                    }
                }
            }
        }
        public static void DrawHelpPanel()
        {
            HelpInputHandler();
            KeyboardEventHandler();
            scrollPos = GUILayout.BeginScrollView(scrollPos, PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1"));
            buttonWidth = EditorGUIUtility.currentViewWidth > 400 ? EditorGUIUtility.currentViewWidth / 2 : 200;

            using (new UnityVertical())
            {
                EditorGUILayout.LabelField("LEARN PLAYFAB:", PlayFabEditorHelper.uiStyle.GetStyle("labelStyle"));

                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                {
                    GUILayout.FlexibleSpace();
                    GUI.SetNextControlName("beginners_guide");
                    if (GUILayout.Button("BEGINNERS GUIDE", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MinHeight(32), GUILayout.Width(buttonWidth)))
                    {
                        Application.OpenURL("https://docs.microsoft.com/en-us/gaming/playfab/index#pivot=documentation&panel=quickstarts");
                    }

                    GUILayout.FlexibleSpace();
                }

                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                {
                    GUILayout.FlexibleSpace();
                    GUI.SetNextControlName("recipes");
                    if (GUILayout.Button("RECIPES", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MinHeight(32), GUILayout.Width(buttonWidth)))
                    {
                        Application.OpenURL("https://docs.microsoft.com/en-us/gaming/playfab/resources/recipes-and-samples");
                    }

                    GUILayout.FlexibleSpace();
                }

                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                {
                    GUILayout.FlexibleSpace();
                    GUI.SetNextControlName("tutorials");
                    if (GUILayout.Button("TUTORIALS", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MinHeight(32), GUILayout.Width(buttonWidth)))
                    {
                        Application.OpenURL("https://docs.microsoft.com/en-us/gaming/playfab/features/commerce/economy/tutorials");
                    }

                    GUILayout.FlexibleSpace();
                }

                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                {
                    GUILayout.FlexibleSpace();
                    GUI.SetNextControlName("api_reference");
                    if (GUILayout.Button("API REFERENCE", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MinHeight(32), GUILayout.Width(buttonWidth)))
                    {
                        Application.OpenURL("https://docs.microsoft.com/en-us/gaming/playfab/api-references/");
                    }

                    GUILayout.FlexibleSpace();
                }
            }

            using (new UnityVertical())
            {
                EditorGUILayout.LabelField("TROUBLESHOOTING:", PlayFabEditorHelper.uiStyle.GetStyle("labelStyle"));

                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                {
                    GUILayout.FlexibleSpace();
                    GUI.SetNextControlName("ask_questions");
                    if (GUILayout.Button("ASK QUESTIONS", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MinHeight(32), GUILayout.Width(buttonWidth)))
                    {
                        Application.OpenURL("https://community.playfab.com/index.html");
                    }

                    GUILayout.FlexibleSpace();
                }

                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                {
                    GUILayout.FlexibleSpace();
                    GUI.SetNextControlName("view_service_availability");
                    if (GUILayout.Button("VIEW SERVICE AVAILABILITY", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MinHeight(32), GUILayout.Width(buttonWidth)))
                    {
                        Application.OpenURL("http://status.playfab.com/");
                    }

                    GUILayout.FlexibleSpace();
                }
            }
            GUILayout.EndScrollView();
        }
    }
}
