using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace PlayFab.PfEditor
{
    public class PlayFabEditorSDKTools : UnityEditor.Editor
    {
        private const int buttonWidth = 150;
        public static bool IsInstalled { get { return GetPlayFabSettings() != null; } }

        private static Type playFabSettingsType = null;
        private static string installedSdkVersion = string.Empty;
        private static string latestSdkVersion = string.Empty;
        private static UnityEngine.Object sdkFolder;
        private static UnityEngine.Object _previousSdkFolderPath;
        private static bool isObjectFieldActive;
        private static bool isInitialized; //used to check once, gets reset after each compile;
        public static bool isSdkSupported = true;

        public static void DrawSdkPanel()
        {
            if (!isInitialized)
            {
                //SDK is installed.
                CheckSdkVersion();
                isInitialized = true;
                GetLatestSdkVersion();
                sdkFolder = FindSdkAsset();

                if (sdkFolder != null)
                {
                    PlayFabEditorPrefsSO.Instance.SdkPath = AssetDatabase.GetAssetPath(sdkFolder);
                    PlayFabEditorDataService.SaveEnvDetails();
                }
            }

            if (IsInstalled)
                ShowSdkInstalledMenu();
            else
                ShowSdkNotInstalledMenu();
        }

        private static void ShowSdkInstalledMenu()
        {
            isObjectFieldActive = sdkFolder == null;

            if (_previousSdkFolderPath != sdkFolder)
            {
                // something changed, better save the result.
                _previousSdkFolderPath = sdkFolder;

                PlayFabEditorPrefsSO.Instance.SdkPath = (AssetDatabase.GetAssetPath(sdkFolder));
                PlayFabEditorDataService.SaveEnvDetails();

                isObjectFieldActive = false;
            }

            var labelStyle = new GUIStyle(PlayFabEditorHelper.uiStyle.GetStyle("titleLabel"));
            using (new UnityVertical(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
            {
                EditorGUILayout.LabelField(string.Format("SDK {0} is installed", string.IsNullOrEmpty(installedSdkVersion) ? "Unknown" : installedSdkVersion),
                    labelStyle, GUILayout.MinWidth(EditorGUIUtility.currentViewWidth));

                if (!isObjectFieldActive)
                {
                    GUI.enabled = false;
                }
                else
                {
                    EditorGUILayout.LabelField(
                        "An SDK was detected, but we were unable to find the directory. Drag-and-drop the top-level PlayFab SDK folder below.",
                        PlayFabEditorHelper.uiStyle.GetStyle("orTxt"));
                }

                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                {
                    GUILayout.FlexibleSpace();
                    sdkFolder = EditorGUILayout.ObjectField(sdkFolder, typeof(UnityEngine.Object), false, GUILayout.MaxWidth(200));
                    GUILayout.FlexibleSpace();
                }

                if (!isObjectFieldActive)
                {
                    // this is a hack to prevent our "block while loading technique" from breaking up at this point.
                    GUI.enabled = !EditorApplication.isCompiling && PlayFabEditor.blockingRequests.Count == 0;
                }

                if (isSdkSupported && sdkFolder != null)
                {
                    using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                    {

                        GUILayout.FlexibleSpace();

                        if (GUILayout.Button("REMOVE SDK", PlayFabEditorHelper.uiStyle.GetStyle("textButton"), GUILayout.MinHeight(32), GUILayout.MinWidth(200)))
                        {
                            RemoveSdk();
                        }

                        GUILayout.FlexibleSpace();
                    }
                }

            }

            if (sdkFolder != null)
            {
                using (new UnityVertical(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
                {
                    isSdkSupported = false;
                    string[] versionNumber = !string.IsNullOrEmpty(installedSdkVersion) ? installedSdkVersion.Split('.') : new string[0];

                    var numerical = 0;
                    if (string.IsNullOrEmpty(installedSdkVersion) || versionNumber == null || versionNumber.Length == 0 ||
                        (versionNumber.Length > 0 && int.TryParse(versionNumber[0], out numerical) && numerical < 2))
                    {
                        //older version of the SDK
                        using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                        {
                            EditorGUILayout.LabelField("Most of the Editor Extensions depend on SDK versions >2.0. Consider upgrading to the get most features.", PlayFabEditorHelper.uiStyle.GetStyle("orTxt"));
                        }

                        using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                        {
                            GUILayout.FlexibleSpace();
                            if (GUILayout.Button("READ THE UPGRADE GUIDE", PlayFabEditorHelper.uiStyle.GetStyle("textButton"), GUILayout.MinHeight(32)))
                            {
                                Application.OpenURL("https://github.com/PlayFab/UnitySDK/blob/master/UPGRADE.md");
                            }
                            GUILayout.FlexibleSpace();
                        }
                    }
                    else if (numerical >= 2)
                    {
                        isSdkSupported = true;
                    }

                    using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleClear")))
                    {
                        if (ShowSDKUpgrade() && isSdkSupported)
                        {
                            GUILayout.FlexibleSpace();
                            if (GUILayout.Button("Upgrade to " + latestSdkVersion, PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MinHeight(32)))
                            {
                                UpgradeSdk();
                            }
                            GUILayout.FlexibleSpace();
                        }
                        else if (isSdkSupported)
                        {
                            GUILayout.FlexibleSpace();
                            EditorGUILayout.LabelField("You have the latest SDK!", labelStyle, GUILayout.MinHeight(32));
                            GUILayout.FlexibleSpace();
                        }
                    }
                }
            }

            if (isSdkSupported && string.IsNullOrEmpty(PlayFabEditorDataService.SharedSettings.TitleId))
            {
                using (new UnityVertical(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
                {
                    EditorGUILayout.LabelField("Before making PlayFab API calls, the SDK must be configured to your PlayFab Title.", PlayFabEditorHelper.uiStyle.GetStyle("orTxt"));
                    using (new UnityHorizontal())
                    {
                        GUILayout.FlexibleSpace();
                        if (GUILayout.Button("SET MY TITLE", PlayFabEditorHelper.uiStyle.GetStyle("textButton")))
                        {
                            PlayFabEditorMenu.OnSettingsClicked();
                        }
                        GUILayout.FlexibleSpace();
                    }
                }
            }

            using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
            {
                GUILayout.FlexibleSpace();

                if (GUILayout.Button("VIEW RELEASE NOTES", PlayFabEditorHelper.uiStyle.GetStyle("textButton"), GUILayout.MinHeight(32), GUILayout.MinWidth(200)))
                {
                    Application.OpenURL("https://docs.microsoft.com/en-us/gaming/playfab/release-notes/");
                }

                GUILayout.FlexibleSpace();
            }
        }

        private static void ShowSdkNotInstalledMenu()
        {
            using (new UnityVertical(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
            {
                var labelStyle = new GUIStyle(PlayFabEditorHelper.uiStyle.GetStyle("titleLabel"));

                EditorGUILayout.LabelField("No SDK is installed.", labelStyle, GUILayout.MinWidth(EditorGUIUtility.currentViewWidth));
                GUILayout.Space(20);

                using (new UnityHorizontal(PlayFabEditorHelper.uiStyle.GetStyle("gpStyleGray1")))
                {
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("Refresh", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MaxWidth(buttonWidth), GUILayout.MinHeight(32)))
                        playFabSettingsType = null;
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("Install PlayFab SDK", PlayFabEditorHelper.uiStyle.GetStyle("Button"), GUILayout.MaxWidth(buttonWidth), GUILayout.MinHeight(32)))
                        ImportLatestSDK();

                    GUILayout.FlexibleSpace();
                }
            }
        }

        public static void ImportLatestSDK()
        {
            PlayFabEditorHttp.MakeDownloadCall("https://aka.ms/PlayFabUnitySdk", (fileName) =>
            {
                Debug.Log("PlayFab SDK Install: Complete");
                AssetDatabase.ImportPackage(fileName, false);

                // attempts to re-import any changed assets (which ImportPackage doesn't implicitly do)
                AssetDatabase.Refresh();

                PlayFabEditorPrefsSO.Instance.SdkPath = PlayFabEditorHelper.DEFAULT_SDK_LOCATION;
                PlayFabEditorDataService.SaveEnvDetails();

            });
        }

        public static Type GetPlayFabSettings()
        {
            if (playFabSettingsType == typeof(object))
                return null; // Sentinel value to indicate that PlayFabSettings doesn't exist
            if (playFabSettingsType != null)
                return playFabSettingsType;

            playFabSettingsType = typeof(object); // Sentinel value to indicate that PlayFabSettings doesn't exist
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in allAssemblies)
            {
                Type[] assemblyTypes;
                try
                {
                    assemblyTypes = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException e)
                {
                    assemblyTypes = e.Types;
                }

                foreach (var eachType in assemblyTypes)
                    if (eachType != null)
                        if (eachType.Name == PlayFabEditorHelper.PLAYFAB_SETTINGS_TYPENAME)
                            playFabSettingsType = eachType;
            }
	    
            //if (playFabSettingsType == typeof(object))
            //    Debug.LogWarning("Should not have gotten here: "  + allAssemblies.Length);
            //else
            //    Debug.Log("Found Settings: " + allAssemblies.Length + ", " + playFabSettingsType.Assembly.FullName);
            return playFabSettingsType == typeof(object) ? null : playFabSettingsType;
        }

        private static void CheckSdkVersion()
        {
            if (!string.IsNullOrEmpty(installedSdkVersion))
                return;

            var types = new List<Type>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    foreach (var type in assembly.GetTypes())
                        if (type.Name == "PlayFabVersion" || type.Name == PlayFabEditorHelper.PLAYFAB_SETTINGS_TYPENAME)
                            types.Add(type);
                }
                catch (ReflectionTypeLoadException)
                {
                    // For this failure, silently skip this assembly unless we have some expectation that it contains PlayFab
                    if (assembly.FullName.StartsWith("Assembly-CSharp")) // The standard "source-code in unity proj" assembly name
                        Debug.LogWarning("PlayFab EdEx Error, failed to access the main CSharp assembly that probably contains PlayFab. Please report this on the PlayFab Forums");
                    continue;
                }
            }

            foreach (var type in types)
            {
                foreach (var property in type.GetProperties())
                    if (property.Name == "SdkVersion" || property.Name == "SdkRevision")
                        installedSdkVersion += property.GetValue(property, null).ToString();
                foreach (var field in type.GetFields())
                    if (field.Name == "SdkVersion" || field.Name == "SdkRevision")
                        installedSdkVersion += field.GetValue(field).ToString();
            }
        }

        private static UnityEngine.Object FindSdkAsset()
        {
            UnityEngine.Object sdkAsset = null;

            // look in editor prefs
            if (PlayFabEditorPrefsSO.Instance.SdkPath != null)
            {
                sdkAsset = AssetDatabase.LoadAssetAtPath(PlayFabEditorPrefsSO.Instance.SdkPath, typeof(UnityEngine.Object));
            }
            if (sdkAsset != null)
                return sdkAsset;

            sdkAsset = AssetDatabase.LoadAssetAtPath(PlayFabEditorHelper.DEFAULT_SDK_LOCATION, typeof(UnityEngine.Object));
            if (sdkAsset != null)
                return sdkAsset;

            var fileList = Directory.GetDirectories(Application.dataPath, "*PlayFabSdk", SearchOption.AllDirectories);
            if (fileList.Length == 0)
                return null;

            var relPath = fileList[0].Substring(fileList[0].LastIndexOf("Assets"));
            return AssetDatabase.LoadAssetAtPath(relPath, typeof(UnityEngine.Object));
        }

        private static bool ShowSDKUpgrade()
        {
            if (string.IsNullOrEmpty(latestSdkVersion) || latestSdkVersion == "Unknown")
            {
                return false;
            }

            if (string.IsNullOrEmpty(installedSdkVersion) || installedSdkVersion == "Unknown")
            {
                return true;
            }

            string[] currrent = installedSdkVersion.Split('.');
            string[] latest = latestSdkVersion.Split('.');

            if (int.Parse(currrent[0]) < 2)
            {
                return false;
            }

            return int.Parse(latest[0]) > int.Parse(currrent[0])
                || int.Parse(latest[1]) > int.Parse(currrent[1])
                || int.Parse(latest[2]) > int.Parse(currrent[2]);
        }

        private static void UpgradeSdk()
        {
            if (EditorUtility.DisplayDialog("Confirm SDK Upgrade", "This action will remove the current PlayFab SDK and install the lastet version. Related plug-ins will need to be manually upgraded.", "Confirm", "Cancel"))
            {
                RemoveSdk(false);
                ImportLatestSDK();
            }
        }

        private static void RemoveSdk(bool prompt = true)
        {
            if (prompt && !EditorUtility.DisplayDialog("Confirm SDK Removal", "This action will remove the current PlayFab SDK. Related plug-ins will need to be manually removed.", "Confirm", "Cancel"))
                return;

            //try to clean-up the plugin dirs
            if (Directory.Exists(Application.dataPath + "/Plugins"))
            {
                var folders = Directory.GetDirectories(Application.dataPath + "/Plugins", "PlayFabShared", SearchOption.AllDirectories);
                foreach (var folder in folders)
                    FileUtil.DeleteFileOrDirectory(folder);

                //try to clean-up the plugin files (if anything is left)
                var files = Directory.GetFiles(Application.dataPath + "/Plugins", "PlayFabErrors.cs", SearchOption.AllDirectories);
                foreach (var file in files)
                    FileUtil.DeleteFileOrDirectory(file);
            }

            if (FileUtil.DeleteFileOrDirectory(PlayFabEditorPrefsSO.Instance.SdkPath))
            {
                PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnSuccess, "PlayFab SDK Removed!");

                // HACK for 5.4, AssetDatabase.Refresh(); seems to cause the install to fail.
                if (prompt)
                {
                    AssetDatabase.Refresh();
                }
            }
            else
            {
                PlayFabEditor.RaiseStateUpdate(PlayFabEditor.EdExStates.OnError, "An unknown error occured and the PlayFab SDK could not be removed.");
            }
        }

        private static void GetLatestSdkVersion()
        {
            var threshold = PlayFabEditorPrefsSO.Instance.EdSet_lastSdkVersionCheck != DateTime.MinValue ? PlayFabEditorPrefsSO.Instance.EdSet_lastSdkVersionCheck.AddHours(1) : DateTime.MinValue;

            if (DateTime.Today > threshold)
            {
                PlayFabEditorHttp.MakeGitHubApiCall("https://api.github.com/repos/PlayFab/UnitySDK/git/refs/tags", (version) =>
                {
                    latestSdkVersion = version ?? "Unknown";
                    PlayFabEditorPrefsSO.Instance.EdSet_latestSdkVersion = latestSdkVersion;
                });
            }
            else
            {
                latestSdkVersion = PlayFabEditorPrefsSO.Instance.EdSet_latestSdkVersion;
            }
        }
    }
}
