using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PlayFab.UUnit;
using PlayFab.ClientModels;
using UnityEngine;

namespace PlayFab.Internal
{
    class EventTest : UUnitTestCase
    {
        private EventInstanceListener _listener;
        private static readonly HashSet<string> callbacks = new HashSet<string>();

        private class EventInstanceListener
        {
            public void Register()
            {
                // Instance methods must be cast to a delegate inside the registration function
                PlayFabSettings.RequestCallback<object> onRequestInstGl = OnRequest_InstGl; // Generic callbacks have to use the generic signature
                PlayFabSettings.ResponseCallback<object, PlayFabResultCommon> onResponseInstGl = OnResponse_InstGl; // Generic callbacks have to use the generic signature
                PlayFabClientAPI.LoginWithCustomIDRequestCallback onRequestInstLogin = OnRequest_InstLogin;
                PlayFabClientAPI.LoginWithCustomIDResponseCallback onResponseInstLogin = OnResponse_InstLogin;

                // Registering for instance methods, using the local delegate variables (bound to the "this" instance)
                PlayFabSettings.RegisterForRequests(null, onRequestInstGl);
                PlayFabSettings.RegisterForResponses(null, onResponseInstGl);
                PlayFabSettings.RegisterForRequests("/Client/LoginWithCustomID", onRequestInstLogin);
                PlayFabSettings.RegisterForResponses("/Client/LoginWithCustomID", onResponseInstLogin);

                PlayFabSettings.GlobalErrorHandler += error => { callbacks.Add(error.ErrorMessage); };
            }

            public void Unregister()
            {
                // Automatically unregisters all callbacks bound to this instance - No delegate casting or local variables needed for a full un-register
                PlayFabSettings.UnregisterInstance(this);
                PlayFabSettings.GlobalErrorHandler = null;
            }

            private void OnRequest_InstGl(string url, int callId, object request, object customData)
            {
                callbacks.Add("OnRequest_InstGl");
            }

            private void OnResponse_InstGl(string url, int callId, object request, object result, PlayFabError error, object customData)
            {
                callbacks.Add("OnResponse_InstGl");
            }

            private void OnRequest_InstLogin(string url, int callId, LoginWithCustomIDRequest request, object customData)
            {
                callbacks.Add("OnRequest_InstLogin");
            }

            private void OnResponse_InstLogin(string url, int callId, LoginWithCustomIDRequest request, LoginResult result, PlayFabError error, object customData)
            {
                callbacks.Add("OnResponse_InstLogin");
            }
        }

        private static class EventStaticListener
        {
            public static void Register()
            {
                PlayFabSettings.RegisterForRequests(null, _onRequestGl);
                PlayFabSettings.RegisterForResponses(null, _onResponseGl);
                PlayFabSettings.RegisterForRequests("/Client/LoginWithCustomID", _onRequestLogin);
                PlayFabSettings.RegisterForResponses("/Client/LoginWithCustomID", _onResponseLogin);
            }

            public static void Unregister()
            {
                PlayFabSettings.UnregisterForRequests(null, _onRequestGl);
                PlayFabSettings.UnregisterForResponses(null, _onResponseGl);
                PlayFabSettings.UnregisterForRequests("/Client/LoginWithCustomID", _onRequestLogin);
                PlayFabSettings.UnregisterForResponses("/Client/LoginWithCustomID", _onResponseLogin);
            }

            private static PlayFabSettings.RequestCallback<object> _onRequestGl = OnRequest_StaticGl; // Generic callbacks have to use the generic signature - Static methods can be cast once and saved as a static variable
            private static void OnRequest_StaticGl(string url, int callId, object request, object customData)
            {
                callbacks.Add("OnRequest_StaticGl");
            }

            private static PlayFabSettings.ResponseCallback<object, PlayFabResultCommon> _onResponseGl = OnResponse_StaticGl; // Generic callbacks have to use the generic signature - Static methods can be cast once and saved as a static variable
            private static void OnResponse_StaticGl(string url, int callId, object request, object result, PlayFabError error, object customData)
            {
                callbacks.Add("OnResponse_StaticGl");
            }

            private static PlayFabClientAPI.LoginWithCustomIDRequestCallback _onRequestLogin = OnRequest_StaticLogin; // Static methods can be cast once and saved as a static variable
            private static void OnRequest_StaticLogin(string url, int callId, LoginWithCustomIDRequest request, object customData)
            {
                callbacks.Add("OnRequest_StaticLogin");
            }

            private static PlayFabClientAPI.LoginWithCustomIDResponseCallback _onResponseLogin = OnResponse_StaticLogin; // Static methods can be cast once and saved as a static variable
            private static void OnResponse_StaticLogin(string url, int callId, LoginWithCustomIDRequest request, LoginResult result, PlayFabError error, object customData)
            {
                callbacks.Add("OnResponse_StaticLogin");
            }
        }

        public override void SetUp(UUnitTestContext testContext)
        {
            PlayFabSettings.TitleId = "6195";
            PlayFabSettings.ForceUnregisterAll();

            _listener = new EventInstanceListener();
            callbacks.Clear();

            //if (!PlayFabClientAPI.IsClientLoggedIn())
            //{
            //    // A few tests just need any valid auth token
            //    LoginWithCustomIDRequest loginRequest = new LoginWithCustomIDRequest
            //    {
            //        CreateAccount = true,
            //        CustomId = SystemInfo.deviceUniqueIdentifier
            //    };
            //    PlayFabClientAPI.LoginWithCustomID(loginRequest, null, null, testContext);
            //    // NOTE: Async callback needs to occcur before those tests run.  Probably need to upgrade the SetUp to be async-capable...
            //}
        }

        public override void Tick(UUnitTestContext testContext)
        {
            // No async work needed
        }

        public override void TearDown(UUnitTestContext testContext)
        {
            callbacks.Clear();
            PlayFabSettings.HideCallbackErrors = false;
            PlayFabSettings.ForceUnregisterAll();
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

            PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest { CreateAccount = true, CustomId = "UnitySdk-UnitTest", TitleId = "6195" }, PlayFabUUnitUtils.ApiCallbackWrapper<LoginResult>(testContext, TestInstCallbacks_GeneralOnlyCallback), PlayFabUUnitUtils.ApiErrorWrapper(testContext, SharedErrorCallback), testContext);
            testContext.True(callbacks.Contains("OnRequest_InstGl"), string.Join(", ", callbacks.ToArray()));
            testContext.True(callbacks.Contains("OnRequest_InstLogin"), string.Join(", ", callbacks.ToArray()));
            testContext.IntEquals(2, callbacks.Count, string.Join(", ", callbacks.ToArray()));
            callbacks.Clear();
        }
        private void TestInstCallbacks_GeneralOnlyCallback(LoginResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.True(callbacks.Contains("OnResponse_InstGl"), string.Join(", ", callbacks.ToArray())); // NOTE: This depends on the global callbacks happening before the local callback
            testContext.True(callbacks.Contains("OnResponse_InstLogin"), string.Join(", ", callbacks.ToArray())); // NOTE: This depends on the global callbacks happening before the local callback
            testContext.IntEquals(2, callbacks.Count, string.Join(", ", callbacks.ToArray()));
            testContext.EndTest(UUnitFinishState.PASSED, null);

            _listener.Unregister();
        }

        [UUnitTest]
        public void TestStaticCallbacks_GeneralOnly(UUnitTestContext testContext)
        {
            EventStaticListener.Register();

            PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest { CreateAccount = true, CustomId = "UnitySdk-UnitTest", TitleId = "6195" }, PlayFabUUnitUtils.ApiCallbackWrapper<LoginResult>(testContext, TestStaticCallbacks_GeneralOnlyCallback), PlayFabUUnitUtils.ApiErrorWrapper(testContext, SharedErrorCallback), testContext);
            CheckCallbacks(testContext, "OnRequest_StaticGl", callbacks);
            CheckCallbacks(testContext, "OnRequest_StaticLogin", callbacks);
            testContext.IntEquals(2, callbacks.Count, string.Join(", ", callbacks.ToArray()));
            callbacks.Clear();

        }
        private void TestStaticCallbacks_GeneralOnlyCallback(LoginResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            // NOTE: This depends on the global callbacks happening before the local callback
            CheckCallbacks(testContext, "OnResponse_StaticGl", callbacks);
            CheckCallbacks(testContext, "OnResponse_StaticLogin", callbacks);
            testContext.IntEquals(2, callbacks.Count, string.Join(", ", callbacks.ToArray()));
            testContext.EndTest(UUnitFinishState.PASSED, null);

            EventStaticListener.Unregister();
        }

        [UUnitTest]
        public void TestInstCallbacks_Local(UUnitTestContext testContext)
        {
            _listener.Register();

            PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest { CreateAccount = true, CustomId = "UnitySdk-UnitTest", TitleId = "6195" }, PlayFabUUnitUtils.ApiCallbackWrapper<LoginResult>(testContext, TestInstCallbacks_LocalCallback), PlayFabUUnitUtils.ApiErrorWrapper(testContext, SharedErrorCallback), testContext);
            CheckCallbacks(testContext, "OnRequest_InstGl", callbacks);
            CheckCallbacks(testContext, "OnRequest_InstLogin", callbacks);
            testContext.IntEquals(2, callbacks.Count, string.Join(", ", callbacks.ToArray()));
            callbacks.Clear();
        }
        private void TestInstCallbacks_LocalCallback(LoginResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            // NOTE: This depends on the global callbacks happening before the local callback
            CheckCallbacks(testContext, "OnResponse_InstGl", callbacks);
            CheckCallbacks(testContext, "OnResponse_InstLogin", callbacks);
            testContext.IntEquals(2, callbacks.Count, string.Join(", ", callbacks.ToArray()));
            testContext.EndTest(UUnitFinishState.PASSED, null);

            _listener.Unregister();
        }

        [UUnitTest]
        public void TestStaticCallbacks_Local(UUnitTestContext testContext)
        {
            EventStaticListener.Register();

            PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest { CreateAccount = true, CustomId = "UnitySdk-UnitTest", TitleId = "6195" }, PlayFabUUnitUtils.ApiCallbackWrapper<LoginResult>(testContext, TestStaticCallbacks_LocalCallback), PlayFabUUnitUtils.ApiErrorWrapper(testContext, SharedErrorCallback), testContext);
            CheckCallbacks(testContext, "OnRequest_StaticGl", callbacks);
            CheckCallbacks(testContext, "OnRequest_StaticLogin", callbacks);
            testContext.IntEquals(2, callbacks.Count, string.Join(", ", callbacks.ToArray()));
            callbacks.Clear();
        }
        private void TestStaticCallbacks_LocalCallback(LoginResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            // NOTE: This depends on the global callbacks happening before the local callback
            CheckCallbacks(testContext, "OnResponse_StaticGl", callbacks);
            CheckCallbacks(testContext, "OnResponse_StaticLogin", callbacks);
            testContext.IntEquals(2, callbacks.Count, string.Join(", ", callbacks.ToArray()));
            testContext.EndTest(UUnitFinishState.PASSED, null);

            EventStaticListener.Unregister();
        }

        /// <summary>
        /// The user can provide functions that throw errors on callbacks.
        /// These should not affect the PlayFab api system itself.
        /// </summary>
        [UUnitTest]
        public void TestCallbackFailuresGlobal(UUnitTestContext testContext)
        {
            PlayFabSettings.HideCallbackErrors = true;
            PlayFabSettings.RegisterForResponses(null, (PlayFabSettings.ResponseCallback<object, PlayFabResultCommon>)SuccessCallback_Global);

            GetCatalogItemsRequest catalogRequest = new GetCatalogItemsRequest();
            PlayFabClientAPI.GetCatalogItems(catalogRequest, PlayFabUUnitUtils.ApiCallbackWrapper<GetCatalogItemsResult>(testContext, GetCatalogItemsCallback_Single), PlayFabUUnitUtils.ApiErrorWrapper(testContext, SharedErrorCallback), testContext);
        }
        private static void SuccessCallback_Global(string urlPath, int callId, object request, PlayFabResultCommon result, PlayFabError error, object customData)
        {
            callbacks.Add("SuccessCallback_Global");
            throw new Exception("Non-PlayFab callback error");
        }
        private static void GetCatalogItemsCallback_Single(GetCatalogItemsResult result)
        {
            callbacks.Add("GetCatalogItemsCallback_Single");

            var testContext = (UUnitTestContext)result.CustomData;
            // NOTE: This depends on the global callbacks happening before the local callback
            CheckCallbacks(testContext, "GetCatalogItemsCallback_Single", callbacks);
            CheckCallbacks(testContext, "SuccessCallback_Global", callbacks);
            testContext.IntEquals(2, callbacks.Count, string.Join(",", callbacks.ToArray()));
            testContext.EndTest(UUnitFinishState.PASSED, "");
        }

        /// <summary>
        /// The user can provide functions that throw errors on callbacks.
        /// These should not affect the PlayFab api system itself.
        /// </summary>
        [UUnitTest]
        public void TestCallbackFailuresLocal(UUnitTestContext testContext)
        {
            PlayFabSettings.HideCallbackErrors = true;
            PlayFabSettings.GlobalErrorHandler += SharedError_Global;

            RegisterPlayFabUserRequest registerRequest = new RegisterPlayFabUserRequest(); // A bad request that will fail
            PlayFabClientAPI.RegisterPlayFabUser(registerRequest, null, PlayFabUUnitUtils.ApiErrorWrapper(testContext, SharedError_Single), testContext);
        }
        private static void SharedError_Global(PlayFabError error)
        {
            callbacks.Add("SharedError_Global");
            throw new Exception("Non-PlayFab callback error");
        }
        private static void SharedError_Single(PlayFabError error)
        {
            callbacks.Add("SharedError_Single");

            var testContext = (UUnitTestContext)error.CustomData;
            // NOTE: This depends on the global callbacks happening before the local callback
            CheckCallbacks(testContext, "SharedError_Single", callbacks);
            CheckCallbacks(testContext, "SharedError_Global", callbacks);
            testContext.IntEquals(2, callbacks.Count, string.Join(",", callbacks.ToArray()));
            testContext.EndTest(UUnitFinishState.PASSED, "");
        }
    }
}
