using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace PlayFab.Internal
{
    public static class PlayFabEdExPackager
    {
        private static string EDEX_VERSION_TEMPLATE = "namespace PlayFab.PfEditor { public static partial class PlayFabEditorHelper { public static string EDEX_VERSION = \"{sdkVersion}\"; } }\n";
        private static string PACKAGE_FILENAME = "PlayFabEditorExtensions.unitypackage";

        private static readonly string[] SdkAssets = {
            "Assets/PlayFabEditorExtensions"
        };

        private static string PathCombine(params string[] elements)
        {
            string output = null;
            foreach (var element in elements)
                output = string.IsNullOrEmpty(output) ? element : Path.Combine(output, element);
            return output;
        }

        private static void MkDir(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        /// <summary>
        /// We deliberately don't check things that would cause exceptions here.
        /// If something fails, we need it to throw an exception to cause the error code to be != 0,
        ///   which means catching and throwing it/another anyways, so just don't bother
        /// </summary>
        [MenuItem("PlayFab/Testing/Build PlayFab EdEx UnityPackage")]
        public static void BuildUnityPackage()
        {
            var versionSrcFile = "C:/depot/API_Specs/SdkManualNotes.json"; // TODO: Don't hard code this
            var notes = File.ReadAllText(versionSrcFile);
            var searchRegex = "\"unity-v2\": \"([0-9]+\\.[0-9]+\\.[0-9]+)\"";
            var match = Regex.Match(notes, searchRegex);
            var unitySdkVersion = match.Captures[0].Value.Replace("\"", "").Replace("unity-v2:", "").Trim();

            var versionDefFiles = Directory.GetFiles(Application.dataPath, "PlayFabEditorVersion.cs", SearchOption.AllDirectories);
            var versionDefFile = versionDefFiles[0];
            var contents = EDEX_VERSION_TEMPLATE.Replace("{sdkVersion}", unitySdkVersion);
            File.WriteAllText(versionDefFile, contents);

            // We just changed a file we're about to publish - May not work, we might have to change this to be two console calls
            AssetDatabase.Refresh();

            var workspacePath = Environment.GetEnvironmentVariable("WORKSPACE"); // This is a Jenkins-Build environment variable
            if (string.IsNullOrEmpty(workspacePath))
                workspacePath = "C:/depot"; // Expected typical location
            var repoName = Environment.GetEnvironmentVariable("SdkName"); // This is a Jenkins-Build environment variable
            if (string.IsNullOrEmpty(repoName))
                repoName = "UnitySDK"; // Default if we aren't building something else

            var packageFolder = PathCombine(workspacePath, "sdks", repoName, "Packages");
            MkDir(packageFolder);
            var packageFullPath = Path.Combine(packageFolder, PACKAGE_FILENAME);
            if (File.Exists(packageFullPath))
                File.Delete(packageFullPath);
            if (File.Exists(packageFullPath))
                throw new PlayFabException(PlayFabExceptionCode.BuildError, "The older package version could not be deleted.");

            AssetDatabase.ExportPackage(SdkAssets, packageFullPath, ExportPackageOptions.Recurse);

            if (!File.Exists(packageFullPath))
                throw new PlayFabException(PlayFabExceptionCode.BuildError, "The package was not replaced as expected.");
            Debug.Log("Edex Package built: " + packageFullPath);
        }
    }
}
