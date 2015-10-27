using System;
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
    public static class TradeExample
    {
        #region Controller Event Handling
        static TradeExample()
        {
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnUserLogin, OnUserLogin);
            PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnCatalogLoaded, OnCatalogLoaded);
        }

        public static void SetUp()
        {
            // The static constructor is called as a by-product of this call
        }

        private static void OnUserLogin(string playFabId)
        {
            GetTrades();
        }

        private static void OnCatalogLoaded(string trash)
        {
            // Find the designated trade target item
            foreach (var catalogPair in PfSharedModelEx.clientCatalog)
                if (catalogPair.Value.DisplayName.ToLower().Contains(PfSharedModelEx.SWILL_NAME.ToLower()))
                    PfSharedModelEx.swillItemId = catalogPair.Key;
        }
        #endregion Controller Event Handling

        #region Prerequisite PlayFab Inventory APIs
        public static void GetTrades()
        {
            ClientModels.GetPlayerTradesRequest request = new ClientModels.GetPlayerTradesRequest();
            PlayFabClientAPI.GetPlayerTrades(request, GetTradesCallback, PfSharedControllerEx.FailCallback("GetPlayerTrades"));
        }
        private static void GetTradesCallback(ClientModels.GetPlayerTradesResponse result)
        {
            PfSharedModelEx.globalClientUser.openTrades = result.OpenedTrades;
        }

        public static Action OpenTrade(params string[] offeredInventoryInstanceIds)
        {
            Action output = () =>
            {
                var openRequest = new ClientModels.OpenTradeRequest();
                // Optional field: null is anybody, alternately if specified, this is a targeted trade request
                //   In this example, we restrict the trade to ourselves (because I don't have multiple clients for this example)
                //   A normal trade process would use all the same steps, but would interact between multliple clients
                openRequest.AllowedPlayerIds = new List<string>() { PfSharedModelEx.globalClientUser.playFabId };
                // Offering the items you have
                openRequest.OfferedInventoryInstanceIds = new List<string>();
                openRequest.OfferedInventoryInstanceIds.AddRange(offeredInventoryInstanceIds);
                // Listing the items you want
                openRequest.RequestedCatalogItemIds = new List<string>() { PfSharedModelEx.swillItemId };
                PlayFabClientAPI.OpenTrade(openRequest, OpenTradeCallback, PfSharedControllerEx.FailCallback("OpenTrade"));
            };
            return output;
        }
        private static void OpenTradeCallback(ClientModels.OpenTradeResponse result)
        {
            // At this point, the tradeId needs to be shared via some mechanism, such as photon, a game server, shared-group-data, or external implementation
            //   Since we fulfill this trade with ourselves, that step is somewhat automatic in this example
            Debug.Log("New trade opened: " + result.Trade.TradeId);

            // We could append result.Trade to openTrades if we trusted the diff, but the latency for calls is pretty high, so it's safer to just fetch a clean list:
            GetTrades();
            // My inventory items just moved into escrow - It's safest to do a full refresh
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, null);
        }

        public static Action CancelTrade(string tradeId)
        {
            Action output = () =>
            {
                var cancelRequest = new ClientModels.CancelTradeRequest();
                cancelRequest.TradeId = tradeId;
                PlayFabClientAPI.CancelTrade(cancelRequest, CancelTradeCallback, PfSharedControllerEx.FailCallback("CancelTrade"));
            };
            return output;
        }
        private static void CancelTradeCallback(ClientModels.CancelTradeResponse result)
        {
            Debug.Log("Existing trade canceled: " + result.Trade.TradeId);

            // We could remove the trade matching result.Trade.TradeId from openTrades if we trusted the diff, but the latency for calls is pretty high, so it's safer to just fetch a clean list:
            GetTrades();
            // The escrow items just returned to my inventory - It's safest to do a full refresh
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, null);
        }

        public static Action AcceptTrade(string tradeId, string offeringPlayerId, List<string> acceptedInventoryInstanceIds)
        {
            Action output = () =>
            {
                var acceptRequest = new ClientModels.AcceptTradeRequest();
                acceptRequest.TradeId = tradeId;
                acceptRequest.OfferingPlayerId = offeringPlayerId;
                acceptRequest.AcceptedInventoryInstanceIds = acceptedInventoryInstanceIds;
                PlayFabClientAPI.AcceptTrade(acceptRequest, AcceptTradeCallback, PfSharedControllerEx.FailCallback("CancelTrade"));
            };
            return output;
        }
        private static void AcceptTradeCallback(ClientModels.AcceptTradeResponse result)
        {
            Debug.Log("Existing trade completed: " + result.Trade.TradeId);

            // We could remove the trade matching result.Trade.TradeId from openTrades if we trusted the diff, but the latency for calls is pretty high, so it's safer to just fetch a clean list:
            GetTrades();
            // At this point, both the user who made the offer, and the player who accepted the offer must refresh their inventory, as nothing in the result demonstrates how those inventories will change
            // (The offering user doesn't even know that their inventory changed, so that can be a bit tricky)
            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, null);
        }
        #endregion
    }
}
