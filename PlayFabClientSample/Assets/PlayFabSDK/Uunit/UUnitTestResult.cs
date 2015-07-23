using System.Collections.Generic;
using System.Text;

public class UUnitTestResult
{
    private int runCount = 0;
    private int successCount = 0;
    private int failedCount = 0;

    private static StringBuilder sb = new StringBuilder();
    List<string> messages = new List<string>();

    public void TestStarted()
    {
        runCount += 1;
    }

    public void TestComplete(bool success, long stopwatchMS, string message)
    {
        sb.Length = 0;
        sb.Append(stopwatchMS);
        while (sb.Length < 10)
            sb.Insert(0, ' ');
        sb.Append(" ms - ").Append(success ? "PASSED" : "FAILED");
        if (!string.IsNullOrEmpty(message))
            sb.Append(" - ").Append(message);
        messages.Add(sb.ToString());
        sb.Length = 0;

        if (success)
            successCount += 1;
        else
            failedCount += 1;
    }

    public string Summary()
    {
        sb.Length = 0;
        sb.AppendFormat("Testing complete:  {0} test run, {1} tests passed, {2} tests failed.", runCount, successCount, failedCount);
        messages.Add(sb.ToString());
        return string.Join("\n", messages.ToArray());
    }
}
