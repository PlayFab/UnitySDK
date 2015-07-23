using System;
using System.Diagnostics;
using System.Reflection;

public class UUnitTestCase
{
    Stopwatch setUpStopwatch = new Stopwatch();
    Stopwatch tearDownStopwatch = new Stopwatch();
    Stopwatch eachTestStopwatch = new Stopwatch();
    private string testMethodName;

    public void SetTest(string testMethodName)
    {
        this.testMethodName = testMethodName;
    }

    public void Run(UUnitTestResult testResult)
    {
        setUpStopwatch.Start();
        SetUp();
        setUpStopwatch.Stop();

        testResult.TestStarted();
        bool success = false;
        string message = null;
        try
        {
            Type type = this.GetType();
            MethodInfo method = type.GetMethod(testMethodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            eachTestStopwatch.Reset();
            eachTestStopwatch.Start();
            method.Invoke(this, null);
            eachTestStopwatch.Stop();
            success = true;
        }
        catch (TargetInvocationException e)
        {
            message = e.InnerException.ToString();
            success = false;
        }
        finally
        {
            tearDownStopwatch.Start();
            TearDown();
            tearDownStopwatch.Stop();
        }

        testResult.TestComplete(success, eachTestStopwatch.ElapsedMilliseconds, message);

    }

    protected virtual void SetUp()
    {
    }

    protected virtual void TearDown()
    {
    }
}