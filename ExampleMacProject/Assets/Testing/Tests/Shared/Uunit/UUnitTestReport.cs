/*
 * UUnit system from UnityCommunity
 * Heavily modified
 * 0.4 release by pboechat
 * http://wiki.unity3d.com/index.php?title=UUnit
 * http://creativecommons.org/licenses/by-sa/3.0/
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayFab.UUnit
{
    public enum UUnitFinishState
    {
        PENDING,
        PASSED,
        FAILED,
        SKIPPED,
        TIMEDOUT
    }

    /// <summary>
    /// This is a wrapper around TestSuiteReport with the callbacks that let UUnitTestSuite manipulate/append results, and UUnitTestRunner display them
    /// </summary>
    public class UUnitTestReport
    {
        public readonly TestSuiteReport InternalReport = new TestSuiteReport();

        public UUnitTestReport(string classname)
        {
            InternalReport.name = classname;
            InternalReport.timestamp = DateTime.UtcNow;
        }

        public void TestStarted()
        {
            InternalReport.RecalculateCounts();
        }

        public void TestComplete(string testName, UUnitFinishState finishState, long stopwatchMs, string message, string stacktrace)
        {
            var report = new TestCaseReport
            {
                message = message,
                classname = InternalReport.name,
                failureText = finishState.ToString(),
                finishState = finishState,
                name = testName,
                time = TimeSpan.FromMilliseconds(stopwatchMs)
            };
            if (InternalReport.testResults == null)
                InternalReport.testResults = new List<TestCaseReport>();
            InternalReport.testResults.Add(report);
            InternalReport.RecalculateCounts();

            // TODO: Add hooks for SuiteSetUp and SuiteTearDown, so this can be estimated more accurately
            InternalReport.time = DateTime.UtcNow - InternalReport.timestamp; // For now, update the duration on every test complete - the last one will be essentially correct
        }

        /// <summary>
        /// Return that tests were run, and all of them reported FinishState
        /// </summary>
        public bool AllTestsPassed()
        {
            InternalReport.RecalculateCounts();
            return InternalReport.tests > 0 && InternalReport.tests == (InternalReport.passed + InternalReport.skipped) && InternalReport.failures == 0;
        }
    }

    /// <summary>
    /// Data container defining the test-suite data saved to JUnit XML format
    /// </summary>
    public class TestSuiteReport
    {
        // Part of the XML spec
        public List<TestCaseReport> testResults;
        public string name;
        public int tests { get; private set;}
        public int failures{ get; private set;}
        public int errors;
        public int skipped{ get; private set;}
        public TimeSpan time;
        public DateTime timestamp;
        public Dictionary<string, string> properties;
        // Useful for debugging but not part of the serialized format
        public int passed{ get; private set;} // Could be calculated from the others, but sometimes knowing if they don't add up means something
        public void RecalculateCounts()
        {
            tests = testResults?.Count() ?? 0;
            failures = testResults?.Where(eachReport => { return eachReport.finishState == UUnitFinishState.FAILED; }).Count() ?? 0;
            skipped = testResults?.Where(eachReport => { return eachReport.finishState == UUnitFinishState.SKIPPED; }).Count() ?? 0;
            passed = testResults?.Where(eachReport => { return eachReport.finishState == UUnitFinishState.PASSED; }).Count() ?? 0;
        }
    }

    /// <summary>
    /// Data container defining the test-case data saved to JUnit XML format
    /// </summary>
    public class TestCaseReport
    {
        public string classname;
        public string name;
        public TimeSpan time;
        // Sub-Fields in the XML spec
        /// <summary> message is the descriptive text used to debug the test failure </summary>
        public string message;
        /// <summary> The xml spec allows failureText to be an arbitrary string.  When possible it should match FinishState (But not required) </summary>
        public string failureText;
        public UUnitFinishState finishState;
        // Other parameters not part of the xml spec, used for internal debugging
        public string stacktrace;
    }
}
