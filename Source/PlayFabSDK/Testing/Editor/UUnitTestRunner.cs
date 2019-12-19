using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace PlayFab.UUnit
{
    public static class StaticTestRunner
    {
        private static UUnitIncrementalTestRunner[] _testers = null;

        private static void ClearDebugLog()
        {
            var assembly = Assembly.GetAssembly(typeof(SceneView));
            var type = assembly.GetType("UnityEditorInternal.LogEntries");
            if (type == null)
            {
                Debug.LogWarning("UnityEditorInternal.LogEntries.Clear method has been moved in Unity 2017.");
                return;
            }
            var method = type.GetMethod("Clear");
            if (method == null)
            {
                Debug.LogWarning("UnityEditorInternal.LogEntries.Clear method has been moved in Unity 2017.");
                return;
            }

            method.Invoke(new object(), null);
        }

        [MenuItem("PlayFab/Testing/Play and Run Tests")]
        public static void TestImmediately()
        {
            ClearDebugLog();

            _testers = UnityEngine.Object.FindObjectsOfType<UUnitIncrementalTestRunner>();
            if (_testers.Length == 0)
            {
                _testers = new[] { new GameObject("UUnitRunner", typeof(UUnitIncrementalTestRunner)).GetComponent<UUnitIncrementalTestRunner>() };
                _testers[0].autoQuit = true;
            }

            EditorApplication.isPlaying = true;
        }
    }
}
