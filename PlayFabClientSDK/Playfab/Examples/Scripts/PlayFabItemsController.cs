using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab.ClientModels;
using PlayFab.Internal;
using PlayFab;

public class PlayFabItemsController : SingletonMonoBehaviour<PlayFabItemsController> {

	
	private static List<ItemInstance> Inventory;
	public static List<ItemInstance> InventoryConsumed;
	public static Dictionary<string,int> VirtualCurrency;


	public static bool InventoryLoaded = false;
	public void UpdateInventory(){
		PlayFabClientAPI.GetUserInventory (new GetUserInventoryRequest(),OnGetUserInventory, OnPlayFabError);
	}

	private void OnGetUserInventory(GetUserInventoryResult result){
		InventoryConsumed = Inventory = result.Inventory;
		VirtualCurrency = result.VirtualCurrency;	

		PlayFabGameBridge.consumableItems = new Dictionary<string,uint?>();
		PlayFabGameBridge.consumableItemsConsumed = new Dictionary<string,uint?>(); 
		for (int i = 0; i<Inventory.Count; i++) {
			if (Inventory [i].RemainingUses != null) {
				if(PlayFabGameBridge.consumableItems.ContainsKey(Inventory[i].ItemId))PlayFabGameBridge.consumableItems[Inventory[i].ItemId] += Inventory[i].RemainingUses;
					else{
					PlayFabGameBridge.consumableItems.Add(Inventory[i].ItemId,Inventory[i].RemainingUses);
					PlayFabGameBridge.consumableItemsConsumed.Add(Inventory[i].ItemId,0);
				}
			}
		}
		InventoryLoaded = true;
	}

	public static void OnPurchase(PurchaseItemResult result){
		PlayFabItemsController.instance.UpdateInventory ();
	}

	public static void ConsumeItems(){
		foreach(KeyValuePair<string, uint?> entry in PlayFabGameBridge.consumableItemsConsumed)
		{
			if(PlayFabGameBridge.consumableItemsConsumed[entry.Key]!= 0) PlayFabItemsController.instance.ConsumeCalculator (entry.Key,PlayFabGameBridge.consumableItemsConsumed[entry.Key]);
		}
	}

	private void ConsumeCalculator (string ItemId,uint? toConsume){
			ConsumeItemRequest request = new ConsumeItemRequest ();
			for (int i = 0; i<Inventory.Count; i++) {
				if (Inventory[i].RemainingUses != null && Inventory[i].ItemId == ItemId && Inventory[i].RemainingUses != 0) {
					request.ItemInstanceId = Inventory[i].ItemInstanceId;
					if(toConsume>=Inventory[i].RemainingUses){
						toConsume -= Inventory[i].RemainingUses;
						request.ConsumeCount = Convert.ToInt32(Inventory[i].RemainingUses);
						Inventory[i].RemainingUses = 0;
					}else{
						Inventory[i].RemainingUses -= toConsume;
						request.ConsumeCount = Convert.ToInt32(toConsume);
					}
					PlayFabClientAPI.ConsumeItem(request,onConsumeCompleted,OnPlayFabError);
					if(toConsume==0)break;
				}
			}
	}


	private void onConsumeCompleted(ConsumeItemResult result)
	{
		Debug.Log ("Consumed");
	}

	void OnPlayFabError(PlayFabError error)
	{
		Debug.Log ("Got an error: " + error.ErrorMessage);
	}
}
