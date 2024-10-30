using UnityEditor;
using UnityEngine;

namespace PlayFab.PfEditor
{
    public class TitleDataEditor : UnityEditor.EditorWindow
    {
#if !UNITY_5_3_OR_NEWER
        public GUIContent titleContent;
#endif

        public string key = string.Empty;
        public string Value = string.Empty;
        public Vector2 scrollPos = Vector2.zero;

        void OnGUI()
        {
            // The actual window code goes here
            using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
            {
                EditorGUILayout.LabelField(string.Format("Editing: {0}", key), PlayFabEditorHelper.uiStyle.GetStyle("orTitle"), GUILayout.MinWidth(EditorGUIUtility.currentViewWidth));
            }
            scrollPos = GUILayout.BeginScrollView(scrollPos, PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1"));
            Value = EditorGUILayout.TextArea(Value, PlayFabEditorHelper.uiStyle.GetStyle("editTxt"));
            GUI.SetNextControlName("TextArea");
            GUI.skin.settings.cursorColor = Color.black;
            GUILayout.EndScrollView();

            using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
            {
                GUILayout.FlexibleSpace();
                GUI.SetNextControlName("SaveButton");
                if (GUILayout.Button("SAVE", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MaxWidth(200)))
                {
                    for (int z = 0; z < PlayFabEditorDataMenu.tdViewer.items.Count; z++)
                    {
                        if (PlayFabEditorDataMenu.tdViewer.items[z].Key == key)
                        {
                            PlayFabEditorDataMenu.tdViewer.items[z].Value = Value;
                            PlayFabEditorDataMenu.tdViewer.items[z].isDirty = true;
                        }
                    }
                    GUI.FocusControl("SaveButton");
                    Close();
                }
                GUILayout.FlexibleSpace();
            }

            Repaint();
            HandleFocusTrap();
        }
        
        void HandleFocusTrap()
        {
            if (Event.current.type == EventType.KeyDown)
            {
                if (Event.current.control && Event.current.keyCode == KeyCode.Tab)
                {
                    if (GUI.GetNameOfFocusedControl() == "SaveButton")
                    {
                        GUI.FocusControl("TextArea");
                        Event.current.Use();
                    }
                    else
                    {
                        GUI.FocusControl("SaveButton");
                        Event.current.Use();
                    }
                }
                else if ((Event.current.keyCode == KeyCode.Escape))
                {
                    Close();
                    GUI.FocusControl("refresh");
                }
            }
        }

        public void LoadData(string k, string v)
        {
            key = k;
            Value = v;
        }
    }
}
