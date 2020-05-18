using PlayFab.PfEditor.EditorModels;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace PlayFab.PfEditor
{
    public class PlayFabEditorToolsMenu : UnityEditor.Editor
    {
        public static float buttonWidth = 200;
        public static Vector2 scrollPos = Vector2.zero;

        public static void DrawToolsPanel()
        {
            scrollPos = GUILayout.BeginScrollView(scrollPos, PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1"));
            buttonWidth = EditorGUIUtility.currentViewWidth > 400 ? EditorGUIUtility.currentViewWidth / 2 : 200;

            using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
            {
                EditorGUILayout.LabelField("CLOUD SCRIPT:", PlayFabEditorHelper.uiStyle.GetStyle("labelStyle"));
                GUILayout.Space(10);
                if (GUILayout.Button("IMPORT", PlayFabEditorHelper.uiStyle.GetStyle("textButton"), GUILayout.MinHeight(30)))
                {
                    ImportCloudScript();
                }
                GUILayout.Space(10);
                if (File.Exists(PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath))
                {
                    if (GUILayout.Button("REMOVE", PlayFabEditorHelper.uiStyle.GetStyle("textButton"), GUILayout.MinHeight(30)))
                    {
                        PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath = string.Empty;
                        PlayFabEditorDataService.SaveEnvDetails();
                    }
                    GUILayout.Space(10);
                    if (GUILayout.Button("EDIT", PlayFabEditorHelper.uiStyle.GetStyle("textButton"), GUILayout.MinHeight(30)))
                    {
                        EditorUtility.OpenWithDefaultApp(PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath);
                    }
                }
            }

            if (File.Exists(PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath))
            {
                var path = File.Exists(PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath) ? PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath : PlayFabEditorHelper.CLOUDSCRIPT_PATH;
                var shortPath = "..." + path.Substring(path.LastIndexOf('/'));

                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                {
                    GUILayout.FlexibleSpace();

                    if (GUILayout.Button(shortPath, PlayFabEditorHelper.uiStyle.GetStyle("textButton"), GUILayout.MinWidth(110), GUILayout.MinHeight(20)))
                    {
                        EditorUtility.RevealInFinder(path);
                    }
                    //                            GUILayout.Space(10);
                    //                            if (GUILayout.Button("EDIT LOCALLY", PlayFabEditorHelper.uiStyle.GetStyle("textButton"), GUILayout.MinWidth(90), GUILayout.MinHeight(20)))
                    //                            {
                    //                                EditorUtility.OpenWithDefaultApp(path);
                    //                            }
                    GUILayout.FlexibleSpace();
                }

                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                {
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("SAVE TO PLAYFAB", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MinHeight(32), GUILayout.Width(buttonWidth)))
                    {
                        if (EditorUtility.DisplayDialog("Deployment Confirmation", "This action will upload your local Cloud Script changes to PlayFab?", "Continue", "Cancel"))
                        {
                            BeginCloudScriptUpload();
                        }
                    }
                    GUILayout.FlexibleSpace();
                }
            }
            else
            {
                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                {
                    GUILayout.FlexibleSpace();
                    EditorGUILayout.LabelField("No Cloud Script files added. Import your file to get started.", PlayFabEditorHelper.uiStyle.GetStyle("orTxt"));
                    GUILayout.FlexibleSpace();
                }
            }

            GUILayout.EndScrollView();
        }

        private static void ImportCloudScript()
        {
            var dialogResponse = EditorUtility.DisplayDialogComplex("Selcet an Import Option", "What Cloud Script file do you want to import?", "Use my latest PlayFab revision", "Cancel", "Use my local file");
            switch (dialogResponse)
            {
                case 0:
                    // use PlayFab
                    GetCloudScriptRevision();
                    break;
                case 1:
                    // cancel
                    return;
                case 2:
                    //use local
                    SelectLocalFile();
                    break;
            }
        }

        private static void GetCloudScriptRevision()
        {
            // empty request object gets latest versions
            PlayFabEditorApi.GetCloudScriptRevision(new EditorModels.GetCloudScriptRevisionRequest(), (GetCloudScriptRevisionResult result) =>
            {
                var csPath = PlayFabEditorHelper.CLOUDSCRIPT_PATH;
                var location = Path.GetDirectoryName(csPath);
                try
                {
                    if (!Directory.Exists(location))
                        Directory.CreateDirectory(location);
                    if (!File.Exists(csPath))
                        using (var newfile = File.Create(csPath)) { }
                    File.WriteAllText(csPath, result.Files[0].FileContents);
                    Debug.Log("CloudScript uploaded successfully!");
                    PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath = csPath;
                    PlayFabEditorDataService.SaveEnvDetails();
                    AssetDatabase.Refresh();
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                    // PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnError, ex.Message);
                    return;
                }
            }, PlayFabEditorHelper.SharedErrorCallback);
        }

        private static void SelectLocalFile()
        {
            var starterPath = File.Exists(PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath) ? Application.dataPath : PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath;
            var cloudScriptPath = string.Empty;
            cloudScriptPath = EditorUtility.OpenFilePanel("Select your Cloud Script file", starterPath, "js");

            if (!string.IsNullOrEmpty(cloudScriptPath))
            {
                PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath = cloudScriptPath;
                PlayFabEditorDataService.SaveEnvDetails();
            }
        }

        private static void BeginCloudScriptUpload()
        {
            var filePath = File.Exists(PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath) ? PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath : PlayFabEditorHelper.CLOUDSCRIPT_PATH;

            if (!File.Exists(PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath) && !File.Exists(PlayFabEditorHelper.CLOUDSCRIPT_PATH))
            {
                PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnError, "Cloud Script Upload Failed: null or corrupt file at path(" + filePath + ").");
                return;
            }

            var s = File.OpenText(filePath);
            var contents = s.ReadToEnd();
            s.Close();

            var request = new UpdateCloudScriptRequest();
            request.Publish = EditorUtility.DisplayDialog("Deployment Options", "Do you want to make this Cloud Script live after uploading?", "Yes", "No");
            request.Files = new List<CloudScriptFile>(){
                new CloudScriptFile() {
                    Filename = PlayFabEditorHelper.CLOUDSCRIPT_FILENAME,
                    FileContents = contents
                }
            };

            PlayFabEditorApi.UpdateCloudScript(request, (UpdateCloudScriptResult result) =>
            {
                PlayFabEditorPrefsSO.Instance.LocalCloudScriptPath = filePath;
                PlayFabEditorDataService.SaveEnvDetails();

                Debug.Log("CloudScript uploaded successfully!");

            }, PlayFabEditorHelper.SharedErrorCallback);
        }
    }
}
