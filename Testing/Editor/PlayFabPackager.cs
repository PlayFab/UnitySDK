using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEditor;

namespace PlayFab.Internal
{
    public static class PlayFabPackager
    {
        private static readonly string[] SdkAssets = {
            "Assets/PlayFabSDK",
            "Assets/Plugins"
        };
        private static readonly string[] TestScenes = {
            "assets/Testing/scenes/testscene.unity"
        };

        #region Utility Functions
        private static void Setup()
        {
            Type setupPlayFabExampleType = typeof(PlayFabPackager).Assembly.GetType("SetupPlayFabExample");
            MethodInfo setupMethod = null;
            if (setupPlayFabExampleType != null)
                setupMethod = setupPlayFabExampleType.GetMethod("Setup", BindingFlags.Static | BindingFlags.Public);
            if (setupMethod != null)
                setupMethod.Invoke(null, null);
        }

        private static string GetBuildPath()
        {
            return Path.GetFullPath(Path.Combine(Application.dataPath, "../testBuilds"));
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
            Setup();
            var packagePath = "C:/depot/sdks/UnitySDK/Packages/UnitySDK.unitypackage";
            AssetDatabase.ExportPackage(SdkAssets, packagePath, ExportPackageOptions.Recurse);
            Debug.Log("Package built: " + packagePath);
        }

        [MenuItem("PlayFab/Testing/AndroidTestBuild")]
        public static void MakeAndroidBuild()
        {
            Setup();
            PlayerSettings.SetPropertyInt("ScriptingBackend", (int)ScriptingImplementation.Mono2x, BuildTargetGroup.Android); // Ideal setting for Android
            PlayerSettings.bundleIdentifier = "com.PlayFab.PlayFabTest";
            var androidPackage = Path.Combine(GetBuildPath(), "PlayFabAndroid.apk");
            MkDir(GetBuildPath());
            BuildPipeline.BuildPlayer(TestScenes, androidPackage, BuildTarget.Android, BuildOptions.None);
            if (Directory.GetFiles(androidPackage).Length == 0)
                throw new Exception("Target file did not build: " + androidPackage);
        }

        [MenuItem("PlayFab/Testing/iPhoneTestBuild")]
        public static void MakeIPhoneBuild()
        {
            Setup();
#if UNITY_5
            BuildTarget appleBuildTarget = BuildTarget.iOS;
#else
            BuildTarget appleBuildTarget = BuildTarget.iPhone;
#endif

            // PlayerSettings.SetPropertyInt("ScriptingBackend", (int)ScriptingImplementation.IL2CPP, appleBuildTarget); // Ideally we should be testing both at some point, but ...
            PlayerSettings.SetPropertyInt("ScriptingBackend", (int)ScriptingImplementation.Mono2x, appleBuildTarget); // Mono2x is traditionally the one with issues, and it's a lot faster to build/test
            var iosPath = Path.Combine(GetBuildPath(), "PlayFabIOS");
            MkDir(GetBuildPath());
            MkDir(iosPath);
            BuildPipeline.BuildPlayer(TestScenes, iosPath, appleBuildTarget, BuildOptions.None);
            if (Directory.GetFiles(iosPath).Length == 0)
                throw new Exception("Target directory is empty: " + iosPath + ", " + string.Join(",", Directory.GetFiles(iosPath)));
        }

        [MenuItem("PlayFab/Testing/WinPhoneTestBuild")]
        public static void MakeWp8Build()
        {
            Setup();
#if UNITY_5
            BuildTarget wsaBuildTarget = BuildTarget.WSAPlayer;
            EditorUserBuildSettings.wsaSDK = WSASDK.UniversalSDK81;
            EditorUserBuildSettings.wsaBuildAndRunDeployTarget = WSABuildAndRunDeployTarget.LocalMachineAndWindowsPhone;
            EditorUserBuildSettings.wsaGenerateReferenceProjects = true;
            PlayerSettings.WSA.SetCapability(PlayerSettings.WSACapability.InternetClient, true);
#else
            BuildTarget wsaBuildTarget = BuildTarget.WP8Player;
#endif

            var wp8Path = Path.Combine(GetBuildPath(), "PlayFabWP8");
            MkDir(GetBuildPath());
            MkDir(wp8Path);
            BuildPipeline.BuildPlayer(TestScenes, wp8Path, wsaBuildTarget, BuildOptions.None);
            if (Directory.GetFiles(wp8Path).Length == 0)
                throw new Exception("Target directory is empty: " + wp8Path + ", " + string.Join(",", Directory.GetFiles(wp8Path)));
        }

        [MenuItem("PlayFab/Testing/Win32TestBuild")]
        public static void MakeWin32TestingBuild()
        {
            Setup();
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
            if (Directory.GetFiles(win32Path).Length == 0)
                throw new Exception("Target file did not build: " + win32Path);
        }
    }
}
