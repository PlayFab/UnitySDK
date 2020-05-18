using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace PlayFab.UUnit
{
    public static class StaticTestRunner
    {
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

        // From an empty scene, this will create the test scene
        [MenuItem("PlayFab/Testing/Play and Run Tests")]
        public static void TestImmediately()
        {
            ClearDebugLog();

            var testComponents = UnityEngine.Object.FindObjectsOfType<UUnitIncrementalTestRunner>();
            if (testComponents.Length == 0)
            {
                testComponents = new[] { new GameObject("UUnitRunner", typeof(UUnitIncrementalTestRunner)).GetComponent<UUnitIncrementalTestRunner>() };
                testComponents[0].autoQuit = true;
            }

            EditorApplication.isPlaying = true;
        }
    }
}
