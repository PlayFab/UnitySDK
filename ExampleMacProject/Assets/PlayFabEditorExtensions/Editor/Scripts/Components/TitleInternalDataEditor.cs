using System.ComponentModel.Design;
using UnityEditor;
using UnityEngine;

namespace PlayFab.PfEditor
{
    public class TitleInternalDataEditor : UnityEditor.EditorWindow
    {
        public string key = string.Empty;
        public string Value = string.Empty;
#if !UNITY_5_3_OR_NEWER
        public GUIContent titleContent;
#endif

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


            using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
            {
                GUILayout.FlexibleSpace();
                GUI.SetNextControlName("SaveButton");
                if (GUILayout.Button("Save", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MaxWidth(200)))
                {
                    for (int z = 0; z < PlayFabEditorDataMenu.tdInternalViewer.items.Count; z++)
                    {
                        if (PlayFabEditorDataMenu.tdInternalViewer.items[z].Key == key)
                        {
                            PlayFabEditorDataMenu.tdInternalViewer.items[z].Value = Value;
                            PlayFabEditorDataMenu.tdInternalViewer.items[z].isDirty = true;
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
                else if((Event.current.keyCode == KeyCode.Escape))
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
