using PlayFab.PfEditor.EditorModels;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using System.IO;

namespace PlayFab.PfEditor
{
#if UNITY_5_3_OR_NEWER
    [CreateAssetMenu(fileName = "PlayFabEditorPrefsSO", menuName = "PlayFab/Make Prefs SO", order = 1)]
#endif
    public class PlayFabEditorPrefsSO : ScriptableObject
    {
        private static PlayFabEditorPrefsSO _instance;
        public static PlayFabEditorPrefsSO Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                var settingsList = Resources.LoadAll<PlayFabEditorPrefsSO>("PlayFabEditorPrefsSO");
                if (settingsList.Length == 1)
                    _instance = settingsList[0];
                if (_instance != null)
                    return _instance;

                _instance = CreateInstance<PlayFabEditorPrefsSO>();
                if (!Directory.Exists(Path.Combine(Application.dataPath, "PlayFabEditorExtensions/Editor/Resources")))
                    Directory.CreateDirectory(Path.Combine(Application.dataPath, "PlayFabEditorExtensions/Editor/Resources"));

                // TODO: we know the location of this file will be under  PlayFabEditorExtensions/Editor/ 
                // just need to pull that files path, and append /Resrouces/ and boom you have the below path.
                // consider moving this above the if directory exists so we can do the same logic beforehand.
                Directory.GetFiles(Application.dataPath, "PlayFabEditor.cs");

                AssetDatabase.CreateAsset(_instance, "Assets/PlayFabEditorExtensions/Editor/Resources/PlayFabEditorPrefsSO.asset");
                AssetDatabase.SaveAssets();
                Debug.LogWarning("Created missing PlayFabEditorPrefsSO file");
                return _instance;
            }
        }

        public static void Save()
        {
            EditorUtility.SetDirty(_instance);
            AssetDatabase.SaveAssets();
        }

        public string DevAccountEmail;
        public string DevAccountToken;

        public string AadAuthorization;

        public List<Studio> StudioList = null; // Null means not fetched, empty is a possible return result from GetStudios
        public string SelectedStudio;

        public readonly Dictionary<string, string> TitleDataCache = new Dictionary<string, string>();
        public readonly Dictionary<string, string> InternalTitleDataCache = new Dictionary<string, string>();

        public string SdkPath;
        public string EdExPath;
        public string LocalCloudScriptPath;

        private string _latestSdkVersion;
        private string _latestEdExVersion;
        private DateTime _lastSdkVersionCheck;
        private DateTime _lastEdExVersionCheck;
        public bool PanelIsShown;
        public string EdSet_latestSdkVersion { get { return _latestSdkVersion; } set { _latestSdkVersion = value; _lastSdkVersionCheck = DateTime.UtcNow; } }
        public string EdSet_latestEdExVersion { get { return _latestEdExVersion; } set { _latestEdExVersion = value; _lastEdExVersionCheck = DateTime.UtcNow; } }
        public DateTime EdSet_lastSdkVersionCheck { get { return _lastSdkVersionCheck; } }
        public DateTime EdSet_lastEdExVersionCheck { get { return _lastEdExVersionCheck; } }

        public int curMainMenuIdx;
        public int curSubMenuIdx;
    }
}
