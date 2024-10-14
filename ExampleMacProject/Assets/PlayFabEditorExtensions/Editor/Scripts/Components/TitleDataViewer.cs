using PlayFab.PfEditor.EditorModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PlayFab.PfEditor
{
    // TODO: Clean up the copy paste between this and TitleInternalDataViewer
    public class TitleDataViewer : UnityEditor.Editor
    {
        public readonly List<KvpItem> items = new List<KvpItem>();
        public static TitleDataEditor tdEditor;
        public Vector2 scrollPos = Vector2.zero;
        private bool showSave = false;
        private static int focusIndex;
        private static bool isShiftKeyPressed = false;


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
        private static void titleHandler()
        {
            var e = Event.current;
            shiftKeyHandler();
            if (e.type == EventType.KeyUp && e.keyCode == KeyCode.Tab)
            {
                if (!isShiftKeyPressed)
                {
                    switch (focusIndex)
                    {
                        case 0:
                            EditorGUI.FocusTextInControl("refresh");
                            focusIndex = 1;
                            break;
                        case 1:
                            EditorGUI.FocusTextInControl("add");
                            focusIndex = 2;
                            break;
                        case 2:
                            EditorGUI.FocusTextInControl("new_value_text_field");
                            focusIndex = 3;
                            break;
                        case 3:
                            EditorGUI.FocusTextInControl("edit");
                            focusIndex = 4;
                            break;
                        case 4:
                            EditorGUI.FocusTextInControl("clear");
                            focusIndex = 5;
                            break;
                        case 5:
                            EditorGUI.FocusTextInControl("save");
                            focusIndex = 6;
                            break;
                        case 6:
                            EditorGUI.FocusTextInControl("refresh");
                            focusIndex = 0;
                            break;

                    }
                }
                else
                {
                    switch (focusIndex)
                    {
                        case 0:
                            GUI.FocusControl("save");
                            focusIndex = 1;
                            break;
                        case 1:
                            GUI.FocusControl("clear");
                            focusIndex = 2;
                            break;
                        case 2:
                            GUI.FocusControl("edit");
                            focusIndex = 3;
                            break;
                        case 3:
                            EditorGUI.FocusTextInControl("new_value_text_field");
                            focusIndex = 4;
                            break;
                        case 4:
                            GUI.FocusControl("add");
                            focusIndex = 5;
                            break;
                        case 5:
                            EditorGUI.FocusTextInControl("refresh");
                            focusIndex = 6;
                            break;
                        case 6:
                            GUI.FocusControl("save");
                            focusIndex = 0;
                            break;

                    }
                }
            }
        }
        // this gets called after the Base draw loop
        public void Draw()
        {
            titleHandler();
            using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
                EditorGUILayout.LabelField("TitleData provides Key-Value storage available to all API sets. TitleData is designed to store game-wide configuration data.", PlayFabEditorHelper.uiStyle.GetStyle("genTxt"));

            using (new UnityHorizontal())
            {
                GUILayout.FlexibleSpace();
                GUI.SetNextControlName("refresh");
                if (GUILayout.Button("REFRESH", PlayFabEditorHelper.uiStyle.GetStyle("Button")))
                {
                    RefreshTitleData();
                }
                GUI.SetNextControlName("add");
                if (GUILayout.Button("+", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MaxWidth(25)))
                {
                    AddRecord();
                }
            }

            if (items != null && items.Count > 0)
            {
                scrollPos = GUILayout.BeginScrollView(scrollPos, PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1"));
                var keyInputBoxWidth = EditorGUIUtility.currentViewWidth > 200 ? 170 : (EditorGUIUtility.currentViewWidth - 100) / 2;
                var valueInputBoxWidth = EditorGUIUtility.currentViewWidth > 200 ? EditorGUIUtility.currentViewWidth - 290 : (EditorGUIUtility.currentViewWidth - 100) / 2;

                for (var z = 0; z < items.Count; z++)
                {
                    items[z].DataEditedCheck();
                    if (items[z].isDirty)
                    {
                        showSave = true;
                    }

                    if (items[z].Value != null)
                    {
                        var keyStyle = items[z].isDirty ? PlayFabEditorHelper.uiStyle.GetStyle("TextField") : PlayFabEditorHelper.uiStyle.GetStyle("listKey");
                        var valStyle = items[z].isDirty ? PlayFabEditorHelper.uiStyle.GetStyle("TextField") : PlayFabEditorHelper.uiStyle.GetStyle("listValue");

                        using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                        {
                            GUI.SetNextControlName("new_value_text_field");
                            items[z].Key = EditorGUILayout.TextField(items[z].Key, keyStyle, GUILayout.Width(keyInputBoxWidth), GUILayout.MaxHeight(20));

                            EditorGUILayout.LabelField(":", GUILayout.MaxWidth(10));
                            EditorGUILayout.LabelField("" + items[z].Value, valStyle, GUILayout.MaxWidth(valueInputBoxWidth), GUILayout.MaxHeight(20));
                            GUI.SetNextControlName("edit");
                            if (GUILayout.Button("EDIT", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MaxHeight(19), GUILayout.MinWidth(35)))
                            {
                                if (tdEditor == null)
                                {
                                    tdEditor = EditorWindow.GetWindow<TitleDataEditor>();
                                    tdEditor.titleContent = new GUIContent("Title Data");
                                    tdEditor.minSize = new Vector2(300, 400);
                                }

                                tdEditor.LoadData(items[z].Key, items[z].Value);
                                tdEditor.Show();
                            }
                            GUI.SetNextControlName("clear");

                            if (GUILayout.Button("X", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MaxHeight(19), GUILayout.MinWidth(20)))
                            {
                                items[z].isDirty = true;
                                items[z].Value = null;
                            }
                        }
                    }
                }

                GUILayout.EndScrollView();

                if (showSave)
                {
                    using (new UnityHorizontal())
                    {
                        GUILayout.FlexibleSpace();
                        GUI.SetNextControlName("save");
                        if (GUILayout.Button("SAVE", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MaxWidth(200)))
                        {
                            SaveRecords();
                        }
                        GUILayout.FlexibleSpace();
                    }
                }
            }
        }

        private void AddRecord()
        {
            //GUI.SetNextControlName("new_value_text_field");
            items.Add(new KvpItem("", "NewValue") { isDirty = true });
        }

        public void RefreshTitleData()
        {
            Action<PlayFab.PfEditor.EditorModels.GetTitleDataResult> dataRequest = (result) =>
            {
                items.Clear();
                showSave = false;
                foreach (var kvp in result.Data)
                items.Add(new KvpItem(kvp.Key, kvp.Value));

                PlayFabEditorPrefsSO.Instance.TitleDataCache.Clear();
                foreach (var pair in result.Data)
                    PlayFabEditorPrefsSO.Instance.TitleDataCache.Add(pair.Key, pair.Value);
                PlayFabEditorDataService.SaveEnvDetails();
            };
           
            PlayFabEditorApi.GetTitleData(dataRequest, PlayFabEditorHelper.SharedErrorCallback);
        }

        private void SaveRecords()
        {
            //reset dirty status.
            showSave = false;
            Dictionary<string, string> dirtyItems = new Dictionary<string, string>();
            foreach (var item in items)
                if (item.isDirty)
                    dirtyItems.Add(item.Key, item.Value);

            if (dirtyItems.Count > 0)
            {
                var nextSeconds = 1f;
                foreach (var di in dirtyItems)
                {
                    EditorCoroutine.Start(SaveItem(di, nextSeconds));
                    nextSeconds += 1f;
                }

                foreach (var item in items)
                    item.CleanItem();
            }
        }

        private IEnumerator SaveItem(KeyValuePair<string, string> dirtyItem, float seconds)
        {
            yield return new EditorCoroutine.EditorWaitForSeconds(seconds);
            //Debug.LogFormat("{0} - Co-Start: {1}", dirtyItem.Key, seconds);
            var itemToUpdateDic = new Dictionary<string, string> { { dirtyItem.Key, dirtyItem.Value } };
            PlayFabEditorApi.SetTitleData(itemToUpdateDic, null, PlayFabEditorHelper.SharedErrorCallback);
        }
    }
}
