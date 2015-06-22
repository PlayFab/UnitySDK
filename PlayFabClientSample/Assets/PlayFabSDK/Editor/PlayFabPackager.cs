using UnityEngine;
using UnityEditor;

public class PlayFabPackager : MonoBehaviour {

	private static string[] SDKAssets = {
		"Assets/PlayFabSDK",
		"Assets/Plugins"
	};

	[MenuItem ("PlayFab/Package SDK")]
	public static void PackagePlayFabSDK()
	{
		AssetDatabase.ExportPackage (SDKAssets, "../PlayFabClientSDK.unitypackage", ExportPackageOptions.Recurse);
	}
}
