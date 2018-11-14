#if ENABLE_PLAYFABPUBSUB_API

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayFab.UUnit
{
    public class PubSubTest : UUnitTestCase
    {
        static PlayFab.EventsModels.EntityKey _MyEntityKey = null;
        static string _previousTitleId = null;

        private PubSub pubSub;

        TimeSpan writeDelay = new TimeSpan(0, 0, 0, 3);
        DateTime nextWrite;

        private const string ns = "com.playfab.events.test";
        private const string testName = "testevent";

        public override void SetUp(UUnitTestContext testContext)
        {
            // specific title id for relay test
            _previousTitleId = PlayFabSettings.TitleId;
            PlayFabSettings.TitleId = "70B02F89";
            PlayFabSettings.VerticalName = "spi";
            UpdateNextWriteTime();
        }

        private void UpdateNextWriteTime()
        {
            nextWrite = DateTime.Now + writeDelay;
        }

        public override void Tick(UUnitTestContext testContext)
        {
            if (pubSub != null && pubSub.State == PersistentSocketState.Opened && DateTime.Now > nextWrite)
            {
                UpdateNextWriteTime();
                EventsModels.WriteEventsRequest req = new EventsModels.WriteEventsRequest();

                EventsModels.EventContents ec = new EventsModels.EventContents();

                ec.Entity = new EventsModels.EntityKey();
                ec.Entity.Id = _MyEntityKey.Id;
                ec.Entity.Type = _MyEntityKey.Type;
                ec.Name = testName;

                ec.EventNamespace = ns;
                ec.PayloadJSON = $"{{\"CurrentTime\" : \"{DateTime.Now}\"}}";

                req.Events = new List<EventsModels.EventContents>();
                req.Events.Add(ec);

                PlayFabEventsAPI.WriteEvents(req, null, null);
            }
        }

        public override void TearDown(UUnitTestContext testContext)
        {
            PlayFabSettings.TitleId = _previousTitleId;
            PlayFabSettings.VerticalName = null;
        }

        public override void ClassTearDown()
        {
        }

        [UUnitTest]
        public void TestPubSubConstruction(UUnitTestContext testContext)
        {
            ClientModels.LoginWithCustomIDRequest login = new ClientModels.LoginWithCustomIDRequest();
            login.CustomId = "PersistentSocketsUnityUnitTest" + Guid.NewGuid().ToString();
            login.CreateAccount = true;
            PlayFabClientAPI.LoginWithCustomID(login, LoginSuccess, LoginFailure, testContext);
        }

        void LoginSuccess(ClientModels.LoginResult result)
        {
            _MyEntityKey = new PlayFab.EventsModels.EntityKey { Id = result.EntityToken.Entity.Id, Type = result.EntityToken.Entity.Type };

            pubSub = new PubSub(message =>
            {
                ((UUnitTestContext)result.CustomData).EndTest(UUnitFinishState.PASSED, "");
            },
            new Topic { EventNamespace = "com.playfab.events.test", Name = "testevent", Entity = new Entity { Type = _MyEntityKey.Type, Id = _MyEntityKey.Id } });
        }

        void LoginFailure(PlayFab.PlayFabError error)
        {
            ((UUnitTestContext)error.CustomData).Fail("PubSub UnitTest Login Failed with the message: " + error.GenerateErrorReport());
        }
    }
}

#endif
