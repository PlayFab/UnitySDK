using System;
using System.Collections.Generic;
using PlayFab.Internal;
using PlayFab.Json;

namespace PlayFab
{
    public class PluginManager
    {
        public const string PLUGIN_TRANSPORT_ONEDS = "PLUGIN_TRANSPORT_ONEDS";

        private Dictionary<PluginContractKey, IPlayFabPlugin> plugins = new Dictionary<PluginContractKey, IPlayFabPlugin>(new PluginContractKeyComparator());

        /// <summary>
        /// The singleton instance of plugin manager.
        /// </summary>
        private static readonly PluginManager Instance = new PluginManager();

        private PluginManager()
        {
        }

        /// <summary>
        /// Gets a plugin.
        /// If a plugin with specified contract and optional instance name does not exist, it will create a new one.
        /// </summary>
        /// <param name="contract">The plugin contract.</param>
        /// <param name="instanceName">The optional plugin instance name. Instance names allow to have mulptiple plugins with the same contract.</param>
        /// <returns>The plugin instance.</returns>
        public static T GetPlugin<T>(PluginContract contract, string instanceName = "") where T : IPlayFabPlugin
        {
            return (T)Instance.GetPluginInternal(contract, instanceName);
        }

        /// <summary>
        /// Sets a custom plugin.
        /// If a plugin with specified contract and optional instance name already exists, it will be replaced with specified instance.
        /// </summary>
        /// <param name="plugin">The plugin instance.</param>
        /// <param name="contract">The app contract of plugin.</param>
        /// <param name="instanceName">The optional plugin instance name. Instance names allow to have mulptiple plugins with the same contract.</param>
        public static void SetPlugin(IPlayFabPlugin plugin, PluginContract contract, string instanceName = "")
        {
            Instance.SetPluginInternal(plugin, contract, instanceName);
        }

        private IPlayFabPlugin GetPluginInternal(PluginContract contract, string instanceName)
        {
            var key = new PluginContractKey { _pluginContract = contract, _pluginName = instanceName };
            IPlayFabPlugin plugin;
            if (!this.plugins.TryGetValue(key, out plugin))
            {
                // Requested plugin is not in the cache, create the default one
                switch (contract)
                {
                    case PluginContract.PlayFab_Serializer:
                        plugin = this.CreatePlugin<SimpleJsonInstance>();
                        break;
                    case PluginContract.PlayFab_Transport:
                        if (instanceName == PluginManager.PLUGIN_TRANSPORT_ONEDS)
                            plugin = this.CreateOneDSTransportPlugin();
                        else
                            plugin = this.CreatePlayFabTransportPlugin();
                        break;
                    default:
                        throw new ArgumentException("This contract is not supported", "contract");
                }

                this.plugins[key] = plugin;
            }

            return plugin;
        }

        private void SetPluginInternal(IPlayFabPlugin plugin, PluginContract contract, string instanceName)
        {
            if (plugin == null)
            {
                throw new ArgumentNullException("plugin", "Plugin instance cannot be null");
            }

            var key = new PluginContractKey { _pluginContract = contract, _pluginName = instanceName };
            this.plugins[key] = plugin;
        }

        private IPlayFabPlugin CreatePlugin<T>() where T : IPlayFabPlugin, new()
        {
            return (IPlayFabPlugin)Activator.CreateInstance(typeof(T));
        }

        private ITransportPlugin CreatePlayFabTransportPlugin()
        {
            ITransportPlugin transport = null;
#if !UNITY_WSA && !UNITY_WP8
            if (PlayFabSettings.RequestType == WebRequestType.HttpWebRequest)
                transport = new PlayFabWebRequest();
#endif

#if UNITY_2018_2_OR_NEWER // PlayFabWww will throw warnings as Unity has deprecated Www
            if (transport == null)
                transport = new PlayFabUnityHttp();
#elif UNITY_2017_2_OR_NEWER
            if (PlayFabSettings.RequestType == WebRequestType.UnityWww)
                transport = new PlayFabWww();

            if (transport == null)
                transport = new PlayFabUnityHttp();
#else
            if (transport == null)
                transport = new PlayFabWww();
#endif

            return transport;
        }

        private IOneDSTransportPlugin CreateOneDSTransportPlugin()
        {
            IOneDSTransportPlugin transport = null;
#if !UNITY_WSA && !UNITY_WP8
            if (PlayFabSettings.RequestType == WebRequestType.HttpWebRequest)
                transport = new OneDsWebRequestPlugin();
#endif

#if UNITY_2018_2_OR_NEWER // OneDsWwwPlugin will throw warnings as Unity has deprecated Www
            if (transport == null)
                transport = new OneDsUnityHttpPlugin();
#elif UNITY_2017_2_OR_NEWER
            if (PlayFabSettings.RequestType == WebRequestType.UnityWww)
                transport = new OneDsWwwPlugin();

            if (transport == null)
                transport = new OneDsUnityHttpPlugin();
#else
            if (transport == null)
                transport = new OneDsWwwPlugin();
#endif

            return transport;
        }
    }
}
