using System;

namespace PlayFab.UUnit
{
    /// <summary>
    /// Provide some default async-callback wrappers that demonstrate how to catch exceptions in callbacks and report them as failures
    /// A super-general solution is elusive and difficult.  Can't really come up with anything that doesn't massively break the interface.
    /// These are ONLY meant to be used by the PlayFab UUnit test framework
    ///
    /// Every async call that is part of a test should be wrapped like this to ensure that exceptions are relayed to the testContext as failures, including UUnit-asserts.
    /// If a UUnit exception is visible in the Unity exception log, an async callback wasn't properly wrapped.
    ///
    /// Unfortunately, due to limitations in C#, every callback signature must have a unique wrapper function in this style.
    /// </summary>
    public static class PlayFabUUnitUtils
    {
        /// <summary>
        /// Test-wrapper callback for API-Callbacks
        /// If there are unhandled exceptions in those tests, make sure it gets reported to the test as a failure
        /// This is ONLY meant to be used by the PlayFab UUnit test framework
        /// </summary>
        public static Action<T> ApiActionWrapper<T>(UUnitTestContext testContext, Action<T> myfunc)
        {
            Action<T> subWrapper = (response) =>
            {
                try
                {
                    if (myfunc != null)
                        myfunc(response);
                }
                catch (UUnitException uu)
                {
                    // Silence the assert and ensure the test is marked as complete - The exception is just to halt the test process
                    testContext.EndTest(testContext.FinishState, uu.Message + "\n" + uu.StackTrace);
                }
                catch (Exception e)
                {
                    // Report this exception as an unhandled failure in the test
                    testContext.EndTest(UUnitFinishState.FAILED, e.ToString());
                }
            };
            return subWrapper;
        }

        /// <summary>
        /// Test-wrapper callback for Simple, non PlayFab error backed API-Callbacks
        /// If there are unhandled exceptions in those tests, make sure it gets reported to the test as a failure
        /// This is ONLY meant to be used by the PlayFab UUnit test framework
        /// </summary>
        public static Action<T> SimpleApiActionWrapper<T>(UUnitTestContext testContext, Action<UUnitTestContext, T> myfunc)
        {
            Action<T> subWrapper = (response) =>
            {
                try
                {
                    if (myfunc != null)
                        myfunc(testContext, response);
                }
                catch (UUnitException uu)
                {
                    // Silence the assert and ensure the test is marked as complete - The exception is just to halt the test process
                    testContext.EndTest(testContext.FinishState, uu.Message + "\n" + uu.StackTrace);
                }
                catch (Exception e)
                {
                    // Report this exception as an unhandled failure in the test
                    testContext.EndTest(UUnitFinishState.FAILED, e.ToString());
                }
            };
            return subWrapper;
        }
    }
}
