using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Inventory controller that provides the base inventory calls to the shared controller and model
/// </summary>
public class InventoryController : MonoBehaviour {
	
	// references to UI components
	public Button ActionButton;
	public Text ActiveItemId;
	public Text ActiveItemName;
	public Text ActiveItemDescription;
	public Text ActiveItemUses;
	public Text ActiveItemType;
	public Image ActiveIcon;
	public Text ActiveExpiration;
	public string ActiveHelpUrl;
	
	public Transform ListView;
	public Transform InvItemPrefab;
	public Transform InventoryPanel;
	
	public WalletController Wallet;
	
	private InventoryItemController _activeItem; 
	private readonly List<Transform> _itemSceneObjects = new List<Transform>();
	
	void Awake()
	{
	}

	public void OnEnable()
	{
		PlayFab.PlayFabSettings.RegisterForResponses(null, GetType().GetMethod("OnDataRetrieved", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
		HidePanel();
		Init();	
	}
	
	public void CheckToContinue(string playFabId, string characterId, PlayFab.Examples.PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
	{
		Init();
	}
	
	public void OnDisable()
	{
		PlayFab.PlayFabSettings.UnregisterForResponses(null, GetType().GetMethod("OnDataRetrieved", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
	}
	
	public void OnDataRetrieved(string url, int callId, object request, object result, PlayFab.PlayFabError error, object customData)
	{
		if(this.gameObject.activeInHierarchy == true && PlayFab.Examples.PfSharedModelEx.ActiveMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		{
			switch(url)
			{
				case "/Client/GetUserInventory":
					Debug.Log("InventoryViewer: GotData:" + url);
					Init();
					break;
					
				case "/Client/ConsumeItem":
					Debug.Log("InventoryViewer: GotData:" + url);
					Init();
					break;
					
				case "/Client/UnlockContainerItem":
					Debug.Log("InventoryViewer: GotData:" + url);
					Init();
					break;
			}
		}
		else if(this.gameObject.activeInHierarchy == true && PlayFab.Examples.PfSharedModelEx.ActiveMode == PlayFab.Examples.PfSharedModelEx.ModelModes.Character)
		{
			switch(url)
			{
				case "/Client/GetCharacterInventory":
					Debug.Log("InventoryViewer: GotData:" + url);
					Init();
					break;
					
				case "/Client/ConsumeItem":
					Debug.Log("InventoryViewer: GotData:" + url);
					Init();
					break;
					
				case "/Client/UnlockContainerItem":
					Debug.Log("InventoryViewer: GotData:" + url);
					Init();
					break;
			}
		}
	}
	
	public void Init()
	{
		ClearDetails();
		if(PlayFab.Examples.PfSharedModelEx.ActiveMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		{
			if(PlayFab.Examples.PfSharedModelEx.CurrentUser.UserInventory != null && PlayFab.Examples.PfSharedModelEx.TitleCatalogs.Count > 0)
			 {
				AdjustItemPrefabs(PlayFab.Examples.PfSharedModelEx.CurrentUser.UserInventory.Count);
				InventoryItemController first = null;
				
				for(int z = 0; z < PlayFab.Examples.PfSharedModelEx.CurrentUser.UserInventory.Count; z++)
				{	
					InventoryItemController item = this._itemSceneObjects[z].GetComponent<InventoryItemController>();
					
					
					item.Init(this, PlayFab.Examples.PfSharedModelEx.CurrentUser.UserInventory[z]);
					
					if(z == 0)
					{
						first = item;
					}
				}
				ShowPanel();
				
				ItemClicked(first);

				
				//Wallet Code
				StartCoroutine(Wallet.Init());
			 }
			 else
			 {
			 	// close dialog, no items found?
			 	Debug.Log("No user inventory items were found. Closing dialog.");
			 	CloseInventory();
			 	
			 }
		}
		else // show character inventory
		{
			if(PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterInventory != null && PlayFab.Examples.PfSharedModelEx.TitleCatalogs.Count > 0)
			{
				AdjustItemPrefabs(PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterInventory.Count);
				InventoryItemController first = null;
				for(int z = 0; z < PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterInventory.Count; z++)
				{
					InventoryItemController item = this._itemSceneObjects[z].GetComponent<InventoryItemController>();
					
					item.Init(this, PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterInventory[z]);
					
					if(z == 0)
					{
						first = item;
					}
				}
				ShowPanel();
				
				if(this._activeItem == null && first != null)
				{
					ItemClicked(first);
				}
				else if(this._activeItem != null)
				{
					ItemClicked(this._activeItem);
				}
				
				//Wallet Code
				StartCoroutine(Wallet.Init());
			}
			else
			{
				// close dialog, no items found?
				Debug.Log("No charcter inventory items were found. Closing dialog.");
				CloseInventory();
			}
		}
	}
	
	public void ShowPanel()
	{
		this.InventoryPanel.gameObject.SetActive(true);
	}
	
	public void HidePanel()
	{
		this.InventoryPanel.gameObject.SetActive(false);
	}
	
	public void AdjustItemPrefabs(int itemCount)
	{
		if(this._itemSceneObjects.Count > itemCount)
		{
			int numToRemove = this._itemSceneObjects.Count - itemCount;
			for(int z = 0; z < numToRemove; z++)
			{
				Destroy(this._itemSceneObjects[z].gameObject);
			}
			this._itemSceneObjects.RemoveRange(0, numToRemove);
		}
		else if(this._itemSceneObjects.Count < itemCount)
		{
			int numToAdd = itemCount - this._itemSceneObjects.Count;
			for(int z = 0; z < numToAdd; z++)
			{
				Transform go = Instantiate(this.InvItemPrefab);
				go.SetParent(this.ListView, false);
				
				this._itemSceneObjects.Add(go);
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
		
		this._activeItem = item;
		this._activeItem.PanelOutline.effectColor = this._activeItem.SelectedColor;
		UpdateDetails();
	}
	

	public void DeselectItems()
	{
		this._activeItem = null;
		foreach(var item in this._itemSceneObjects)
		{
			InventoryItemController iic = item.GetComponent<InventoryItemController>();
			iic.PanelOutline.effectColor = iic.UnselectedColor;
		}
	}
	
	public void UpdateDetails()
	{
		if(_activeItem.CatalogItem == null)
		 return;
		 
		this.ActiveItemUses.transform.parent.gameObject.SetActive(true);   // by default enable uses field
		this.ActiveExpiration.transform.parent.gameObject.SetActive(false); // by default disable expire field				
		
		this.ActiveItemName.text = this._activeItem.CatalogItem.ItemId;
		this.ActiveItemDescription.text = this._activeItem.CatalogItem.Description;
		this.ActiveItemUses.text =  ""+this._activeItem.ItemInstance.RemainingUses;
		
		if(this._activeItem.CatalogItem.Bundle != null)
		{
			this.ActiveItemType.text = "Bundle";
			EnableDurableButton();
		}
		else if(this._activeItem.CatalogItem.Container != null)
		{
			this.ActiveItemType.text = "Container";
			EnableOpenButton();
		}
		else if(this._activeItem.CatalogItem.Consumable.UsageCount > 0 && this._activeItem.CatalogItem.Consumable.UsagePeriod == null)
		{
			this.ActiveItemType.text = "Consumable";
			EnableUseButton();
		}
		else if(this._activeItem.CatalogItem.Consumable.UsageCount > 0 && this._activeItem.CatalogItem.Consumable.UsagePeriod != null)
		{
			this.ActiveItemType.text = "Time-limited";
			this.ActiveExpiration.text = string.Format("{0:g}", this._activeItem.ItemInstance.Expiration);
			this.ActiveExpiration.transform.parent.gameObject.SetActive(true);
			EnableUseButton();
		}
		else 
		{
			this.ActiveItemType.text = "Durable";
			this.ActiveItemUses.transform.parent.gameObject.SetActive(false); // hide uses field
			EnableDurableButton();
		}
		
		this.ActiveItemName.text = this._activeItem.CatalogItem.DisplayName;
		this.ActiveItemDescription.text = this._activeItem.CatalogItem.Description;
		this.ActiveItemId.text = this._activeItem.CatalogItem.ItemId;
		
		this.ActiveIcon.overrideSprite = null;
	}
	
	public void ClearDetails()
	{
		this.ActionButton.onClick.RemoveAllListeners();
		this.ActionButton.interactable = false;
		
		Text btnText = this.ActionButton.GetComponentInChildren<Text>();
		if(btnText != null)
		{
			btnText.text = string.Empty;
		}

		this.ActiveIcon.overrideSprite = null;
		this.ActiveItemType.text = string.Empty;
		this.ActiveItemUses.text = string.Empty;
		this.ActiveExpiration.text = string.Empty;
		this.ActiveItemName.text = string.Empty;
		this.ActiveItemDescription.text = string.Empty;
		this.ActiveItemId.text = string.Empty;
	}

	public void EnableUseButton()
	{
		this.ActionButton.onClick.RemoveAllListeners();
		this.ActionButton.onClick.AddListener(() => { ConsumeItem(); });
		this.ActionButton.interactable = true;
		this.ActionButton.GetComponentInChildren<Text>().text = "Use / Consume Item";
	}
	
	public void EnableOpenButton()
	{
		this.ActionButton.onClick.RemoveAllListeners();
		this.ActionButton.onClick.AddListener(() => { UnlockContainer(); });
		this.ActionButton.interactable = true;
		this.ActionButton.GetComponentInChildren<Text>().text = "Open Container";
	}
	
	public void EnableDurableButton()
	{
		this.ActionButton.onClick.RemoveAllListeners();
		this.ActionButton.interactable = false;
		this.ActionButton.GetComponentInChildren<Text>().text = "Durable - No Actions";
	}
	
	public void CloseInventory()
	{
		this.gameObject.SetActive(false);
	}
	
	public void Refresh()
	{
		PlayFab.Examples.Client.InventoryExample.LoadInventoryFromPlayFab();
	}
	
	public void ConsumeItem()
	{
		Debug.Log("Consume Item: " + this._activeItem.CatalogItem.ItemId);
		PlayFab.Examples.Client.InventoryExample.ConsumeItem(this._activeItem.ItemInstance.ItemInstanceId, 1);
	}
	
	public void UnlockContainer()
	{
		Debug.Log("Unlocking Container: " + this._activeItem.CatalogItem.ItemId);
		PlayFab.Examples.Client.InventoryExample.UnlockContainer(this._activeItem.ItemInstance.ItemId, this._activeItem.ItemInstance.CatalogVersion);
		//unlock();
	}
	
	public void OpenHelpUrl()
	{
		MainExampleController.OpenWebBrowser(this.ActiveHelpUrl);
	}
}
