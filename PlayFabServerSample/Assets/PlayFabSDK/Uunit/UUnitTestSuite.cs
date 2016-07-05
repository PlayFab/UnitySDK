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

        public string GenerateSummary()
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
                string ms = (eachEndTime - eachStartTime).TotalMilliseconds.ToString("0");
                for (int i = ms.Length; i < TIME_ALIGNMENT_WIDTH; i++)
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

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var eachAssembly in assemblies)
                FindAndAddAllTestCases(eachAssembly, parent, filter);
        }

        public void FindAndAddAllTestCases(Assembly assembly, Type parent, string filter = null)
        {
            if (_suiteState != UUnitActiveState.PENDING)
                throw new Exception("Must add all tests before executing tests.");

            var types = assembly.GetTypes();
            foreach (var t in types)
                if (!t.IsAbstract && t.IsSubclassOf(parent))
                    AddTestsForType(t, filter);
        }

        private void AddTestsForType(Type testCaseType, string filter = null)
        {
            if (_suiteState != UUnitActiveState.PENDING)
                throw new Exception("Must add all tests before executing tests.");

            var filterSet = AssembleFilter(filter);

            UUnitTestCase newTestCase = null;
            foreach (var constructorInfo in testCaseType.GetConstructors())
            {
                try
                {
                    newTestCase = (UUnitTestCase)constructorInfo.Invoke(null);
                }
                catch (Exception) { } // Ignore it and try the next one
            }
            if (newTestCase == null)
                throw new Exception(testCaseType.Name + " must have a parameter-less constructor.");

            var methods = testCaseType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MethodInfo m in methods)
            {
                var attributes = m.GetCustomAttributes(typeof(UUnitTestAttribute), false);
                if (attributes.Length == 0 || !MatchesFilters(m.Name, filterSet)) // There can only be 1, and we only care about attribute existence (no data on attribute), and it has to match the filter
                    continue;

                Action<UUnitTestContext> eachTestDelegate;
                try
                {
                    eachTestDelegate = Delegate.CreateDelegate(typeof(Action<UUnitTestContext>), newTestCase, m) as Action<UUnitTestContext>;
                }
                catch (Exception e)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(testCaseType.Name).Append(".").Append(m.Name).Append(" must match the test delegate signature: Action<UUnitTestContext>");
                    sb.Append("\n").Append(e);

                    sb.Append("\nExpected Params: [");
                    var actionInfo = typeof(Action<UUnitTestContext>).GetMethod("Invoke");
                    foreach (var param in actionInfo.GetParameters())
                        sb.Append(param.Name).Append(",");
                    sb.Append("]");

                    sb.Append("\nActual Params: [");
                    foreach (var param in m.GetParameters())
                        sb.Append(param.Name).Append(",");
                    sb.Append("]");
                    throw new Exception(sb.ToString());
                }
                if (eachTestDelegate != null)
                    _testContexts.Add(new UUnitTestContext(newTestCase, eachTestDelegate));
            }
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

            UUnitTestContext nextTest = _activeIndex < _testContexts.Count ? _testContexts[_activeIndex] : null;
            if (nextTest != null && nextTest.ActiveState == UUnitActiveState.COMPLETE)
            {
                _activeIndex++;
                nextTest = (_activeIndex >= _testContexts.Count) ? null : _testContexts[_activeIndex];
            }

            if (nextTest != null && nextTest.ActiveState == UUnitActiveState.PENDING)
                StartTest(nextTest);
            else if (nextTest != null)
                TickTest(nextTest);

            bool testsDone = _activeIndex >= _testContexts.Count;
            if (testsDone && _suiteState == UUnitActiveState.ACTIVE)
            {
                _suiteState = UUnitActiveState.READY;
                // PostTestResultsToCloudScript();
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
            DateTime now = DateTime.UtcNow;
            if (testContext.ActiveState != UUnitActiveState.READY // Not finished
                && (now - testContext.StartTime) < TestTimeout) // Not timed out
            {
                testContext.TestInstance.Tick(testContext);
                return;
            }

            testContext.EndTime = now;
            testContext.ActiveState = UUnitActiveState.COMPLETE;
            Wrap(testContext, testContext.TestInstance.TearDown);
            _testReport.TestComplete(testContext.TestDelegate.Target.GetType().Name + "." + testContext.TestDelegate.Method.Name, testContext.FinishState, (int)(testContext.EndTime - testContext.StartTime).TotalMilliseconds, testContext.TestResultMsg, null);
        }
    }
}
