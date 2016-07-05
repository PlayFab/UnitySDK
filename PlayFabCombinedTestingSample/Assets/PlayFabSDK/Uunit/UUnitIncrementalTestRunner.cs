using UnityEngine;
using System;
using System.Collections.Generic;
using PlayFab.ClientModels;
using UnityEngine.UI;

namespace PlayFab.UUnit
{
    public class UUnitIncrementalTestRunner : MonoBehaviour
    {
        public bool autoQuit = false;
        public bool suiteFinished = false;
        public string summary;
        public UUnitTestSuite suite;
        public Text textDisplay = null;
        public string filter;
        public bool postResultsToCloudscript = true;

        public void Start()
        {
            suite = new UUnitTestSuite();
            suite.FindAndAddAllTestCases(typeof(UUnitTestCase), filter);

            if (textDisplay == null)
            {
                Canvas canvas = new GameObject("Canvas", typeof(Canvas)).GetComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                textDisplay = new GameObject("Test Report", typeof(Text)).GetComponent<Text>();
                textDisplay.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                RectTransform textTransform = textDisplay.rectTransform;
                textTransform.SetParent(canvas.transform, false);
                textTransform.anchorMin = new Vector2(0, 0);
                textTransform.anchorMax = new Vector2(1, 1);
                textTransform.pivot = new Vector2(0, 1);
                textTransform.anchoredPosition = Vector2.zero;
            }
        }

        public void Update()
        {
            if (suiteFinished || textDisplay == null)
                return;

            suiteFinished = suite.TickTestSuite();
            summary = suite.GenerateSummary();
            textDisplay.text = summary;

            if (suiteFinished)
            {
                textDisplay.text += "\nThe UUnitRunner gameobject was added to the scene for these tests.  You must manually remove it from your scene.";
                if (suite.AllTestsPassed())
                    Debug.Log(summary);
                else
                    Debug.LogWarning(summary);

                if (postResultsToCloudscript)
                    PostTestResultsToCloudScript(suite.GetInternalReport());
                else
                    OnCloudScriptSubmit(null);
            }
        }

        public void PostTestResultsToCloudScript(TestSuiteReport testReport)
        {
            ExecuteCloudScriptRequest request = new ExecuteCloudScriptRequest
            {
                FunctionName = "SaveTestData",
                FunctionParameter = new Dictionary<string, object> { { "customId", PlayFabSettings.BuildIdentifier }, { "testReport", new[] { testReport } } },
                GeneratePlayStreamEvent = true
            };
            PlayFabClientAPI.ExecuteCloudScript(request, OnCloudScriptSubmit, OnCloudScriptError);
        }

        public void OnCloudScriptSubmit(ExecuteCloudScriptResult result)
        {
            if (postResultsToCloudscript)
                Debug.Log("Results posted to Cloud Script successfully: " + PlayFabSettings.BuildIdentifier);

            if (autoQuit && !Application.isEditor)
                Application.Quit();
            else if (!suite.AllTestsPassed())
                throw new Exception("Results were not posted to Cloud Script: " + PlayFabSettings.BuildIdentifier);
        }

        public void OnCloudScriptError(PlayFabError error)
        {
            Debug.LogWarning("Error posting results to Cloud Script:" + error.GenerateErrorReport());

            if (autoQuit && !Application.isEditor)
                Application.Quit();
            else if (!suite.AllTestsPassed())
                throw new Exception("Results were not posted to Cloud Script: " + PlayFabSettings.BuildIdentifier);
        }
    }
}
