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

        // this gets called after the Base draw loop
        public void Draw()
        {
            using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
                EditorGUILayout.LabelField("TitleData provides Key-Value storage available to all API sets. TitleData is designed to store game-wide configuration data.", PlayFabEditorHelper.uiStyle.GetStyle("genTxt"));

            using (new UnityHorizontal())
            {
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("REFRESH", PlayFabEditorHelper.uiStyle.GetStyle("Button")))
                {
                    RefreshTitleData();
                }

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
                        var keyStyle = items[z].isDirty ? PlayFabEditorHelper.uiStyle.GetStyle("listKey_dirty") : PlayFabEditorHelper.uiStyle.GetStyle("listKey");
                        var valStyle = items[z].isDirty ? PlayFabEditorHelper.uiStyle.GetStyle("listValue_dirty") : PlayFabEditorHelper.uiStyle.GetStyle("listValue");

                        using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                        {
                            items[z].Key = EditorGUILayout.TextField(items[z].Key, keyStyle, GUILayout.Width(keyInputBoxWidth));

                            EditorGUILayout.LabelField(":", GUILayout.MaxWidth(10));
                            EditorGUILayout.LabelField("" + items[z].Value, valStyle, GUILayout.MaxWidth(valueInputBoxWidth), GUILayout.MaxHeight(25));

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
