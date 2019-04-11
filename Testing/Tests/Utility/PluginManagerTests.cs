#if !DISABLE_PLAYFABCLIENT_API
using System;

namespace PlayFab.UUnit
{
    public class PluginManagerTests : UUnitTestCase
    {
        private class CustomSerializerPlugin : ISerializerPlugin
        {
            public T DeserializeObject<T>(string serialized)
            {
                throw new NotImplementedException();
            }

            public T DeserializeObject<T>(string serialized, object serializerStrategy)
            {
                throw new NotImplementedException();
            }

            public object DeserializeObject(string serialized)
            {
                throw new NotImplementedException();
            }

            public string SerializeObject(object obj)
            {
                throw new NotImplementedException();
            }

            public string SerializeObject(object obj, object serializerStrategy)
            {
                throw new NotImplementedException();
            }
        }

        private class CustomTransportPlugin : ITransportPlugin
        {
            public string Name;

            public bool IsInitialized
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public int GetPendingMessages()
            {
                throw new NotImplementedException();
            }

            public void Initialize()
            {
                throw new NotImplementedException();
            }

            public void MakeApiCall(object reqContainer)
            {
                throw new NotImplementedException();
            }

            public void OnDestroy()
            {
                throw new NotImplementedException();
            }

            public void SimpleGetCall(string fullUrl, Action<byte[]> successCallback, Action<string> errorCallback)
            {
                throw new NotImplementedException();
            }

            public void SimplePutCall(string fullUrl, byte[] payload, Action<byte[]> successCallback, Action<string> errorCallback)
            {
                throw new NotImplementedException();
            }

            public void SimplePostCall(string fullUrl, byte[] payload, Action<byte[]> successCallback, Action<string> errorCallback)
            {
                throw new NotImplementedException();
            }

            public void Update()
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Test that plugin manager returns default plugins if they are not set.
        /// </summary>
        [UUnitTest]
        public void PluginManagerDefaultPlugins(UUnitTestContext testContext)
        {
            var playFabSerializer = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);
            var playFabTransport = PluginManager.GetPlugin<ITransportPlugin>(PluginContract.PlayFab_Transport);

            testContext.NotNull(playFabSerializer);
            testContext.NotNull(playFabTransport);
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        /// <summary>
        /// Test that plugin manager can set and return a custom plugin.
        /// </summary>
        [UUnitTest]
        public void PluginManagerCustomPlugin(UUnitTestContext testContext)
        {
            var playFabSerializer = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);
            var expectedSerializer = new CustomSerializerPlugin();
            try
            {
                // Set a custom serializer plugin
                PluginManager.SetPlugin(expectedSerializer, PluginContract.PlayFab_Serializer);

                // Get serializer plugin from manager
                var actualSerializer = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);

                // Verify
                testContext.True(object.ReferenceEquals(actualSerializer, expectedSerializer));
                testContext.EndTest(UUnitFinishState.PASSED, null);
            }
            finally
            {
                // Restore the original plugin
                PluginManager.SetPlugin(playFabSerializer, PluginContract.PlayFab_Serializer);
            }
        }

        /// <summary>
        /// Test that plugin manager can set and return multiple plugins per contract.
        /// </summary>
        [UUnitTest]
        public void PluginManagerMultiplePluginsPerContract(UUnitTestContext testContext)
        {
            const string customTransportName1 = "Custom transport client 1";
            const string customTransportName2 = "Custom transport client 2";

            var playFabTransport = PluginManager.GetPlugin<ITransportPlugin>(PluginContract.PlayFab_Transport);
            var expectedTransport1 = new CustomTransportPlugin() { Name = customTransportName1 };
            var expectedTransport2 = new CustomTransportPlugin() { Name = customTransportName2 };

            // Set custom plugins
            PluginManager.SetPlugin(expectedTransport1, PluginContract.PlayFab_Transport, customTransportName1);
            PluginManager.SetPlugin(expectedTransport2, PluginContract.PlayFab_Transport, customTransportName2);

            // Verify
            var actualTransport = PluginManager.GetPlugin<ITransportPlugin>(PluginContract.PlayFab_Transport);
            testContext.True(object.ReferenceEquals(actualTransport, playFabTransport)); // the default one is still the same
            var actualTransport1 = PluginManager.GetPlugin<ITransportPlugin>(PluginContract.PlayFab_Transport, customTransportName1);
            testContext.True(object.ReferenceEquals(actualTransport1, expectedTransport1));
            var actualTransport2 = PluginManager.GetPlugin<ITransportPlugin>(PluginContract.PlayFab_Transport, customTransportName2);
            testContext.True(object.ReferenceEquals(actualTransport2, expectedTransport2));
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }
    }
}
#endif
