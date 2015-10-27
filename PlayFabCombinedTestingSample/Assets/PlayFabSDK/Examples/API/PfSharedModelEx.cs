using System;
using System.Collections.Generic;

namespace PlayFab.Examples
{
    public static class PfSharedModelEx
    {
        #region Character Storage
        // Index of data keyed for each user - a server process may need to keep many players in memory
        public static Dictionary<string, UserSharedModel> serverUsers = new Dictionary<string, UserSharedModel>();
        // Reference to singleton global user - a client process cannot access more than 1 player's information directly
        public static UserSharedModel globalClientUser = new UserSharedModel();
        #endregion Character Storage

        public const string SWILL_NAME = "swill"; // TODO: This is global information specific to 1 title - Resolve this
        public static string swillItemId; // TODO: This is global information specific to 1 title - Resolve this

        #region Title information
        public static HashSet<string> virutalCurrencyTypes = new HashSet<string>() { "SS", "GS", "ST" }; // Set your vcKeys here
        public static HashSet<string> consumableItemIds = new HashSet<string>();
        public static HashSet<string> containerItemIds = new HashSet<string>();

        // These will be identical, but they are currently different datatypes
        public static Dictionary<string, ServerModels.CatalogItem> serverCatalog = new Dictionary<string, ServerModels.CatalogItem>();
        public static Dictionary<string, ClientModels.CatalogItem> clientCatalog = new Dictionary<string, ClientModels.CatalogItem>();
        #endregion Title information
    }

    public class UserSharedModel
    {
        #region Client Login
        public string playFabId;
        public List<string> characterIds = new List<string>();
        public List<string> characterNames = new List<string>();
        #endregion Login

        #region Shared/Server/Client Inventory
        // Shared
        public string userInvDisplay = "";
        // Server
        public List<ServerModels.ItemInstance> serverUserItems;
        public Dictionary<string, PfCharInv> serverCharInventories = new Dictionary<string, PfCharInv>();
        // Client
        public List<ClientModels.ItemInstance> clientUserItems;
        public Dictionary<string, PfCharInv> clientCharInventories = new Dictionary<string, PfCharInv>();
        #endregion Inventory

        #region Shared Virtual Currency
        // NOTE: There is no way to request all vc types presently, so the knowledge must be hard coded
        public Dictionary<string, int> userVirtualCurrency = new Dictionary<string, int>();
        public Dictionary<string, Dictionary<string, int>> characterVC = new Dictionary<string, Dictionary<string, int>>();
        #endregion Virtual Currency

        #region Client Trade
        public List<ClientModels.TradeInfo> openTrades;
        #endregion Client Trade

        #region Helper Functions
        public bool GetClientItemPrice(string characterId, string catalogItemId, out string vcKey, out int cost)
        {
            ClientModels.CatalogItem catalogItem;
            vcKey = null;
            cost = 0;

            Dictionary<string, int> wallet = userVirtualCurrency;
            if (characterId == null)
                wallet = userVirtualCurrency;
            else
                characterVC.TryGetValue(characterId, out wallet);

            if (PfSharedModelEx.clientCatalog.TryGetValue(catalogItemId, out catalogItem) && wallet != null)
            {
                foreach (var pair in catalogItem.VirtualCurrencyPrices)
                {
                    int curBalance;
                    if (wallet.TryGetValue(pair.Key, out curBalance) && curBalance > pair.Value)
                    {
                        vcKey = pair.Key;
                        cost = (int)pair.Value;
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion Helper Functions
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
