/*
 * UUnit system from UnityCommunity
 * Heavily modified
 * 0.4 release by pboechat
 * http://wiki.unity3d.com/index.php?title=UUnit
 * http://creativecommons.org/licenses/by-sa/3.0/
*/

using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;

namespace PlayFab.UUnit
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UUnitTestAttribute : Attribute
    {
    }

    public class UUnitTestSuite
    {
        private const int TIME_ALIGNMENT_WIDTH = 10;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(15);
        private static readonly StringBuilder sb = new StringBuilder();

        private readonly List<UUnitTestContext> _testContexts = new List<UUnitTestContext>();
        private int _activeIndex = 0;
        private readonly UUnitTestReport _testReport = new UUnitTestReport(PlayFabSettings.BuildIdentifier);
        private UUnitActiveState _suiteState = UUnitActiveState.PENDING;
        private UUnitTestCase activeTestInstance = null;

        public string GenerateTestSummary()
        {
            sb.Length = 0;

            DateTime now = DateTime.UtcNow, eachStartTime, eachEndTime;
            int finished = 0, passed = 0, failed = 0, skipped = 0;

            foreach (var eachContext in _testContexts)
            {
                // Count tests
                if (eachContext.ActiveState == UUnitActiveState.COMPLETE)
                {
                    finished++;
                    eachStartTime = eachContext.StartTime;
                    eachEndTime = eachContext.EndTime;
                    if (eachContext.FinishState == UUnitFinishState.PASSED)
                        passed++;
                    else if (eachContext.FinishState == UUnitFinishState.SKIPPED)
                        skipped++;
                    else
                        failed++;
                }
                else
                {
                    eachStartTime = eachContext.ActiveState == UUnitActiveState.PENDING ? now : eachContext.StartTime;
                    eachEndTime = now;
                }

                // line for each test report
                if (sb.Length != 0)
                    sb.Append("\n");
                var ms = (eachEndTime - eachStartTime).TotalMilliseconds.ToString("0");
                for (var i = ms.Length; i < TIME_ALIGNMENT_WIDTH; i++)
                    sb.Append(' ');
                sb.Append(ms).Append(" ms - ").Append(eachContext.FinishState);
                sb.Append(" - ").Append(eachContext.Name);
                if (!string.IsNullOrEmpty(eachContext.TestResultMsg))
                {
                    sb.Append(" - ").Append(eachContext.TestResultMsg);
                    // TODO: stacktrace
                }
            }

            sb.AppendFormat("\nTesting complete:  {0}/{1} test run, {2} tests passed, {3} tests failed, {4} tests skipped.", finished, _testContexts.Count, passed, failed, skipped);

            return sb.ToString();
        }

        public TestSuiteReport GetInternalReport()
        {
            return _testReport.InternalReport;
        }

        public void FindAndAddAllTestCases(Type parent, string filter = null)
        {
            if (_suiteState != UUnitActiveState.PENDING)
                throw new Exception("Must add all tests before executing tests.");

#if NETFX_CORE
            var eachAssembly = typeof(UUnitTestCase).GetTypeInfo().Assembly; // We can only load assemblies known in advance on WSA
#else
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var eachAssembly in assemblies)
#endif
                FindAndAddAllTestCases(eachAssembly, parent, filter);
        }

        public void FindAndAddAllTestCases(Assembly assembly, Type parent, string filter = null)
        {
            if (_suiteState != UUnitActiveState.PENDING)
                throw new Exception("Must add all tests before executing tests.");

            var types = assembly.GetTypes();
            foreach (var t in types)
                if (!t.GetTypeInfo().IsAbstract && t.GetTypeInfo().IsSubclassOf(parent))
                    AddTestsForType(t.AsType(), filter);
        }

        private void AddTestsForType(Type testCaseType, string filter = null)
        {
            if (_suiteState != UUnitActiveState.PENDING)
                throw new Exception("Must add all tests before executing tests.");

            var filterSet = AssembleFilter(filter);

            UUnitTestCase newTestCase = null;
            foreach (var constructorInfo in testCaseType.GetTypeInfo().GetConstructors())
            {
                try
                {
                    newTestCase = (UUnitTestCase)constructorInfo.Invoke(null);
                }
                catch (Exception) { } // Ignore it and try the next one
            }
            if (newTestCase == null)
                throw new Exception(testCaseType.Name + " must have a parameter-less constructor.");

            var methods = testCaseType.GetTypeInfo().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            List<object> attributesList = new List<object>();
            foreach (var methodInfo in methods)
            {
                attributesList.Clear();
                attributesList.AddRange(methodInfo.GetCustomAttributes(typeof(UUnitTestAttribute), false));
                if (attributesList.Count == 0 || !MatchesFilters(methodInfo.Name, filterSet)) // There can only be 1, and we only care about attribute existence (no data on attribute), and it has to match the filter
                    continue;

                Action<UUnitTestContext> eachTestDelegate = CreateDelegate<UUnitTestContext>(testCaseType.Name, newTestCase, methodInfo);
                if (eachTestDelegate != null)
                    _testContexts.Add(new UUnitTestContext(newTestCase, eachTestDelegate, methodInfo.Name));
            }
        }

        private static Action<T> CreateDelegate<T>(string typeName, object instance, MethodInfo methodInfo)
        {
            Action<T> eachTestDelegate;
            try
            {
                eachTestDelegate = methodInfo.CreateDelegate(typeof(Action<T>), instance) as Action<T>;
            }
            catch (Exception e)
            {
                var sb2 = new StringBuilder();
                sb2.Append(typeName).Append(".").Append(methodInfo.Name).Append(" must match the test delegate signature: Action<T>");
                sb2.Append("\n").Append(e);

                sb2.Append("\nExpected Params: [");
                var actionInfo = typeof(Action<T>).GetMethod("Invoke");
                foreach (var param in actionInfo.GetParameters())
                    sb2.Append(param.Name).Append(",");
                sb2.Append("]");

                sb2.Append("\nActual Params: [");
                foreach (var param in methodInfo.GetParameters())
                    sb2.Append(param.Name).Append(",");
                sb2.Append("]");
                throw new Exception(sb2.ToString());
            }
            return eachTestDelegate;
        }

        private HashSet<string> AssembleFilter(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                return null;
            var filterWords = filter.ToLower().Split(new char[] { '\n', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (filterWords.Length > 0)
                return new HashSet<string>(filterWords);
            return null;
        }

        private bool MatchesFilters(string name, HashSet<string> filterSet)
        {
            if (filterSet == null)
                return true;
            var nameLc = name.ToLower();
            foreach (var eachFilter in filterSet)
                if (nameLc.Contains(eachFilter))
                    return true;
            return false;
        }

        /// <summary>
        /// Return that tests were run, and all of them reported success
        /// </summary>
        public bool AllTestsPassed()
        {
            return _testReport.AllTestsPassed();
        }

        /// <summary>
        /// Tick the test suite.
        /// This should be called once per Update until it returns true.
        /// Once it returns true, testing is complete
        /// </summary>
        public bool TickTestSuite()
        {
            if (_suiteState == UUnitActiveState.COMPLETE)
                return true;
            if (_suiteState == UUnitActiveState.PENDING)
                _suiteState = UUnitActiveState.ACTIVE;

            var nextTest = _activeIndex < _testContexts.Count ? _testContexts[_activeIndex] : null;
            if (nextTest != null && nextTest.ActiveState == UUnitActiveState.COMPLETE)
            {
                _activeIndex++;
                nextTest = (_activeIndex >= _testContexts.Count) ? null : _testContexts[_activeIndex];
            }

            if (nextTest != null && nextTest.ActiveState == UUnitActiveState.PENDING)
                StartTest(nextTest);
            else if (nextTest != null)
                TickTest(nextTest);

            var testsDone = _activeIndex >= _testContexts.Count;
            if (testsDone && _suiteState == UUnitActiveState.ACTIVE)
            {
                _suiteState = UUnitActiveState.READY;
                ManageInstance(null, activeTestInstance); // Ensure that the final test is cleaned up
            }
            return _suiteState == UUnitActiveState.READY;
        }

        /// <summary>
        /// Start a test, track which test is active, and manage timers
        /// </summary>
        private void StartTest(UUnitTestContext testContext)
        {
            ManageInstance(testContext.TestInstance, activeTestInstance);

            testContext.StartTime = DateTime.UtcNow;
            testContext.ActiveState = UUnitActiveState.ACTIVE;
            _testReport.TestStarted();

            if (testContext.ActiveState == UUnitActiveState.ACTIVE)
                Wrap(testContext, testContext.TestInstance.SetUp);
            if (testContext.ActiveState == UUnitActiveState.ACTIVE)
                Wrap(testContext, testContext.TestDelegate);
            // Async tests can't resolve this tick, so just return
        }

        /// <summary>
        /// Ensure that exceptions in any test-functions are relayed to the testContext as failures
        /// </summary>
        private void Wrap(UUnitTestContext testContext, Action<UUnitTestContext> testFunc)
        {
            try
            {
                testFunc(testContext);
            }
            catch (UUnitSkipException uu)
            {
                // Silence the assert and ensure the test is marked as complete - The exception is just to halt the test process
                testContext.EndTest(UUnitFinishState.SKIPPED, uu.Message);
            }
            catch (UUnitException uu)
            {
                // Silence the assert and ensure the test is marked as complete - The exception is just to halt the test process
                testContext.EndTest(UUnitFinishState.FAILED, uu.Message + "\n" + uu.StackTrace);
            }
            catch (Exception e)
            {
                // Report this exception as an unhandled failure in the test
                testContext.EndTest(UUnitFinishState.FAILED, e.ToString());
            }
        }

        /// <summary>
        /// Manage the ClassSetUp and ClassTearDown functions for each UUnitTestCase
        /// </summary>
        private void ManageInstance(UUnitTestCase newtestInstance, UUnitTestCase oldTestInstance)
        {
            if (ReferenceEquals(newtestInstance, oldTestInstance))
                return;

            if (oldTestInstance != null)
                oldTestInstance.ClassTearDown();
            if (newtestInstance != null)
                newtestInstance.ClassSetUp();
            activeTestInstance = newtestInstance;
        }

        private void TickTest(UUnitTestContext testContext)
        {
            var now = DateTime.UtcNow;
            var timedOut = (now - testContext.StartTime) > TestTimeout;
            if (testContext.ActiveState != UUnitActiveState.READY && !timedOut) // Not finished & not timed out
            {
                Wrap(testContext, testContext.TestInstance.Tick);
                return;
            }
            else if (testContext.ActiveState == UUnitActiveState.ACTIVE && timedOut)
            {
                testContext.EndTest(UUnitFinishState.TIMEDOUT, "Test duration exceeded maxumum");
            }

            testContext.EndTime = now;
            Wrap(testContext, testContext.TestInstance.TearDown);
            testContext.ActiveState = UUnitActiveState.COMPLETE;
            _testReport.TestComplete(testContext.TestDelegate.Target.GetType().Name + "." + testContext.Name, testContext.FinishState, (int)(testContext.EndTime - testContext.StartTime).TotalMilliseconds, testContext.TestResultMsg, null);
        }
    }
}
