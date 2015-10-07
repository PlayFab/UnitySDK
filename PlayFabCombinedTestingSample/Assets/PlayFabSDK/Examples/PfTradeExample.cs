using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PlayFab.Examples
{
    /// <summary>
    /// This is example code for all the API's described here: PlayFab Inventory System - Basic Trading Guide
    /// This file contains calls to each of the functions described, an old-style Unity-gui to demonstrate the inventory changes taking place, and the prerequisite login and setup code.
    /// 
    /// This example set specifically restricts the trade-target to "self".
    /// This is a matter of simplicity for the example itself.  This would otherwise be very unusual in a real game.
    /// A real game would avoid this case, but an example with 2+ users would require 2+ Unity-processes (which makes this example a lot harder to demonstrate)
    /// </summary>
    [RequireComponent(typeof(PfLoginExample))]
    [RequireComponent(typeof(PfInventoryExample))]
    public class PfTradeExample : PfExampleGui
    {
        private const string SWILL_NAME = "swill";

        #region Data Variables
        private string swillItemId;
        private List<ClientModels.TradeInfo> openTrades;

        private static StringBuilder sb = new StringBuilder();
        #endregion Data Variables

        #region Unity GUI
        public override void OnExampleGUI(ref int rowIndex)
        {
            bool isLoggedIn = PlayFabClientAPI.IsClientLoggedIn();
            if (string.IsNullOrEmpty(swillItemId))
                return; // Trade can't function properly without specific required itemIds identified

            // Display User Items
            TextField(isLoggedIn, rowIndex, 0, "Offer (for swill):");
            if (invExample.userItems != null)
                for (int i = 0; i < invExample.userItems.Count; i++)
                    Button(isLoggedIn, rowIndex, i + 1, invExample.userItems[i].DisplayName, OpenTrade(invExample.userItems[i].ItemInstanceId));
            rowIndex++;
            rowIndex++;

            Button(true, rowIndex, 0, "Refresh Trades", GetTrades);
            rowIndex++;
            rowIndex++;

            // Display active trades
            for (int i = 0; i < openTrades.Count; i++)
            {
                if (openTrades[i].Status != ClientModels.TradeStatus.Open)
                    continue;

                Button(true, rowIndex, 0, "Cancel", CancelTrade(openTrades[i].TradeId));
                rowIndex++;

                TextField(isLoggedIn, rowIndex, 0, "Offered Items:");
                for (int j = 0; j < openTrades[i].OfferedCatalogItemIds.Count; j++)
                {
                    ClientModels.CatalogItem catalogItem;
                    if (invExample.catalogItems.TryGetValue(openTrades[i].OfferedCatalogItemIds[j], out catalogItem))
                        TextField(isLoggedIn, rowIndex, j + 1, catalogItem.DisplayName);
                }
                rowIndex++;

                List<string> tradeInstances; string displayItems;
                if (GetAcceptOptions(openTrades[i], out tradeInstances, out displayItems))
                {
                    TextField(isLoggedIn, rowIndex, 0, "Accept With:");
                    Button(true, rowIndex, 1, displayItems, AcceptTrade(openTrades[i].TradeId, openTrades[i].OfferingPlayerId, tradeInstances));
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
            sb.Length = 0;

            ClientModels.CatalogItem catalogItem;
            foreach (var tradeReqItemId in eachTrade.RequestedCatalogItemIds)
            {
                if (!invExample.catalogItems.TryGetValue(tradeReqItemId, out catalogItem))
                    return false; // The required item doesn't exist, just fail

                bool foundTrade = false;
                foreach (var itemInstance in invExample.userItems)
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

                if (sb.Length != 0)
                    sb.Append(", ");
                sb.Append(catalogItem.DisplayName);
            }

            displayItems = sb.ToString();
            return tradeInstances.Count == eachTrade.RequestedCatalogItemIds.Count; // Return whether we found instances for all required catalogItems
        }
        #endregion Unity GUI

        #region Prerequisite login and setup code
        protected void OnPfUserLoginComplete()
        {
            GetTrades();
        }

        protected void OnPfCatalogLoadComplete()
        {
            // Find the designated trade target item
            foreach (var catalogPair in invExample.catalogItems)
                if (catalogPair.Value.DisplayName.ToLower().Contains(SWILL_NAME.ToLower()))
                    swillItemId = catalogPair.Key;
        }
        #endregion Prerequisite login and setup code

        #region Prerequisite PlayFab Inventory APIs
        private void GetTrades()
        {
            ClientModels.GetPlayerTradesRequest request = new ClientModels.GetPlayerTradesRequest();
            PlayFabClientAPI.GetPlayerTrades(request, GetTradesCallback, SharedFailCallback("GetPlayerTrades"));
        }
        private void GetTradesCallback(ClientModels.GetPlayerTradesResponse result)
        {
            openTrades = result.OpenedTrades;
        }

        protected Action OpenTrade(params string[] offeredInventoryInstanceIds)
        {
            Action output = () =>
            {
                var openRequest = new ClientModels.OpenTradeRequest();
                // Optional field: null is anybody, alternately if specified, this is a targeted trade request
                //   In this example, we restrict the trade to ourselves (because I don't have multiple clients for this example)
                //   A normal trade process would use all the same steps, but would interact between multliple clients
                openRequest.AllowedPlayerIds = new List<string>() { loginExample.playFabId };
                // Offering the items you have
                openRequest.OfferedInventoryInstanceIds = new List<string>();
                openRequest.OfferedInventoryInstanceIds.AddRange(offeredInventoryInstanceIds);
                // Listing the items you want
                openRequest.RequestedCatalogItemIds = new List<string>() { swillItemId };
                PlayFabClientAPI.OpenTrade(openRequest, OpenTradeCallback, SharedFailCallback("OpenTrade"));
            };
            return output;
        }
        private void OpenTradeCallback(ClientModels.OpenTradeResponse result)
        {
            // At this point, the tradeId needs to be shared via some mechanism, such as photon, a game server, shared-group-data, or external implementation
            //   Since we fulfill this trade with ourselves, that step is somewhat automatic in this example
            Debug.Log("New trade opened: " + result.Trade.TradeId);

            // We could append result.Trade to openTrades if we trusted the diff, but the latency for calls is pretty high, so it's safer to just fetch a clean list:
            GetTrades();
            // My inventory items just moved into escrow - It's safest to do a full refresh
            invExample.GetUserInventory();
        }

        protected Action CancelTrade(string tradeId)
        {
            Action output = () =>
            {
                var cancelRequest = new ClientModels.CancelTradeRequest();
                cancelRequest.TradeId = tradeId;
                PlayFabClientAPI.CancelTrade(cancelRequest, CancelTradeCallback, SharedFailCallback("CancelTrade"));
            };
            return output;
        }
        private void CancelTradeCallback(ClientModels.CancelTradeResponse result)
        {
            Debug.Log("Existing trade canceled: " + result.Trade.TradeId);

            // We could remove the trade matching result.Trade.TradeId from openTrades if we trusted the diff, but the latency for calls is pretty high, so it's safer to just fetch a clean list:
            GetTrades();
            // The escrow items just returned to my inventory - It's safest to do a full refresh
            invExample.GetUserInventory();
        }

        protected Action AcceptTrade(string tradeId, string offeringPlayerId, List<string> acceptedInventoryInstanceIds)
        {
            Action output = () =>
            {
                var acceptRequest = new ClientModels.AcceptTradeRequest();
                acceptRequest.TradeId = tradeId;
                acceptRequest.OfferingPlayerId = offeringPlayerId;
                acceptRequest.AcceptedInventoryInstanceIds = acceptedInventoryInstanceIds;
                PlayFabClientAPI.AcceptTrade(acceptRequest, AcceptTradeCallback, SharedFailCallback("CancelTrade"));
            };
            return output;
        }
        private void AcceptTradeCallback(ClientModels.AcceptTradeResponse result)
        {
            Debug.Log("Existing trade completed: " + result.Trade.TradeId);

            // We could remove the trade matching result.Trade.TradeId from openTrades if we trusted the diff, but the latency for calls is pretty high, so it's safer to just fetch a clean list:
            GetTrades();
            // At this point, both the player who made the offer, and the player who accepted the offer must refresh their inventory, as nothing in the result demonstrates how those inventories will change
            // (The offering player doesn't even know that their inventory changed, so that can be a bit tricky)
            invExample.GetUserInventory(); // Refreshes "both" since coincidentally,
        }
        #endregion
    }
}
