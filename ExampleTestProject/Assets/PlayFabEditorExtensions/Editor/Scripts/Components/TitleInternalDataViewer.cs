using PlayFab.PfEditor.EditorModels;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PlayFab.PfEditor
{
    // TODO: Clean up the copy paste between this and TitleDataViewer
    public class TitleInternalDataViewer : UnityEditor.Editor
    {
        public readonly List<KvpItem> items = new List<KvpItem>();
        public static TitleInternalDataEditor tdEditor;
        public Vector2 scrollPos = Vector2.zero;
        private bool showSave = false;

        // this gets called after the Base draw loop
        public void Draw()
        {
            using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
                EditorGUILayout.LabelField("Internal TitleData provides Key-Value storage available only to Admin & Server API sets. This is useful for storing configuration data that should be hidden from players.", PlayFabEditorHelper.uiStyle.GetStyle("genTxt"));

            using (new UnityHorizontal())
            {
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("REFRESH", PlayFabEditorHelper.uiStyle.GetStyle("Button")))
                {
                    RefreshInternalTitleData();
                }

                if (GUILayout.Button("+", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MaxWidth(25)))
                {
                    AddRecord();
                }
            }

            if (items.Count > 0)
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
                        var keyStyle = items[z].isDirty ? PlayFabEditorHelper.uiStyle.GetStyle("TextField") : PlayFabEditorHelper.uiStyle.GetStyle("TextField");
                        var valStyle = items[z].isDirty ? PlayFabEditorHelper.uiStyle.GetStyle("TextField") : PlayFabEditorHelper.uiStyle.GetStyle("TextField");

                        using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                        {
                            items[z].Key = EditorGUILayout.TextField(items[z].Key, keyStyle, GUILayout.Width(keyInputBoxWidth), GUILayout.MaxHeight(20));

                            EditorGUILayout.LabelField(":", GUILayout.MaxWidth(10));
                            EditorGUILayout.LabelField("" + items[z].Value, valStyle, GUILayout.MaxWidth(valueInputBoxWidth), GUILayout.MaxHeight(20));

                            if (GUILayout.Button("EDIT", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MaxHeight(19), GUILayout.MinWidth(35)))
                            {
                                if (tdEditor == null)
                                {
                                    tdEditor = EditorWindow.GetWindow<TitleInternalDataEditor>();
                                    tdEditor.titleContent = new GUIContent("Internal Title Data");
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

        public void AddRecord()
        {
            items.Add(new KvpItem("", "NewValue") { isDirty = true });
        }

        public void RefreshInternalTitleData()
        {
            Action<PlayFab.PfEditor.EditorModels.GetTitleDataResult> cb = (result) =>
            {
                items.Clear();
                showSave = false;
                foreach (var kvp in result.Data)
                {
                    items.Add(new KvpItem(kvp.Key, kvp.Value));
                }

                PlayFabEditorPrefsSO.Instance.InternalTitleDataCache.Clear();
                foreach (var pair in result.Data)
                    PlayFabEditorPrefsSO.Instance.InternalTitleDataCache.Add(pair.Key, pair.Value);
                PlayFabEditorDataService.SaveEnvDetails();
            };

            PlayFabEditorApi.GetTitleInternalData(cb, PlayFabEditorHelper.SharedErrorCallback);
        }

        public void SaveRecords()
        {
            //reset dirty status.
            showSave = false;
            Dictionary<string, string> dirtyItems = new Dictionary<string, string>();
            foreach (var item in items)
                if (item.isDirty)
                    dirtyItems.Add(item.Key, item.Value);

            if (dirtyItems.Count > 0)
            {
                PlayFabEditorApi.SetTitleInternalData(dirtyItems, (result) =>
                {
                    foreach (var item in items)
                    {
                        item.CleanItem();
                    }
                }, PlayFabEditorHelper.SharedErrorCallback);
            }
        }
    }
}
