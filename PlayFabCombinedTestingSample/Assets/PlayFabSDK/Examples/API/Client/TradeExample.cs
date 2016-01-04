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

        private static void OnUserLogin(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
        {
            GetTrades();
        }

        private static void OnCatalogLoaded(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
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

        public static void OpenTrade(params string[] offeredInventoryInstanceIds)
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
        }
        private static void OpenTradeCallback(ClientModels.OpenTradeResponse result)
        {
            // At this point, the tradeId needs to be shared via some mechanism, such as photon, a game server, shared-group-data, or external implementation
            //   Since we fulfill this trade with ourselves, that step is somewhat automatic in this example
            Debug.Log("New trade opened: " + result.Trade.TradeId);

            PfSharedModelEx.globalClientUser.RemoveItems(null, new HashSet<string>(result.Trade.OfferedInventoryInstanceIds));
            PfSharedModelEx.globalClientUser.openTrades.Add(result.Trade);

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, PfSharedModelEx.globalClientUser.playFabId, null, PfSharedControllerEx.Api.Client | PfSharedControllerEx.Api.Server, false);
        }

        public static void CancelTrade(string tradeId)
        {
            var cancelRequest = new ClientModels.CancelTradeRequest();
            cancelRequest.TradeId = tradeId;
            PlayFabClientAPI.CancelTrade(cancelRequest, CancelTradeCallback, PfSharedControllerEx.FailCallback("CancelTrade"));
        }
        private static void CancelTradeCallback(ClientModels.CancelTradeResponse result)
        {
            Debug.Log("Existing trade canceled: " + result.Trade.TradeId);

            PfSharedModelEx.globalClientUser.RemoveTrade(result.Trade.TradeId);

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, PfSharedModelEx.globalClientUser.playFabId, null, PfSharedControllerEx.Api.Client, true);
        }

        public static void AcceptTrade(string tradeId, string offeringPlayerId, List<string> acceptedInventoryInstanceIds)
        {
            var acceptRequest = new ClientModels.AcceptTradeRequest();
            acceptRequest.TradeId = tradeId;
            acceptRequest.OfferingPlayerId = offeringPlayerId;
            acceptRequest.AcceptedInventoryInstanceIds = acceptedInventoryInstanceIds;
            PlayFabClientAPI.AcceptTrade(acceptRequest, AcceptTradeCallback, PfSharedControllerEx.FailCallback("CancelTrade"));
        }
        private static void AcceptTradeCallback(ClientModels.AcceptTradeResponse result)
        {
            Debug.Log("Existing trade completed: " + result.Trade.TradeId);

            PfSharedModelEx.globalClientUser.RemoveTrade(result.Trade.TradeId);

            PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnInventoryChanged, PfSharedModelEx.globalClientUser.playFabId, null, PfSharedControllerEx.Api.Client, true);
        }
        #endregion
    }
}
