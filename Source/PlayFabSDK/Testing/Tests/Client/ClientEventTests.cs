#if !DISABLE_PLAYFABCLIENT_API

using System;
using System.Collections.Generic;
using System.Linq;
using PlayFab.ClientModels;
using PlayFab.Events;
using PlayFab.Internal;
using PlayFab.SharedModels;

namespace PlayFab.UUnit
{
    public class ClientEventTest : UUnitTestCase
    {
        private static readonly HashSet<string> Callbacks = new HashSet<string>();
        private static PlayFabEvents _playFabEvents;
        private EventInstanceListener _listener;

        private PlayFabClientInstanceAPI clientApi = new PlayFabClientInstanceAPI();

        private class EventInstanceListener
        {
            public void Register()
            {
                _playFabEvents = PlayFabEvents.Init();

                _playFabEvents.OnLoginWithCustomIDRequestEvent += OnLoginWithCustomId;
                _playFabEvents.OnLoginResultEvent += OnLoginResult;
            }

            public void Unregister()
            {
                _playFabEvents.UnregisterInstance(this);
            }

            private void OnLoginResult(LoginResult result)
            {
                Callbacks.Add("OnResponse_InstLogin");
            }

            private void OnLoginWithCustomId(LoginWithCustomIDRequest request)
            {
                Callbacks.Add("OnRequest_InstLogin");
            }
        }

        public override void SetUp(UUnitTestContext testContext)
        {
            var testTitleData = TestTitleDataLoader.LoadTestTitleData();
            PlayFabSettings.TitleId = testTitleData.titleId;

            _listener = new EventInstanceListener();
            Callbacks.Clear();
        }

        public override void Tick(UUnitTestContext testContext)
        {
            // No async work needed
        }

        public override void TearDown(UUnitTestContext testContext)
        {
            Callbacks.Clear();
            _listener.Unregister();
            PlayFabHttp.ClearAllEvents();
        }

        public override void ClassTearDown()
        {
            PlayFabSettings.staticPlayer.ForgetAllCredentials();
        }

        private void SharedErrorCallback(PlayFabError error)
        {
            ((UUnitTestContext)error.CustomData).Fail(error.GenerateErrorReport());
        }

        private static void CheckCallbacks(UUnitTestContext testContext, string expected, HashSet<string> actual)
        {
            testContext.True(actual.Contains(expected), "Want: " + expected + ", Got: " + string.Join(", ", actual.ToArray()));
        }

        [UUnitTest]
        public void TestInstCallbacks_GeneralOnly(UUnitTestContext testContext)
        {
            _listener.Register();
            PlayFabHttp.ApiProcessingEventHandler += TestInstCallbacks_GeneralOnly_OnGlobalEventHandler;

            var request = new LoginWithCustomIDRequest { CreateAccount = true, CustomId = PlayFabSettings.BuildIdentifier };
            clientApi.LoginWithCustomID(request,
                PlayFabUUnitUtils.ApiActionWrapper<LoginResult>(testContext, TestInstCallbacks_GeneralOnlyCallback),
                PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
            CheckCallbacks(testContext, "OnRequest_InstGl", Callbacks);
            CheckCallbacks(testContext, "OnRequest_InstLogin", Callbacks);
            testContext.IntEquals(2, Callbacks.Count, string.Join(", ", Callbacks.ToArray()));
            Callbacks.Clear();
        }
        private void TestInstCallbacks_GeneralOnly_OnGlobalEventHandler(ApiProcessingEventArgs eventArgs)
        {
            if (eventArgs.ApiEndpoint != "/Client/LoginWithCustomID")
                return;

            if (eventArgs.EventType == ApiProcessingEventType.Pre)
            {
                Callbacks.Add("OnRequest_InstGl");
            }
            else if (eventArgs.EventType == ApiProcessingEventType.Post)
            {
                Callbacks.Add("OnResponse_InstGl");
            }
        }
        private void TestInstCallbacks_GeneralOnlyCallback(LoginResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            // NOTE: This depends on the global callbacks happening before the local callback
            CheckCallbacks(testContext, "OnResponse_InstGl", Callbacks);
            CheckCallbacks(testContext, "OnResponse_InstLogin", Callbacks);
            testContext.IntEquals(2, Callbacks.Count, string.Join(", ", Callbacks.ToArray()));
            testContext.EndTest(UUnitFinishState.PASSED, null);

            _listener.Unregister();
        }

        /// <summary>
        /// The user can provide functions that throw errors on callbacks.
        /// These should not affect the PlayFab api system itself.
        /// </summary>
        [UUnitTest]
        public void TestCallbackFailuresGlobal(UUnitTestContext testContext)
        {
            PlayFabHttp.ApiProcessingEventHandler += TestCallbackFailuresGlobal_OnGlobalEventHandler;

            var catalogRequest = new GetCatalogItemsRequest();
            clientApi.GetCatalogItems(catalogRequest,
                PlayFabUUnitUtils.ApiActionWrapper<GetCatalogItemsResult>(testContext, GetCatalogItemsCallback_Single),
                PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback),
                testContext);
        }
        private void TestCallbackFailuresGlobal_OnGlobalEventHandler(ApiProcessingEventArgs eventArgs)
        {
            Callbacks.Add("SuccessCallback_Global");
            throw new Exception("Non-PlayFab callback error");
        }
        private static void GetCatalogItemsCallback_Single(GetCatalogItemsResult result)
        {
            Callbacks.Add("GetCatalogItemsCallback_Single");

            var testContext = (UUnitTestContext)result.CustomData;
            // NOTE: This depends on the global callbacks happening before the local callback
            CheckCallbacks(testContext, "GetCatalogItemsCallback_Single", Callbacks);
            CheckCallbacks(testContext, "SuccessCallback_Global", Callbacks);
            testContext.IntEquals(2, Callbacks.Count, string.Join(",", Callbacks.ToArray()));
            testContext.EndTest(UUnitFinishState.PASSED, "");
        }

        /// <summary>
        /// The user can provide functions that throw errors on callbacks.
        /// These should not affect the PlayFab api system itself.
        /// </summary>
        [UUnitTest]
        public void TestCallbackFailuresLocal(UUnitTestContext testContext)
        {
            PlayFabHttp.ApiProcessingErrorEventHandler += SharedError_Global;

            var registerRequest = new RegisterPlayFabUserRequest(); // A bad request that will fail
            clientApi.RegisterPlayFabUser(registerRequest, null, PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedError_Single), testContext);
        }
        private static void SharedError_Global(PlayFabRequestCommon request, PlayFabError error)
        {
            Callbacks.Add("SharedError_Global");
            throw new Exception("Non-PlayFab callback error");
        }
        private static void SharedError_Single(PlayFabError error)
        {
            Callbacks.Add("SharedError_Single");

            var testContext = (UUnitTestContext)error.CustomData;
            CheckCallbacks(testContext, "SharedError_Single", Callbacks);
            CheckCallbacks(testContext, "SharedError_Global", Callbacks);
            testContext.IntEquals(2, Callbacks.Count, string.Join(",", Callbacks.ToArray()));
            testContext.EndTest(UUnitFinishState.PASSED, "");
        }
    }
}

#endif
