using System.Collections.Generic;

namespace PlayFab
{
    public struct PluginContractKey
    {
        public PluginContract _pluginContract;
        public string _pluginName;
    }

    public class PluginContractKeyComparator : EqualityComparer<PluginContractKey>
    {
        public override bool Equals(PluginContractKey x, PluginContractKey y)
        {
            return x._pluginContract == y._pluginContract && x._pluginName.Equals(y._pluginName);
        }

        public override int GetHashCode(PluginContractKey obj)
        {
            return (int)obj._pluginContract + obj._pluginName.GetHashCode();
        }
    }
}
