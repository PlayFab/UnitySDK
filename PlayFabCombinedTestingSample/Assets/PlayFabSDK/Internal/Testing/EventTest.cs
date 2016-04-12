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
        private static HashSet<string> callbacks = new HashSet<string>();

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

        protected override void SetUp()
        {
            PlayFabSettings.TitleId = "6195";
            PlayFabHTTP.instance.Awake();
            PlayFabSettings.RequestType = WebRequestType.HttpWebRequest;
            PlayFabSettings.ForceUnregisterAll();
        }

        private void WaitForApiCalls()
        {
            DateTime expireTime = DateTime.UtcNow + TimeSpan.FromSeconds(3);
            while (PlayFabHTTP.GetPendingMessages() != 0 && DateTime.UtcNow < expireTime)
            {
                Thread.Sleep(1); // Wait for the threaded call to be executed
                PlayFabHTTP.instance.Update(); // Invoke the callbacks for any threaded messages
            }
            UUnitAssert.True(DateTime.UtcNow < expireTime, "Request timed out");
        }

        [UUnitTest]
        public void TestInstCallbacks_GeneralOnly()
        {
            var listener = new EventInstanceListener();
            listener.Register();
            callbacks.Clear();
            PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest { CreateAccount = true, CustomId = "UnitySdk-UnitTest", TitleId = "6195" }, null, null);
            UUnitAssert.True(callbacks.Contains("OnRequest_InstGl"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.True(callbacks.Contains("OnRequest_InstLogin"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.IntEquals(2, callbacks.Count, string.Join(", ", callbacks.ToArray()));
            callbacks.Clear();
            WaitForApiCalls();
            UUnitAssert.True(callbacks.Contains("OnResponse_InstGl"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.True(callbacks.Contains("OnResponse_InstLogin"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.IntEquals(2, callbacks.Count, string.Join(", ", callbacks.ToArray()));
            listener.Unregister();
        }

        [UUnitTest]
        public void TestStaticCallbacks_GeneralOnly()
        {
            EventStaticListener.Register();
            callbacks.Clear();
            PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest { CreateAccount = true, CustomId = "UnitySdk-UnitTest", TitleId = "6195" }, null, null);
            UUnitAssert.True(callbacks.Contains("OnRequest_StaticGl"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.True(callbacks.Contains("OnRequest_StaticLogin"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.IntEquals(2, callbacks.Count, string.Join(", ", callbacks.ToArray()));
            callbacks.Clear();
            WaitForApiCalls();
            UUnitAssert.True(callbacks.Contains("OnResponse_StaticGl"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.True(callbacks.Contains("OnResponse_StaticLogin"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.IntEquals(2, callbacks.Count, string.Join(", ", callbacks.ToArray()));
            EventStaticListener.Unregister();
        }

        [UUnitTest]
        public void TestInstCallbacks_LocalCallback()
        {
            var listener = new EventInstanceListener();
            listener.Register();
            callbacks.Clear();
            PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest { CreateAccount = true, CustomId = "UnitySdk-UnitTest", TitleId = "6195" }, OnSuccessLocal, null);
            UUnitAssert.True(callbacks.Contains("OnRequest_InstGl"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.True(callbacks.Contains("OnRequest_InstLogin"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.IntEquals(2, callbacks.Count, string.Join(", ", callbacks.ToArray()));
            callbacks.Clear();
            WaitForApiCalls();
            UUnitAssert.True(callbacks.Contains("OnResponse_InstGl"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.True(callbacks.Contains("OnResponse_InstLogin"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.True(callbacks.Contains("OnSuccessLocal"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.IntEquals(3, callbacks.Count, string.Join(", ", callbacks.ToArray()));
            listener.Unregister();
        }

        [UUnitTest]
        public void TestStaticCallbacks_LocalCallback()
        {
            EventStaticListener.Register();
            callbacks.Clear();
            PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest { CreateAccount = true, CustomId = "UnitySdk-UnitTest", TitleId = "6195" }, OnSuccessLocal, null);
            UUnitAssert.True(callbacks.Contains("OnRequest_StaticGl"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.True(callbacks.Contains("OnRequest_StaticLogin"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.IntEquals(2, callbacks.Count, string.Join(", ", callbacks.ToArray()));
            callbacks.Clear();
            WaitForApiCalls();
            UUnitAssert.True(callbacks.Contains("OnResponse_StaticGl"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.True(callbacks.Contains("OnResponse_StaticLogin"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.True(callbacks.Contains("OnSuccessLocal"), string.Join(", ", callbacks.ToArray()));
            UUnitAssert.IntEquals(3, callbacks.Count, string.Join(", ", callbacks.ToArray()));
            EventStaticListener.Unregister();
        }

        private void OnSuccessLocal(LoginResult result)
        {
            callbacks.Add("OnSuccessLocal");
        }

        /// <summary>
        /// The user can provide functions that throw errors on callbacks.
        /// These should not affect the PlayFab api system itself.
        /// </summary>
        [UUnitTest]
        public void TestCallbackFailures()
        {
            PlayFabSettings.HideCallbackErrors = true;
            // Just need any valid auth token for this test
            LoginWithCustomIDRequest loginRequest = new LoginWithCustomIDRequest();
            loginRequest.CreateAccount = true;
            loginRequest.CustomId = SystemInfo.deviceUniqueIdentifier;
            PlayFabClientAPI.LoginWithCustomID(loginRequest, null, null);
            WaitForApiCalls();

            PlayFabSettings.RegisterForResponses(null, (PlayFabSettings.ResponseCallback<object, PlayFabResultCommon>)SuccessCallback_Global);
            PlayFabSettings.GlobalErrorHandler += SharedError_Global;
            callbacks.Clear();

            GetCatalogItemsRequest catalogRequest = new GetCatalogItemsRequest();
            PlayFabClientAPI.GetCatalogItems(catalogRequest, GetCatalogItemsCallback_Single, SharedError_Single);
            WaitForApiCalls();
            UUnitAssert.True(callbacks.Contains("GetCatalogItemsCallback_Single"), "GetCatalogItemsCallback_Single"); // All success callbacks should occur, even if some throw exceptions
            UUnitAssert.True(callbacks.Contains("SuccessCallback_Global"), "SuccessCallback_Global"); // All success callbacks should occur, even if some throw exceptions
            UUnitAssert.False(callbacks.Contains("SharedError_Single"), "SharedError_Single"); // Successful calls should not invoke error-callbacks (even when callbacks throw exceptions)
            UUnitAssert.False(callbacks.Contains("SharedError_Global"), "SharedError_Global"); // Successful calls should not invoke error-callbacks (even when callbacks throw exceptions)
            UUnitAssert.IntEquals(2, callbacks.Count);
            callbacks.Clear();

            RegisterPlayFabUserRequest registerRequest = new RegisterPlayFabUserRequest();
            PlayFabClientAPI.RegisterPlayFabUser(registerRequest, RegisterPlayFabUserCallback_Single, SharedError_Single);
            WaitForApiCalls();
            UUnitAssert.False(callbacks.Contains("GetCatalogItemsCallback_Single"), "GetCatalogItemsCallback_Single"); // Success should not have occurred
            UUnitAssert.False(callbacks.Contains("SuccessCallback_Global"), "SuccessCallback_Global"); // Success should not have occurred
            UUnitAssert.True(callbacks.Contains("SharedError_Single"), "SharedError_Single"); // All error callbacks should occur, even if some throw exceptions
            UUnitAssert.True(callbacks.Contains("SharedError_Global"), "SharedError_Global"); // All error callbacks should occur, even if some throw exceptions
            UUnitAssert.IntEquals(2, callbacks.Count);
            callbacks.Clear();
            PlayFabSettings.HideCallbackErrors = false;
            PlayFabSettings.ForceUnregisterAll();
        }
        private static void GetCatalogItemsCallback_Single(GetCatalogItemsResult result)
        {
            callbacks.Add("GetCatalogItemsCallback_Single");
            throw new Exception("Non-PlayFab callback error");
        }
        private static void RegisterPlayFabUserCallback_Single(RegisterPlayFabUserResult result)
        {
            callbacks.Add("RegisterPlayFabUserCallback_Single");
            throw new Exception("Non-PlayFab callback error");
        }
        private static void SharedError_Single(PlayFabError error)
        {
            callbacks.Add("SharedError_Single");
            throw new Exception("Non-PlayFab callback error");
        }
        private static void SuccessCallback_Global(string urlPath, int callId, object request, PlayFabResultCommon result, PlayFabError error, object customData)
        {
            callbacks.Add("SuccessCallback_Global");
            throw new Exception("Non-PlayFab callback error");
        }
        private static void SharedError_Global(PlayFabError error)
        {
            callbacks.Add("SharedError_Global");
            throw new Exception("Non-PlayFab callback error");
        }
    }
}
