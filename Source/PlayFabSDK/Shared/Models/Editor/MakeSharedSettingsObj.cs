#if !UNITY_5
using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeScriptableObject
{
    [MenuItem("PlayFab/MakePlayFabSharedSettings")]
    public static void MakePlayFabSharedSettings()
    {
        PlayFabSharedSettings asset = ScriptableObject.CreateInstance<PlayFabSharedSettings>();

        AssetDatabase.CreateAsset(asset, "Assets/PlayFabSdk/Shared/Public/Resources/PlayFabSharedSettings.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
#endif
