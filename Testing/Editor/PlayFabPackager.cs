using System.IO;
using UnityEngine;
using UnityEditor;

namespace PlayFab.Internal
{
    public class PlayFabPackager : MonoBehaviour
    {
        private static readonly string[] SdkAssets = {
            "Assets/PlayFabSDK",
            "Assets/Plugins"
        };
        private static readonly string[] TestScenes = {
            "assets/Testing/scenes/testscene.unity"
        };

        #region Utility Functions
        private static string GetBuildPath()
        {
            return Path.Combine(Application.dataPath, "../testBuilds");
        }

        private static void MkDir(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
        #endregion Utility Functions

        [MenuItem("PlayFab/Package SDK")]
        public static void PackagePlayFabSdk()
        {
            var packagePath = "C:/depot/sdks/UnitySDK/Packages/UnitySDK.unitypackage";
            AssetDatabase.ExportPackage(SdkAssets, packagePath, ExportPackageOptions.Recurse);
            Debug.Log("Package built: " + packagePath);
        }

        [MenuItem("PlayFab/Testing/AndroidTestBuild")]
        public static void MakeAndroidBuild()
        {
            PlayerSettings.SetPropertyInt("ScriptingBackend", (int)ScriptingImplementation.Mono2x, BuildTargetGroup.Android); // Ideal setting for Android
            PlayerSettings.bundleIdentifier = "com.PlayFab.PlayFabTest";
            var androidPackage = Path.Combine(GetBuildPath(), "PlayFabAndroid.apk");
            MkDir(GetBuildPath());
            BuildPipeline.BuildPlayer(TestScenes, androidPackage, BuildTarget.Android, BuildOptions.None);
        }

        [MenuItem("PlayFab/Testing/iPhoneTestBuild")]
        public static void MakeIPhoneBuild()
        {
            // PlayerSettings.SetPropertyInt("ScriptingBackend", (int)ScriptingImplementation.IL2CPP, BuildTargetGroup.iOS); // Ideally we should be testing both at some point, but ...
            PlayerSettings.SetPropertyInt("ScriptingBackend", (int)ScriptingImplementation.Mono2x, BuildTargetGroup.iOS); // Mono2x is traditionally the one with issues, and it's a lot faster to build/test
            var iosPath = Path.Combine(GetBuildPath(), "PlayFabIOS");
            MkDir(GetBuildPath());
            MkDir(iosPath);
#if UNITY_5
            BuildPipeline.BuildPlayer(TestScenes, iosPath, BuildTarget.iOS, BuildOptions.None);
#else
            BuildPipeline.BuildPlayer(TestScenes, iosPath, BuildTarget.iPhone, BuildOptions.None);
#endif
        }

        [MenuItem("PlayFab/Testing/WinPhoneTestBuild")]
        public static void MakeWp8Build()
        {
            var wp8Path = Path.Combine(GetBuildPath(), "PlayFabWP8");
            MkDir(GetBuildPath());
            MkDir(wp8Path);
#if UNITY_5
            BuildPipeline.BuildPlayer(TestScenes, wp8Path, BuildTarget.WSAPlayer, BuildOptions.None);
#else
            BuildPipeline.BuildPlayer(TestScenes, wp8Path, BuildTarget.WP8Player, BuildOptions.None);
#endif
        }

        [MenuItem("PlayFab/Testing/Win32TestBuild")]
        public static void MakeWin32TestingBuild()
        {
            PlayerSettings.SetPropertyInt("ScriptingBackend", (int)ScriptingImplementation.Mono2x, BuildTargetGroup.Standalone); // Ideal setting for Windows
            PlayerSettings.defaultIsFullScreen = false;
            PlayerSettings.defaultScreenHeight = 768;
            PlayerSettings.defaultScreenWidth = 1024;
            PlayerSettings.runInBackground = true;
            PlayerSettings.displayResolutionDialog = ResolutionDialogSetting.Disabled;
            PlayerSettings.resizableWindow = true;
            string win32Path = Path.Combine(GetBuildPath(), "Win32test.exe");
            MkDir(GetBuildPath());
            BuildPipeline.BuildPlayer(TestScenes, win32Path, BuildTarget.StandaloneWindows, BuildOptions.None);
        }
    }
}
