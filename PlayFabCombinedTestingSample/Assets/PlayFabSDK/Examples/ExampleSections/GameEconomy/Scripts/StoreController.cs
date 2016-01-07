using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using PlayFab.ClientModels;

using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoreController : MonoBehaviour {
	
	
	public enum StoreControllerStates { GetCatalog, GetStore }
	public StoreControllerStates DisplayState;
	public bool useCachedItems = false;

	public GameObject storePanel;
	public GameObject overlayTint;
	
	public Text panelTitleBar;
	private List<Transform> itemSceneObjects = new List<Transform>();
	public Transform panelListView;
	public Transform itemPrefab;
	
	public WalletController wallet;

	public StoreItemController selectedItem;

	// SET catalog and store name defaults here.
	public string storeName = "default";
	public string catalogName = "1";
	
	private bool hasInitialCatalogLoaded = false;
	
	
	void Awake()
	{
		//PlayFab.Examples.Client.VirtualCurrencyExample.SetUp();
		//PlayFab.Examples.Client.InventoryExample.SetUp();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnEnable()
	{
		HideStore();
		//PlayFab.Examples.PfSharedControllerEx.RegisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnStoreLoaded, HandleOnStoreLoad);
		//PlayFab.Examples.PfSharedControllerEx.RegisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnCatalogLoaded, HandleOnCatalogLoad);
		//PlayFab.Examples.PfSharedControllerEx.RegisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnInventoryLoaded, HandleOnInventoryLoaded);
		
		
		// based on settings, we want to fetch new store / catalog and build our store view.
		// if we are using alt catalog or store, we should prompt for what store / catalog to load.
		// 
		if(this.DisplayState == StoreControllerStates.GetStore)
		{
			UnityAction<string> afterInput = (string response) =>
			{
				if(!string.IsNullOrEmpty(response))
				{
//					if(response == this.storeName && this.useCachedItems == true && PlayFab.Examples.PfSharedModelEx.cachedStoreItems.Count > 0)
//					{
//						// store already retrived, draw it
//						ShowStore();
//					}
//					else
//					{
//						// need to wait on store to load before drawing it
//						this.storeName = response;
//						PlayFab.Examples.Client.InventoryExample.GetStoreItems(response); 
//					}
				}
				else
				{
					this.gameObject.SetActive(false);
				}
			};
			
			
			if(!string.IsNullOrEmpty(this.storeName))
			{
				SharedDialogController.RequestTextInputPrompt("Store Mode:","Enter the name of the store you wish to retrieve.", afterInput, this.storeName);
			}
			else
			{
				SharedDialogController.RequestTextInputPrompt("title","msg", afterInput);
			}
			
		}
		else if(DisplayState == StoreControllerStates.GetCatalog)
		{
			UnityAction<string> afterInput = (string response) =>
			{
				if(!string.IsNullOrEmpty(response))
				{
					if(string.Equals(response, this.catalogName) && this.useCachedItems == true && PlayFab.Examples.PfSharedModelEx.clientCatalog.Count > 0)
					{
						// store already retrived, draw it
						ShowCatalog();
					}
					else
					{
						// need to wait on store to load before drawing it
						this.catalogName = response;
						//PlayFab.Examples.Client.InventoryExample.GetCatalogItems(response); 
					}
				}
				else
				{
					this.gameObject.SetActive(false);
				}
			};
			
			
			if(!string.IsNullOrEmpty(this.storeName))
			{
				SharedDialogController.RequestTextInputPrompt("Catalog Mode:","Enter the name of the catalog you wish to retrieve.", afterInput, this.catalogName);
			}
			else
			{
				SharedDialogController.RequestTextInputPrompt("title","msg", afterInput);
			}
		}
	
	}
	
	public void OnDisable()
	{
//		PlayFab.Examples.PfSharedControllerEx.UnregisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnStoreLoaded, HandleOnStoreLoad);
//		PlayFab.Examples.PfSharedControllerEx.UnregisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnCatalogLoaded, HandleOnCatalogLoad);
//		PlayFab.Examples.PfSharedControllerEx.UnregisterEventMessage(PlayFab.Examples.PfSharedControllerEx.EventType.OnInventoryLoaded, HandleOnInventoryLoaded);
	}
	
	public void InitStore(List<StoreItem> stock = null)
	{
		if(stock != null && PlayFab.Examples.PfSharedModelEx.clientCatalog.Count > 0)
		{
			AdjustItemPrefabs(stock.Count);
			
			int counter = 0;
			foreach(var item in stock)
			{
				StoreItemController itemController = this.itemSceneObjects[counter].GetComponent<StoreItemController>();
				//this.itemSceneObjects[counter].gameObject.SetActive(true);
				
				CatalogItem cItem = null;
				PlayFab.Examples.PfSharedModelEx.clientCatalog.TryGetValue(item.ItemId, out cItem);
				if(cItem != null)
				{
					// swap our catalog prices with the selected store prices.
					cItem.VirtualCurrencyPrices = item.VirtualCurrencyPrices;
					cItem.RealCurrencyPrices = item.RealCurrencyPrices;
					itemController.Init(cItem, this);
				}
				counter++;
			}
		}
	}
	
	public void InitCatalog(Dictionary<string, CatalogItem> stock = null)
	{
		
		//adjust item prefabs (ensure the correct # of preabs exist)
		if(stock != null)
		{
			AdjustItemPrefabs(stock.Count);
			
			int counter = 0;
			foreach(var kvp in stock)
			{
				// only show items that can be purchases, i.e. ones that have a price
				
				if( (kvp.Value.VirtualCurrencyPrices != null && kvp.Value.VirtualCurrencyPrices.Count > 0) || (kvp.Value.RealCurrencyPrices != null && kvp.Value.RealCurrencyPrices.Count > 0))
				{
					StoreItemController itemController = this.itemSceneObjects[counter].GetComponent<StoreItemController>();
					//this.itemSceneObjects[counter].gameObject.SetActive(true);
					itemController.Init(kvp.Value, this);
					counter++;
				}
			}
		}
	}
	
	
	
	public void AdjustItemPrefabs(int itemCount)
	{
		DeselectItems();
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
				Transform go = Instantiate(this.itemPrefab);
				go.SetParent(this.panelListView, false);
				
				this.itemSceneObjects.Add(go);
			}
		}
	}
	
	
	public void HandleOnInventoryLoaded(string playFabId, string characterId, PlayFab.Examples.PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
	{
		StartCoroutine(this.wallet.Init());
	}
	
	
	public void HandleOnStoreLoad(string playFabId, string characterId, PlayFab.Examples.PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
	{
		if(this.DisplayState == StoreControllerStates.GetStore && this.hasInitialCatalogLoaded == true)
		{
			StartCoroutine(this.wallet.Init());
			ShowStore();
		}
	}
	
	public void HandleOnCatalogLoad(string playFabId, string characterId, PlayFab.Examples.PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
	{
		if(this.DisplayState == StoreControllerStates.GetCatalog && this.hasInitialCatalogLoaded == true)
		{
			StartCoroutine(this.wallet.Init());
			ShowCatalog();
		}
		else
		{
			this.hasInitialCatalogLoaded = true;
		}
	}		
		
	public void ShowStore()
	{
		this.panelTitleBar.text = string.Format("Store: \"{0}\"", this.storeName);
		this.overlayTint.SetActive(true);
		this.storePanel.SetActive(true);
		//InitStore(PlayFab.Examples.PfSharedModelEx.cachedStoreItems);
		//var count = PlayFab.Examples.PfSharedModelEx.cachedStoreItems.Count;
	}
		
	public void HideStore()
	{
		this.selectedItem = null;
		this.overlayTint.SetActive(false);
		this.storePanel.SetActive(false);
	}
	
	public void ShowCatalog()
	{
		this.panelTitleBar.text = string.Format("Catalog: \"{0}\"", this.catalogName);
		this.overlayTint.SetActive(true);
		this.storePanel.SetActive(true);
		InitCatalog(PlayFab.Examples.PfSharedModelEx.clientCatalog);
		//var count = PlayFab.Examples.PfSharedModelEx.clientCatalog.Count;

	}
	
	// probably dont need this
//	public void HideCatalog()
//	{
//		this.selectedItem = null;
//		this.overlayTint.SetActive(false);
//		this.storePanel.SetActive(false);
//	}
	
	
//	public void AfterStoreRetrieved(GetStoreItemsRequest request)
//	{
//		
//	}
	
	public void SelectItem(StoreItemController item)
	{
		DeselectItems();
		
		this.selectedItem = item;
		this.selectedItem.buyButton.interactable = true;
		this.selectedItem.panelOutline.effectColor = this.selectedItem.selectedColor;
	}
	
	public void DeselectItems()
	{
		this.selectedItem = null;
		foreach(var item in this.itemSceneObjects)
		{
			StoreItemController sic = item.GetComponent<StoreItemController>();
			sic.buyButton.interactable = false;
			sic.panelOutline.effectColor = sic.unselectedColor;
		}
		
	}
	
	public void BuyItem(CatalogItem item)
	{
		Debug.Log("Buying: " + item.ItemId);
		
		if(this.DisplayState == StoreControllerStates.GetStore)
		{
			//System.Action buyAction = PlayFab.Examples.Client.InventoryExample.PurchaseUserItem(item.ItemId);
			//buyAction();
		}
		else if(this.DisplayState == StoreControllerStates.GetCatalog)
		{
			//System.Action buyAction = PlayFab.Examples.Client.InventoryExample.PurchaseUserItem(item.ItemId);
			//buyAction();
		}
	}
	
	
	public void CloseStore()
	{
		this.gameObject.SetActive(false);
	}
}
