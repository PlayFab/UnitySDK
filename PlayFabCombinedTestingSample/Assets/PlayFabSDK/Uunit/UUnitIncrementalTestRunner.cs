using UnityEngine;
using System;
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

        public void Start()
        {
            suite = new UUnitTestSuite();
            suite.FindAndAddAllTestCases(typeof(UUnitTestCase));

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
                bool passed = suite.AllTestsPassed();
                if (!passed)
                    Debug.LogWarning(summary);
                else
                    Debug.Log(summary);
                if (autoQuit && !Application.isEditor)
                    Application.Quit();
                else if (!passed)
                    throw new Exception("Not all tests passed.");
            }
        }
    }
}
