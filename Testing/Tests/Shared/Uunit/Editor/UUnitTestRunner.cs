using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace PlayFab.UUnit
{
    public static class StaticTestRunner
    {
        private static UUnitIncrementalTestRunner[] testers = null;

        private static void ClearDebugLog()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(SceneView));
            Type type = assembly.GetType("UnityEditorInternal.LogEntries");
            MethodInfo method = type.GetMethod("Clear");
            method.Invoke(new object(), null);
        }

        [MenuItem("PlayFab/UUnit/Play and Run Tests%#t")]
        public static void TestImmediately()
        {
            ClearDebugLog();

            testers = UnityEngine.Object.FindObjectsOfType<UUnitIncrementalTestRunner>();
            if (testers.Length == 0)
            {
                testers = new[] { new GameObject("UUnitRunner", typeof(UUnitIncrementalTestRunner)).GetComponent<UUnitIncrementalTestRunner>() };
                testers[0].autoQuit = true;
            }

            EditorApplication.isPlaying = true;
        }
    }
}
