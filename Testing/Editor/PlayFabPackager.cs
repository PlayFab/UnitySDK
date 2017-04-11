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

        #region Unity Multi-version Utilities
        private static void SetIdentifier(BuildTargetGroup targetGroup, string identifier)
        {
#if UNITY_5_6_OR_NEWER
            PlayerSettings.SetApplicationIdentifier(targetGroup, identifier);
#else
            PlayerSettings.bundleIdentifier = identifier;
#endif
        }

        private static void SetScriptingBackend(ScriptingImplementation mode, BuildTarget target, BuildTargetGroup group)
        {
#if UNITY_5_5_OR_NEWER
            PlayerSettings.SetScriptingBackend(group, mode);
#else
            PlayerSettings.SetPropertyInt("ScriptingBackend", (int)mode, target);
#endif
        }

        private static BuildTarget AppleBuildTarget
        {
            get
            {
#if UNITY_5
                return BuildTarget.iOS;
#else
                return BuildTarget.iPhone;
#endif
            }
        }
        private static BuildTargetGroup AppleBuildTargetGroup
        {
            get
            {
#if UNITY_5
                return BuildTargetGroup.iOS;
#else
                return BuildTargetGroup.iPhone;
#endif
            }
        }

        private static BuildTarget WsaBuildTarget
        {
            get
            {
#if UNITY_5_2 || UNITY_5_3_OR_NEWER
                return BuildTarget.WSAPlayer;
#else
                return BuildTarget.WP8Player;
#endif
            }
        }
        private static BuildTargetGroup WsaBuildTargetGroup
        {
            get
            {
#if UNITY_5_2 || UNITY_5_3_OR_NEWER
                return BuildTargetGroup.WSA;
#else
                return BuildTargetGroup.WP8;
#endif
            }
        }

        #endregion Unity Multi-version Utilities

        [MenuItem("PlayFab/Package SDK")]
        public static void PackagePlayFabSdk()
        {
            var repoName = Environment.GetEnvironmentVariable("SdkName"); // This is a Jenkins-Build environment variable
            if (string.IsNullOrEmpty(repoName))
                repoName = "UnitySDK"; // Default if we aren't building something else
            Setup();
            var packageFolder = Path.Combine(Path.Combine("C:/depot/sdks", repoName), "Packages");
            MkDir(packageFolder);
            var packageFullPath = Path.Combine(packageFolder, "UnitySDK.unitypackage");
            AssetDatabase.ExportPackage(SdkAssets, packageFullPath, ExportPackageOptions.Recurse);
            Debug.Log("Package built: " + packageFullPath);
        }

        [MenuItem("PlayFab/Testing/AndroidTestBuild")]
        public static void MakeAndroidBuild()
        {
            Setup();
            SetScriptingBackend(ScriptingImplementation.Mono2x, BuildTarget.Android, BuildTargetGroup.Android); // Ideal setting for Android
            SetIdentifier(BuildTargetGroup.Android, "com.PlayFab.PlayFabTest");
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
            // SetScriptingBackend(ScriptingImplementation.IL2CPP, AppleBuildTarget, AppleBuildTargetGroup); // Ideally we should be testing both at some point, but ...
            SetScriptingBackend(ScriptingImplementation.Mono2x, AppleBuildTarget, AppleBuildTargetGroup); // Mono2x is traditionally the one with issues, and it's a lot faster to build/test
            SetIdentifier(AppleBuildTargetGroup, "com.PlayFab.PlayFabTest");
            var iosPath = Path.Combine(GetBuildPath(), "PlayFabIOS");
            MkDir(GetBuildPath());
            MkDir(iosPath);
            BuildPipeline.BuildPlayer(TestScenes, iosPath, AppleBuildTarget, BuildOptions.None);
            if (Directory.GetFiles(iosPath).Length == 0)
                throw new Exception("Target directory is empty: " + iosPath + ", " + string.Join(",", Directory.GetFiles(iosPath)));
        }

        [MenuItem("PlayFab/Testing/WinPhoneTestBuild")]
        public static void MakeWp8Build()
        {
            Setup();
#if UNITY_5_2 || UNITY_5_3_OR_NEWER
            EditorUserBuildSettings.wsaSDK = WSASDK.UniversalSDK81;
            EditorUserBuildSettings.wsaBuildAndRunDeployTarget = WSABuildAndRunDeployTarget.LocalMachineAndWindowsPhone;
            EditorUserBuildSettings.wsaGenerateReferenceProjects = true;
            PlayerSettings.WSA.SetCapability(PlayerSettings.WSACapability.InternetClient, true);
#endif

            var wp8Path = Path.Combine(GetBuildPath(), "PlayFabWP8");
            MkDir(GetBuildPath());
            MkDir(wp8Path);
            BuildPipeline.BuildPlayer(TestScenes, wp8Path, WsaBuildTarget, BuildOptions.None);
            if (Directory.GetFiles(wp8Path).Length == 0)
                throw new Exception("Target directory is empty: " + wp8Path + ", " + string.Join(",", Directory.GetFiles(wp8Path)));
        }

        [MenuItem("PlayFab/Testing/Win32TestBuild")]
        public static void MakeWin32TestingBuild()
        {
            Setup();
            SetScriptingBackend(ScriptingImplementation.Mono2x, BuildTarget.StandaloneWindows, BuildTargetGroup.Standalone);
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
