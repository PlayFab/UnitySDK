using System;
using System.Collections.Generic;

namespace PlayFab.Examples
{
    public static class PfSharedModelEx
    {
        #region Client Login
        public static string playFabId;
        public static List<string> characterIds = new List<string>();
        public static List<string> characterNames = new List<string>();
        #endregion Login

        #region Shared/Server/Client Inventory
        // Shared
        public static string userInvDisplay = "";
        public static HashSet<string> consumableItemIds = new HashSet<string>();
        public static HashSet<string> containerItemIds = new HashSet<string>();
        // Server
        public static Dictionary<string, ServerModels.CatalogItem> serverCatalog = new Dictionary<string, ServerModels.CatalogItem>();
        public static List<ServerModels.ItemInstance> serverUserItems;
        public static Dictionary<string, PfCharInv> serverCharInventories = new Dictionary<string, PfCharInv>();
        // Client
        public static Dictionary<string, ClientModels.CatalogItem> clientCatalog = new Dictionary<string, ClientModels.CatalogItem>();
        public static List<ClientModels.ItemInstance> clientUserItems;
        public static Dictionary<string, PfCharInv> clientCharInventories = new Dictionary<string, PfCharInv>();
        #endregion Inventory

        #region Shared Virtual Currency
        // NOTE: There is no way to request all vc types presently, so the knowledge must be hard coded
        public static HashSet<string> virutalCurrencyTypes = new HashSet<string>() { "SS", "GS", "ST" }; // Set your vcKeys here
        public static Dictionary<string, int> userVirtualCurrency = new Dictionary<string, int>();
        public static Dictionary<string, Dictionary<string, int>> characterVC = new Dictionary<string, Dictionary<string, int>>();
        #endregion Virtual Currency

        #region Client Trade
        public const string SWILL_NAME = "swill";
        public static string swillItemId;
        public static List<ClientModels.TradeInfo> openTrades;
        #endregion Client Trade
    }

    /// <summary>
    /// A wrapper for inventory related, character centric, API calls and info
    /// This mostly exists because the characterId needs to be available at all steps in the process, and a class-wrapper avoids most of the Lambda-hell
    /// </summary>
    public class PfCharInv
    {
        public string playFabId;
        public string characterId;
        public string characterName;
        public string inventoryDisplay = "";

        public PfCharInv(string playFabId, string characterId, string characterName)
        {
            this.playFabId = playFabId;
            this.characterId = characterId;
            this.characterName = characterName;
        }
    }
}
