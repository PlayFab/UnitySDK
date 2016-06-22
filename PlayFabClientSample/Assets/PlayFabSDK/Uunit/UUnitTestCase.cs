/*
 * UUnit system from UnityCommunity
 * Heavily modified
 * 0.4 release by pboechat
 * http://wiki.unity3d.com/index.php?title=UUnit
 * http://creativecommons.org/licenses/by-sa/3.0/
*/

using System;
using System.Diagnostics;
using System.Reflection;

namespace PlayFab.UUnit
{
    public class UUnitTestCase
    {
        private delegate void UUnitTestDelegate();

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
            UUnitTestResult.TestState testState = UUnitTestResult.TestState.FAILED;
            string message = null;
            eachTestStopwatch.Reset();
            setUpStopwatch.Reset();
            tearDownStopwatch.Reset();

            try
            {
                testResult.TestStarted();

                setUpStopwatch.Start();
                SetUp();
                setUpStopwatch.Stop();

                Type type = this.GetType();
                MethodInfo method = type.GetMethod(testMethodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                UUnitAssert.NotNull(method, "Could not execute: " + testMethodName + ", it's probably not public."); // Limited access to loaded assemblies
                eachTestStopwatch.Start();
                method.Invoke(this, null);
                testState = UUnitTestResult.TestState.PASSED;
            }
            catch (UUnitSkipException)
            {
                // message remains null
                testState = UUnitTestResult.TestState.SKIPPED;
            }
            catch (UUnitAssertException e)
            {
                message = e.ToString();
                testState = UUnitTestResult.TestState.FAILED;
            }
            catch (TargetInvocationException e)
            {
                if (e.InnerException is UUnitSkipException)
                {
                    // message remains null
                    testState = UUnitTestResult.TestState.SKIPPED;
                }
                else
                {
                    message = e.InnerException.ToString();
                    testState = UUnitTestResult.TestState.FAILED;
                }
            }
            catch (Exception e)
            {
                message = e.ToString();
                testState = UUnitTestResult.TestState.FAILED;
            }
            finally
            {
                eachTestStopwatch.Stop();

                if (testState != UUnitTestResult.TestState.SKIPPED)
                {
                    try
                    {
                        tearDownStopwatch.Start();
                        TearDown();
                        tearDownStopwatch.Stop();
                    }
                    catch (Exception e)
                    {
                        message = e.ToString();
                        testState = UUnitTestResult.TestState.FAILED;
                    }
                }
            }

            testResult.TestComplete(testMethodName, testState, eachTestStopwatch.ElapsedMilliseconds, message);
        }

        protected virtual void SetUp()
        {
        }

        protected virtual void TearDown()
        {
        }
    }
}
