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

        private static string PathCombine(params string[] elements)
        {
            string output = null;
            foreach (var element in elements)
                output = string.IsNullOrEmpty(output) ? element : Path.Combine(output, element);
            return output;
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
#if UNITY_5 || UNITY_5_3_OR_NEWER
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
#if UNITY_5 || UNITY_5_3_OR_NEWER
                return BuildTargetGroup.iOS;
#else
                return BuildTargetGroup.iPhone;
#endif
            }
        }

        private static BuildTarget OsxBuildTarget
        {
            get
            {
#if UNITY_2017_3_OR_NEWER
                return BuildTarget.StandaloneOSX;
#else
                return BuildTarget.StandaloneOSXUniversal;
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

        [MenuItem("PlayFab/Testing/Build PlayFab UnitySDK Package")]
        public static void PackagePlayFabSdk()
        {
            var workspacePath = Environment.GetEnvironmentVariable("WORKSPACE"); // This is a Jenkins-Build environment variable
            if (string.IsNullOrEmpty(workspacePath))
                workspacePath = "C:/depot"; // Expected typical location
            var repoName = Environment.GetEnvironmentVariable("SdkName"); // This is a Jenkins-Build environment variable
            if (string.IsNullOrEmpty(repoName))
                repoName = "UnitySDK"; // Default if we aren't building something else

            Setup();
            var packageFolder = PathCombine(workspacePath, "sdks", repoName, "Packages");
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
            if (!File.Exists(androidPackage))
                throw new Exception("Target file did not build: " + androidPackage);
        }

        [MenuItem("PlayFab/Testing/iPhoneTestBuild")]
        public static void MakeIPhoneBuild()
        {
            Setup();
#if UNITY_2018_1_OR_NEWER
            SetScriptingBackend(ScriptingImplementation.IL2CPP, AppleBuildTarget, AppleBuildTargetGroup); // Ideally we should be testing both at some point, but ...
#else
            SetScriptingBackend(ScriptingImplementation.Mono2x, AppleBuildTarget, AppleBuildTargetGroup); // Mono2x is traditionally the one with issues, and it's a lot faster to build/test
#endif
            SetIdentifier(AppleBuildTargetGroup, "com.PlayFab.PlayFabTest");
            var iosPath = Path.Combine(GetBuildPath(), "PlayFabIOS");
            MkDir(GetBuildPath());
            MkDir(iosPath);
            BuildPipeline.BuildPlayer(TestScenes, iosPath, AppleBuildTarget, BuildOptions.None);
            if (Directory.GetFiles(iosPath).Length == 0)
                throw new Exception("Target directory is empty: " + iosPath + ", " + string.Join(",", Directory.GetFiles(iosPath)));
        }

        [MenuItem("PlayFab/Testing/OSXTestBuild")]
        public static void MakeOsxBuild()
        {
            Setup();
            //SetScriptingBackend(ScriptingImplementation.IL2CPP, OsxBuildTarget, BuildTargetGroup.Standalone);  // IL2CPP can only be built on Mac.
            SetScriptingBackend(ScriptingImplementation.Mono2x, OsxBuildTarget, BuildTargetGroup.Standalone);
            SetIdentifier(AppleBuildTargetGroup, "com.PlayFab.PlayFabTest");
            var osxAppName = "PlayFabOSX";
            var osxPath = Path.Combine(GetBuildPath(), osxAppName);
            MkDir(GetBuildPath());
            MkDir(osxPath);
            BuildPipeline.BuildPlayer(TestScenes, Path.Combine(osxPath, osxAppName), OsxBuildTarget, BuildOptions.None);
            if (Directory.GetFileSystemEntries(osxPath).Length == 0)
                throw new Exception("Target directory is empty: " + osxPath + ", " + string.Join(",", Directory.GetFiles(osxPath)));
        }

        [MenuItem("PlayFab/Testing/PS4TestBuild")]
        public static void MakePS4Build()
        {
            Setup();
            SetScriptingBackend(ScriptingImplementation.IL2CPP, BuildTarget.PS4, BuildTargetGroup.PS4);
            SetIdentifier(BuildTargetGroup.PS4, "com.PlayFab.PlayFabTest");
#if UNITY_5_6_OR_NEWER
            PlayerSettings.SplashScreen.show = false;
#endif
            PlayerSettings.PS4.parentalLevel = 0;
            var ps4Path = Path.Combine(GetBuildPath(), "PlayFabPS4");
            MkDir(GetBuildPath());
            MkDir(ps4Path);
            BuildPipeline.BuildPlayer(TestScenes, ps4Path, BuildTarget.PS4, BuildOptions.None);
            if (Directory.GetFiles(ps4Path).Length == 0)
                throw new Exception("Target directory is empty: " + ps4Path + ", " + string.Join(",", Directory.GetFiles(ps4Path)));
        }

#if UNITY_5_6_OR_NEWER // Switch is entirely unsupported before 5.6
        [MenuItem( "PlayFab/Testing/SwitchTestBuild" )]
        public static void MakeSwitchBuild()
        {
            Setup();
            SetScriptingBackend(ScriptingImplementation.IL2CPP, BuildTarget.Switch, BuildTargetGroup.Switch);
            SetIdentifier(BuildTargetGroup.Switch, "PlayFabSwitchTest");
            PlayerSettings.SplashScreen.show = false;
            EditorUserBuildSettings.switchCreateRomFile = true;

            var switchPackage = Path.Combine(GetBuildPath(), "PlayFabSwitch.nsp");
            MkDir(GetBuildPath());
            BuildPipeline.BuildPlayer(TestScenes, switchPackage, BuildTarget.Switch, BuildOptions.None);
            if (Directory.GetFiles(switchPackage).Length == 0)
                throw new Exception("Target file did not build: " + switchPackage);
        }
#endif

        [MenuItem("PlayFab/Testing/WinPhoneTestBuild")]
        public static void MakeWp8Build()
        {
            Setup();
#if UNITY_2017_1_OR_NEWER
            EditorUserBuildSettings.wsaBuildAndRunDeployTarget = WSABuildAndRunDeployTarget.WindowsPhone;
            EditorUserBuildSettings.wsaSubtarget = WSASubtarget.AnyDevice;
#if !UNITY_2019_1_OR_NEWER
            EditorUserBuildSettings.wsaGenerateReferenceProjects = true;
#endif
            PlayerSettings.WSA.SetCapability(PlayerSettings.WSACapability.InternetClient, true);
#elif UNITY_5_2 || UNITY_5_3_OR_NEWER
            EditorUserBuildSettings.wsaSDK = WSASDK.UniversalSDK81;
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
#if UNITY_2018_1_OR_NEWER
            PlayerSettings.fullScreenMode = FullScreenMode.Windowed;
#else
            PlayerSettings.defaultIsFullScreen = false;
#endif
            PlayerSettings.defaultScreenHeight = 768;
            PlayerSettings.defaultScreenWidth = 1024;
            PlayerSettings.runInBackground = true;
#if !UNITY_2019_2_OR_NEWER
#pragma warning disable 0618
            PlayerSettings.displayResolutionDialog = ResolutionDialogSetting.Disabled;
#pragma warning restore 0618
#endif
            PlayerSettings.resizableWindow = true;
            string win32Path = Path.Combine(GetBuildPath(), "Win32test.exe");
            MkDir(GetBuildPath());
            BuildPipeline.BuildPlayer(TestScenes, win32Path, BuildTarget.StandaloneWindows, BuildOptions.None);
            if (!File.Exists(win32Path))
                throw new Exception("Target file did not build: " + win32Path);
        }

        [MenuItem("PlayFab/Testing/XboxOneTestBuild")]
        public static void MakeXboxOneBuild()
        {
            Setup();
            SetScriptingBackend(ScriptingImplementation.IL2CPP, BuildTarget.XboxOne, BuildTargetGroup.XboxOne);
            //SetScriptingBackend( ScriptingImplementation.Mono2x, BuildTarget.XboxOne, BuildTargetGroup.XboxOne );
            SetIdentifier(BuildTargetGroup.XboxOne, "com.PlayFab.PlayFabTest");
            var xboxOnePath = Path.Combine(GetBuildPath(), "PlayFabXboxOne");
            MkDir(GetBuildPath());
            MkDir(xboxOnePath);
            BuildPipeline.BuildPlayer(TestScenes, xboxOnePath, BuildTarget.XboxOne, BuildOptions.None);
            if (Directory.GetFileSystemEntries(xboxOnePath).Length == 0)
                throw new Exception("Target directory is empty: " + xboxOnePath + ", " + string.Join(",", Directory.GetFiles(xboxOnePath)));
        }
    }
}
