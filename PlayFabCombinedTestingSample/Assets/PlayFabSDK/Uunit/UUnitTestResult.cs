/*
 * UUnit system from UnityCommunity
 * Heavily modified
 * 0.4 release by pboechat
 * http://wiki.unity3d.com/index.php?title=UUnit
 * http://creativecommons.org/licenses/by-sa/3.0/
*/

using System.Collections.Generic;
using System.Text;

namespace PlayFab.UUnit
{
    public class UUnitTestResult
    {
        public enum TestState
        {
            PASSED,
            FAILED,
            SKIPPED,
        }

        private int runCount = 0, successCount = 0, failedCount = 0, skippedCount = 0;

        private static StringBuilder sb = new StringBuilder();
        List<string> messages = new List<string>();

        public void TestStarted()
        {
            runCount += 1;
        }

        public void TestComplete(string testName, TestState success, long stopwatchMS, string message) // TODO: Separate the message and the stack-trace for improved formatting
        {
            sb.Length = 0;
            sb.Append(stopwatchMS);
            while (sb.Length < 10)
                sb.Insert(0, ' ');
            sb.Append(" ms - ").Append(success.ToString());
            sb.Append(" - ").Append(testName);
            if (!string.IsNullOrEmpty(message))
                sb.Append(" - ").Append(message);
            messages.Add(sb.ToString());
            sb.Length = 0;

            switch (success)
            {
                case (TestState.PASSED):
                    successCount += 1; break;
                case (TestState.FAILED):
                    failedCount += 1; break;
                case (TestState.SKIPPED):
                    skippedCount += 1; break;
            }
        }

        public string Summary()
        {
            sb.Length = 0;
            sb.AppendFormat("Testing complete:  {0} test run, {1} tests passed, {2} tests failed, {3} tests skipped.", runCount, successCount, failedCount, skippedCount);
            messages.Add(sb.ToString());
            return string.Join("\n", messages.ToArray());
        }

        /// <summary>
        /// Return that tests were run, and all of them reported success
        /// </summary>
        public bool AllTestsPassed()
        {
            return runCount > 0 && runCount == (successCount + skippedCount) && failedCount == 0;
        }
    }
}
