using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Events;

using PlayFab.ClientModels;

/// <summary>
/// Inventory controller that provides the base inventory calls to the shared controller and model
/// </summary>
public class InventoryController : MonoBehaviour {
	
	// references to UI components
	public Button actionButton;
	public Text active_itemId;
	public Text active_itemName;
	public Text active_itemDescription;
	public Text active_itemUses;
	public Text active_itemType;
	public Image active_icon;
	public Text active_expiration;
	
	public Transform listView;
	public Transform invItemPrefab;
	public Transform inventoryPanel;
	
	public WalletController wallet;
	
	private InventoryItemController activeItem; 
	private List<Transform> itemSceneObjects = new List<Transform>();
	
	void Awake()
	{
//		PlayFab.Examples.Client.VirtualCurrencyExample.SetUp();
//		PlayFab.Examples.Client.InventoryExample.SetUp();
	}

	public void OnEnable()
	{
		HidePanel();
//		PlayFab.Examples.PfSharedControllerEx.RegisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnInventoryLoaded, CheckToContinue);
//		PlayFab.Examples.PfSharedControllerEx.RegisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnCatalogLoaded, CheckToContinue);
		
		Init();	
	}
	
	public void CheckToContinue(string playFabId, string characterId, PlayFab.Examples.PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
	{
		Init();
	}
	
	public void OnDisable()
	{
//		PlayFab.Examples.PfSharedControllerEx.UnregisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnInventoryLoaded, CheckToContinue);
//		PlayFab.Examples.PfSharedControllerEx.UnregisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnCatalogLoaded, CheckToContinue);
	}
	
	public void Init()
	{
		if(PlayFab.Examples.PfSharedModelEx.globalClientUser.clientUserItems != null && PlayFab.Examples.PfSharedModelEx.clientCatalog != null)
		 {
			AdjustItemPrefabs(PlayFab.Examples.PfSharedModelEx.globalClientUser.clientUserItems.Count);
			InventoryItemController first = null;
			for(int z = 0; z < PlayFab.Examples.PfSharedModelEx.globalClientUser.clientUserItems.Count; z++)
			{
				InventoryItemController item = this.itemSceneObjects[z].GetComponent<InventoryItemController>();
				item.Init(this, PlayFab.Examples.PfSharedModelEx.globalClientUser.clientUserItems[z]);
				
				if(z == 0)
				{
					first = item;
				}
			}
			ShowPanel();
			
			if(this.activeItem == null && first != null)
			{
				ItemClicked(first);
			}
			else if(this.activeItem != null);
			{
				ItemClicked(this.activeItem);
			}
			
			
			StartCoroutine(wallet.Init());
		 }
		 else
		 {
		 	// close dialog, no items found?
		 	Debug.Log("No inventory items were found. Closing dialog.");
		 	CloseInventory();
		 	
		 }
	}
	
	public void ShowPanel()
	{
		this.inventoryPanel.gameObject.SetActive(true);
	}
	
	public void HidePanel()
	{
		this.inventoryPanel.gameObject.SetActive(false);
	}
	
	public void AdjustItemPrefabs(int itemCount)
	{
		//DeselectItems();
		if(this.itemSceneObjects.Count > itemCount)
		{
			int numToRemove = this.itemSceneObjects.Count - itemCount;
			for(int z = 0; z < numToRemove; z++)
			{
				Destroy(this.itemSceneObjects[z].gameObject);
			}
			this.itemSceneObjects.RemoveRange(0, numToRemove);
		}
		else if(this.itemSceneObjects.Count < itemCount)
		{
			int numToAdd = itemCount - this.itemSceneObjects.Count;
			for(int z = 0; z < numToAdd; z++)
			{
				Transform go = Instantiate(this.invItemPrefab);
				go.SetParent(this.listView, false);
				
				this.itemSceneObjects.Add(go);
			}
		}
	}
	
	// item selected
	public void ItemClicked(InventoryItemController item)
	{
		if(item == null)
		{
			return;
		}
		
		DeselectItems();
		
		this.activeItem = item;
		this.activeItem.panelOutline.effectColor = this.activeItem.selectedColor;
		UpdateDetails();
	}
	

	public void DeselectItems()
	{
		this.activeItem = null;
		foreach(var item in this.itemSceneObjects)
		{
			InventoryItemController iic = item.GetComponent<InventoryItemController>();
			iic.panelOutline.effectColor = iic.unselectedColor;
		}
	}
	
	public void UpdateDetails()
	{
		
		this.active_itemUses.transform.parent.gameObject.SetActive(true);   // by default enable uses field
		this.active_expiration.transform.parent.gameObject.SetActive(false); // by default disable expire field				
		
		this.active_itemName.text = this.activeItem.catlogItem.ItemId;
		this.active_itemDescription.text = this.activeItem.catlogItem.Description;
		this.active_itemUses.text =  ""+this.activeItem.itemInstance.RemainingUses;
		
		if(this.activeItem.catlogItem.Bundle != null)
		{
			this.active_itemType.text = "Bundle";
			EnableDurableButton();
		}
		else if(this.activeItem.catlogItem.Container != null)
		{
			this.active_itemType.text = "Container";
			EnableOpenButton();
		}
		else if(this.activeItem.catlogItem.Consumable.UsageCount > 0 && this.activeItem.catlogItem.Consumable.UsagePeriod == null)
		{
			this.active_itemType.text = "Consumable";
			EnableUseButton();
		}
		else if(this.activeItem.catlogItem.Consumable.UsageCount > 0 && this.activeItem.catlogItem.Consumable.UsagePeriod != null)
		{
			this.active_itemType.text = "Time-limited";
			this.active_expiration.text = string.Format("{0:g}", this.activeItem.itemInstance.Expiration);
			this.active_expiration.transform.parent.gameObject.SetActive(true);
			EnableUseButton();
		}
		else 
		{
			this.active_itemType.text = "Durable";
			this.active_itemUses.transform.parent.gameObject.SetActive(false); // hide uses field
			EnableDurableButton();
		}
		
		this.active_itemName.text = this.activeItem.catlogItem.DisplayName;
		this.active_itemDescription.text = this.activeItem.catlogItem.Description;
		this.active_itemId.text = this.activeItem.catlogItem.ItemId;
		
		this.active_icon.overrideSprite = null;
	}
	
	public void ClearDetails()
	{
		this.actionButton.onClick.RemoveAllListeners();
		this.actionButton.interactable = false;
		this.actionButton.GetComponentInChildren<Text>().text = string.Empty;

		this.active_icon.overrideSprite = null;
		this.active_itemType.text = string.Empty;
		this.active_itemUses.text = string.Empty;
		this.active_expiration.text = string.Empty;
		this.active_itemName.text = string.Empty;
		this.active_itemDescription.text = string.Empty;
		this.active_itemId.text = string.Empty;
	}

	public void EnableUseButton()
	{
		this.actionButton.onClick.RemoveAllListeners();
		this.actionButton.onClick.AddListener(() => { ConsumeItem(); });
		this.actionButton.interactable = true;
		this.actionButton.GetComponentInChildren<Text>().text = "Use / Consume Item";
	}
	
	public void EnableOpenButton()
	{
		this.actionButton.onClick.RemoveAllListeners();
		this.actionButton.onClick.AddListener(() => { UnlockContainer(); });
		this.actionButton.interactable = true;
		this.actionButton.GetComponentInChildren<Text>().text = "Open Container";
	}
	
	public void EnableDurableButton()
	{
		this.actionButton.onClick.RemoveAllListeners();
		this.actionButton.interactable = false;
		this.actionButton.GetComponentInChildren<Text>().text = "Durable - No Actions";
	}
	
	public void CloseInventory()
	{
		this.gameObject.SetActive(false);
	}
	
	public void ConsumeItem()
	{
		Debug.Log("Consume Item: " + this.activeItem.catlogItem.ItemId);
		//System.Action consume = PlayFab.Examples.Client.InventoryExample.ConsumeUserItem(this.activeItem.itemInstance.ItemInstanceId);
		//consume();
		
	}
	
	public void UnlockContainer()
	{
		Debug.Log("Unlocking Container: " + this.activeItem.catlogItem.ItemId);
		//System.Action unlock = PlayFab.Examples.Client.InventoryExample.UnlockUserContainer(this.activeItem.catlogItem.ItemId);
		//unlock();
	}
}
