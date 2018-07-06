#if UNITY_2017_1_OR_NEWER
using PlayFab.PfEditor;
using UnityEditor;
using UnityEngine;

public class MakeScriptableObject
{
    [MenuItem("PlayFab/MakePlayFabSharedSettings")]
    public static void MakePlayFabSharedSettings()
    {
        PlayFabSharedSettings asset = ScriptableObject.CreateInstance<PlayFabSharedSettings>();

        AssetDatabase.CreateAsset(asset, "Assets/PlayFabSdk/Shared/Public/Resources/PlayFabSharedSettings.asset"); // TODO: Path should not be hard coded
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
#endif
