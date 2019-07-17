using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
#if !DISABLE_PLAYFABCLIENT_API
using PlayFab.ClientModels;
#endif

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
        public TestTitleDataLoader.TestTitleData testTitleData;
        public TextAsset testTitleDataAsset;

        public void Start()
        {
            testTitleData = TestTitleDataLoader.LoadTestTitleData(testTitleDataAsset == null ? null : testTitleDataAsset.text);
            suite = new UUnitTestSuite();
            suite.FindAndAddAllTestCases(typeof(UUnitTestCase), filter);

            if (textDisplay == null)
            {
                var canvas = new GameObject("Canvas", typeof(Canvas)).GetComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                textDisplay = new GameObject("Test Report", typeof(Text)).GetComponent<Text>();
                textDisplay.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
                var textTransform = textDisplay.rectTransform;
                textTransform.SetParent(canvas.transform, false);
                textTransform.anchorMin = new Vector2(0, 0);
                textTransform.anchorMax = new Vector2(1, 1);
                textTransform.pivot = new Vector2(0, 1);
                textTransform.anchoredPosition = Vector2.zero;
                textTransform.offsetMax = Vector2.zero;
                textTransform.offsetMin = Vector2.zero;
                textDisplay.resizeTextForBestFit = true;
            }
        }

        public void Update()
        {
            if (suiteFinished || textDisplay == null)
                return;

            suiteFinished = suite.TickTestSuite();
            summary = suite.GenerateTestSummary();
            textDisplay.text = summary;
            textDisplay.resizeTextForBestFit = true;

            if (suiteFinished)
            {
                textDisplay.text += "\nThe UUnitRunner gameobject was added to the scene for these tests.  You must manually remove it from your scene.";
                textDisplay.resizeTextForBestFit = true;
                if (suite.AllTestsPassed())
                    Debug.Log(summary);
                else
                    Debug.LogWarning(summary);

                OnSuiteFinish();
            }
        }

#if DISABLE_PLAYFABCLIENT_API
        private void OnSuiteFinish()
        {
        }
#else
        private void OnSuiteFinish()
        {
            if (postResultsToCloudscript)
                PostTestResultsToCloudScript();
            else
                OnCloudScriptSubmit(null);
        }

        PlayFabClientInstanceAPI clientInstance = new PlayFabClientInstanceAPI(new PlayFabApiSettings(), new PlayFabAuthenticationContext());
        private void PostTestResultsToCloudScript()
        {
            clientInstance.apiSettings.TitleId = testTitleData.titleId;
            clientInstance.LoginWithCustomID(new LoginWithCustomIDRequest { CustomId = PlayFabSettings.BuildIdentifier }, OnLoginSuccess, OnPostTestResultsError, null, testTitleData.extraHeaders);
        }

        private void OnLoginSuccess(LoginResult result)
        {
            var request = new ExecuteCloudScriptRequest
            {
                FunctionName = "SaveTestData",
                FunctionParameter = new Dictionary<string, object> { { "customId", PlayFabSettings.BuildIdentifier }, { "testReport", new[] { suite.GetInternalReport() } } },
                GeneratePlayStreamEvent = true
            };

            clientInstance.ExecuteCloudScript(request, OnCloudScriptSubmit, OnPostTestResultsError, null, testTitleData.extraHeaders);
        }

        private void OnCloudScriptSubmit(ExecuteCloudScriptResult result)
        {
            if (postResultsToCloudscript && result != null)
            {
                Debug.Log("Results posted to Cloud Script successfully: " + PlayFabSettings.BuildIdentifier + ", " + clientInstance.authenticationContext.PlayFabId);
                if (result.Logs != null)
                    foreach (var eachLog in result.Logs)
                        Debug.Log("Cloud Log: " + eachLog.Message);
            }

            if (autoQuit && !Application.isEditor)
                Application.Quit();
            else if (!suite.AllTestsPassed())
                throw new Exception("Results were not posted to Cloud Script: " + PlayFabSettings.BuildIdentifier);
        }

        private void OnPostTestResultsError(PlayFabError error)
        {
            Debug.LogWarning("Error posting results to Cloud Script:" + error.GenerateErrorReport());

            if (autoQuit && !Application.isEditor)
                Application.Quit();
            else if (!suite.AllTestsPassed())
                throw new Exception("Results were not posted to Cloud Script: " + PlayFabSettings.BuildIdentifier);
        }
#endif
    }
}
