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
		if (PlayFabData.AuthKey != null)
			PlayFabClientAPI.GetUserInventory (new GetUserInventoryRequest(),OnGetUserInventory, OnPlayFabError);
	}

	private void OnGetUserInventory(GetUserInventoryResult result){
		InventoryConsumed = Inventory = result.Inventory;
		VirtualCurrency = result.VirtualCurrency;	

		PlayFabGameBridge.consumableItems = new Dictionary<string,int?>();
		PlayFabGameBridge.consumableItemsConsumed = new Dictionary<string,int?>(); 
		for (int i = 0; i<Inventory.Count; i++) {
			if (Inventory [i].RemainingUses != null) {
				Debug.Log ("Adding " + Inventory[i].RemainingUses + " of class " + Inventory[i].ItemClass);
				if (PlayFabGameBridge.consumableItems.ContainsKey(Inventory[i].ItemClass))
				{
					PlayFabGameBridge.consumableItems[Inventory[i].ItemClass] += Inventory[i].RemainingUses;
				}
				else
				{
					PlayFabGameBridge.consumableItems.Add(Inventory[i].ItemClass,Inventory[i].RemainingUses);
					PlayFabGameBridge.consumableItemsConsumed.Add(Inventory[i].ItemClass,0);
				}
			}
		}
		InventoryLoaded = true;
	}

	public static void OnPurchase(PurchaseItemResult result){
		PlayFabItemsController.instance.UpdateInventory ();
	}

	public static void ConsumeItems(){
		var buffer = new List<string>(PlayFabGameBridge.consumableItemsConsumed.Keys);	// needed because we cannot otherwise change a dictionary while we iterate over it

		foreach(string item in buffer)
		{
			if (PlayFabGameBridge.consumableItemsConsumed[item]!= 0)
			{
				PlayFabItemsController.instance.ConsumeCalculator (item, PlayFabGameBridge.consumableItemsConsumed[item]);
				PlayFabGameBridge.recordConsumed(item);
			}
		}
	}

	private void ConsumeCalculator (string ItemClass,int? toConsume){
			ConsumeItemRequest request = new ConsumeItemRequest ();
			for (int i = 0; i<Inventory.Count; i++) {
				if (Inventory[i].RemainingUses != null && Inventory[i].ItemClass == ItemClass && Inventory[i].RemainingUses != 0) {
					request.ItemInstanceId = Inventory[i].ItemInstanceId;
					if(toConsume>=Inventory[i].RemainingUses){
						toConsume -= Inventory[i].RemainingUses;
						request.ConsumeCount = Convert.ToInt32(Inventory[i].RemainingUses);
						Inventory[i].RemainingUses = 0;	// really we should only do this in onConsumeCompleted in case there is an error
					}else{
						Inventory[i].RemainingUses -= toConsume; // here too
						request.ConsumeCount = Convert.ToInt32(toConsume);
						toConsume = 0;
					}
					Debug.Log ("Consuming " + toConsume + " of " + request.ItemInstanceId);
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
