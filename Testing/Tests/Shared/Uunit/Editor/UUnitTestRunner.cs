using System;
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
            var method = type.GetMethod("Clear");
            method.Invoke(new object(), null);
        }

        [MenuItem("PlayFab/UUnit/Play and Run Tests%#t")]
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
