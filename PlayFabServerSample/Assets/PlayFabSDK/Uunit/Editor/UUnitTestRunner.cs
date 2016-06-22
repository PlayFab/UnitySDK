using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace PlayFab.UUnit
{
    public class StaticTestRunner
    {
        private static void ClearDebugLog()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(SceneView));
            Type type = assembly.GetType("UnityEditorInternal.LogEntries");
            MethodInfo method = type.GetMethod("Clear");
            method.Invoke(new object(), null);
        }

        [MenuItem("PlayFab/UUnit/Run Tests Immediately%#t")]
        public static void TestImmediately()
        {
            ClearDebugLog();
            UUnitTestSuite suite = new UUnitTestSuite();
            suite.FindAndAddAllTestCases(typeof(UUnitTestCase));
            suite.RunAllTests();
            UUnitTestResult result = suite.GetResults();

            if (!result.AllTestsPassed())
            {
                Debug.LogWarning(result.Summary());
                throw new Exception("Not all tests passed.");
            }
            else
            {
                Debug.Log(result.Summary());
            }
        }

        /*[MenuItem("UUnit/Run Tests Incrementally")] Not quite ready for prime-time*/
        public static void TestIncrementally()
        {
            var runnerGOs = GameObject.FindObjectsOfType<UnityIncrementalTestRunner>();
            if (!Application.isPlaying)
                for (int i = 1; i < runnerGOs.Length; i++)
                    GameObject.DestroyImmediate(runnerGOs[i]); // You should only have 1 unit-test runner

            EditorApplication.isPlaying = true; // Start the player

            if (runnerGOs.Length == 0)
            {
                // If there is no unit-test runner active, create one
                GameObject newRunner = new GameObject();
                newRunner.AddComponent<UnityIncrementalTestRunner>();
            }
        }
    }
}
