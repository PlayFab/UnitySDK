using UnityEngine;
using UnityEditor;

public class PlayFabPackager : MonoBehaviour {

	private static string[] SDKAssets = {
		"Assets/PlayFabSDK",
		"Assets/Plugins"
	};
    private static readonly string[] TEST_SCENES = {
        "Assets/PlayFabSDK/DemoScene/DemoScene.unity"
    };
    private const string BUILD_PATH = "C:/depot/sdks/UnitySDK/testBuilds/";

	[MenuItem ("PlayFab/Package SDK")]
	public static void PackagePlayFabSDK()
	{
		AssetDatabase.ExportPackage (SDKAssets, "../PlayFabClientSDK.unitypackage", ExportPackageOptions.Recurse);
	}

    private static void MkDir(string path)
    {
        if (!System.IO.Directory.Exists(path))
            System.IO.Directory.CreateDirectory(path);
    }

    [MenuItem("PlayFab/Testing/AndroidTestBuild")]
    public static void MakeAndroidBuild()
    {
        string ANDROID_PACKAGE = System.IO.Path.Combine(BUILD_PATH, "PlayFabAndroid.apk");
        MkDir(BUILD_PATH);
        BuildPipeline.BuildPlayer(TEST_SCENES, ANDROID_PACKAGE, BuildTarget.Android, BuildOptions.None);
    }

    [MenuItem("PlayFab/Testing/iPhoneTestBuild")]
    public static void MakeIPhoneBuild()
    {
        string IOS_PATH = System.IO.Path.Combine(BUILD_PATH, "PlayFabIOS");
        MkDir(BUILD_PATH);
        MkDir(IOS_PATH);
#if UNITY_5
        BuildPipeline.BuildPlayer(TEST_SCENES, IOS_PATH, BuildTarget.iOS, BuildOptions.None);
#else
        BuildPipeline.BuildPlayer(TEST_SCENES, IOS_PATH, BuildTarget.iPhone, BuildOptions.None);
#endif
    }

    [MenuItem("PlayFab/Testing/WinPhoneTestBuild")]
    public static void MakeWp8Build()
    {
        string WP8_PATH = System.IO.Path.Combine(BUILD_PATH, "PlayFabWP8");
        MkDir(BUILD_PATH);
        MkDir(WP8_PATH);
        BuildPipeline.BuildPlayer(TEST_SCENES, WP8_PATH, BuildTarget.WP8Player, BuildOptions.None);
    }
}
