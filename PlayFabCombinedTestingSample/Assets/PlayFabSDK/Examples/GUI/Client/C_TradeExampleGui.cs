using System.Collections.Generic;
using UnityEngine;

namespace PlayFab.Examples.Client
{
    /// <summary>
    /// This is example code for all the API's described here: PlayFab Inventory System - Basic Trading Guide
    /// This file contains calls to each of the functions described, an old-style Unity-gui to demonstrate the inventory changes taking place, and the prerequisite login and setup code.
    /// 
    /// This example set specifically restricts the trade-target to "self".
    /// This is a matter of simplicity for the example itself.  This would otherwise be very unusual in a real game.
    /// A real game would avoid this case, but an example with 2+ users would require 2+ Unity-processes (which makes this example a lot harder to demonstrate)
    /// </summary>
    public class C_TradeExampleGui : PfExampleGui
    {
        void Awake()
        {
            TradeExample.SetUp();
        }

        #region Unity GUI
        public override void OnExampleGUI(ref int rowIndex)
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();
            if (string.IsNullOrEmpty(PfSharedModelEx.swillItemId))
                return; // Trade can't function properly without specific required itemIds identified

            // Display User Items
            TextField(isLoggedIn, rowIndex, 0, "Offer (for swill):");
            if (PfSharedModelEx.globalClientUser.clientUserItems != null)
                for (int i = 0; i < PfSharedModelEx.globalClientUser.clientUserItems.Count; i++)
                    Button(isLoggedIn, rowIndex, i + 1, PfSharedModelEx.globalClientUser.clientUserItems[i].DisplayName, TradeExample.OpenTrade(PfSharedModelEx.globalClientUser.clientUserItems[i].ItemInstanceId));
            rowIndex++;
            rowIndex++;

            Button(true, rowIndex, 0, "Refresh Trades", TradeExample.GetTrades);
            rowIndex++;
            rowIndex++;

            // Display active trades
            for (int i = 0; i < PfSharedModelEx.globalClientUser.openTrades.Count; i++)
            {
                if (PfSharedModelEx.globalClientUser.openTrades[i].Status != ClientModels.TradeStatus.Open)
                    continue;

                Button(true, rowIndex, 0, "Cancel", TradeExample.CancelTrade(PfSharedModelEx.globalClientUser.openTrades[i].TradeId));
                rowIndex++;

                TextField(isLoggedIn, rowIndex, 0, "Offered Items:");
                for (int j = 0; j < PfSharedModelEx.globalClientUser.openTrades[i].OfferedCatalogItemIds.Count; j++)
                {
                    ClientModels.CatalogItem catalogItem;
                    if (PfSharedModelEx.clientCatalog.TryGetValue(PfSharedModelEx.globalClientUser.openTrades[i].OfferedCatalogItemIds[j], out catalogItem))
                        TextField(isLoggedIn, rowIndex, j + 1, catalogItem.DisplayName);
                }
                rowIndex++;

                List<string> tradeInstances; string displayItems;
                if (GetAcceptOptions(PfSharedModelEx.globalClientUser.openTrades[i], out tradeInstances, out displayItems))
                {
                    TextField(isLoggedIn, rowIndex, 0, "Accept With:");
                    Button(true, rowIndex, 1, displayItems, TradeExample.AcceptTrade(PfSharedModelEx.globalClientUser.openTrades[i].TradeId, PfSharedModelEx.globalClientUser.openTrades[i].OfferingPlayerId, tradeInstances));
                }
                rowIndex++;
                rowIndex++;
            }
        }

        /// <summary>
        /// This function represents a gui where users would place their items into a trade window, which fulfills the requirements of eachTrade
        /// For this tutorial, it just grabs whatever works.
        /// Returns whether the userInventory contains the correct arrangement of items to satisfy the trade.
        /// </summary>
        private static bool GetAcceptOptions(ClientModels.TradeInfo eachTrade, out List<string> tradeInstances, out string displayItems)
        {
            tradeInstances = new List<string>();
            displayItems = null;
            PfSharedControllerEx.sb.Length = 0;

            ClientModels.CatalogItem catalogItem;
            foreach (var tradeReqItemId in eachTrade.RequestedCatalogItemIds)
            {
                if (!PfSharedModelEx.clientCatalog.TryGetValue(tradeReqItemId, out catalogItem))
                    return false; // The required item doesn't exist, just fail

                bool foundTrade = false;
                foreach (var itemInstance in PfSharedModelEx.globalClientUser.clientUserItems)
                {
                    if (tradeInstances.Contains(itemInstance.ItemInstanceId))
                        continue; // We've already allocated this item

                    if (itemInstance.ItemId == tradeReqItemId)
                    {
                        tradeInstances.Add(itemInstance.ItemInstanceId);
                        foundTrade = true;
                        break;
                    }
                }
                if (!foundTrade)
                    return false;

                if (PfSharedControllerEx.sb.Length != 0)
                    PfSharedControllerEx.sb.Append(", ");
                PfSharedControllerEx.sb.Append(catalogItem.DisplayName);
            }

            displayItems = PfSharedControllerEx.sb.ToString();
            return tradeInstances.Count == eachTrade.RequestedCatalogItemIds.Count; // Return whether we found instances for all required catalogItems
        }
        #endregion Unity GUI
    }
}
