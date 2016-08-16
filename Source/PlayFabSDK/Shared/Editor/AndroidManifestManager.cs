using UnityEngine;
using UnityEditor;
using System;
using System.IO;

[InitializeOnLoad]
public class AndroidManifestManager
{
    static AndroidManifestManager()
    {
#if UNITY_ANDROID
        if (PlayerSettings.bundleIdentifier != "com.playfab.sampleproj") {
            CustomizeManifest ();
        }
#endif
    }

    public static void CustomizeManifest()
    {
        string appId = PlayerSettings.bundleIdentifier;

        if (String.IsNullOrEmpty(appId) || appId == "com.Company.ProductName")
        {
            EditorUtility.DisplayDialog("Android Manifest Reminder", "Your project does not currently have a bundle identifier set. If you wish to publish on Android, you must manually edit your Android manifest at Assets/Plugins/Android/AndroindManifest.xml and replace all occurances of {APP_BUNDLE_ID} with your bundle identifier", "OK");
            return;
        }

        TextAsset manifestAsset = (TextAsset)AssetDatabase.LoadMainAssetAtPath("Assets/Plugins/Android/AndroindManifest.xml");
        if (manifestAsset == null)
        {
            // No manifest to fix up
            return;
        }

        String manifestStr = manifestAsset.text;
        String fixedManifest = manifestStr.Replace("{APP_BUNDLE_ID}", appId);
        if (fixedManifest == manifestStr)
        {
            // no changes made
            return;
        }

        AssetDatabase.RenameAsset("Assets/Plugins/Android/AndroindManifest.xml", "Assets/Plugins/Android/AndroindManifest.xml.back");

        String path = Application.dataPath + "/Plugins/Android/AndroindManifest.xml";
        File.WriteAllText(path, fixedManifest);

        AssetDatabase.MoveAssetToTrash("Assets/PlayFabSDK/Editor/AndroidManifestManager.cs");

        AssetDatabase.Refresh();
    }
}
