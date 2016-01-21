using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using PlayFab.ClientModels;

/// <summary>
/// Inventory item controller
/// </summary>
public class InventoryItemController : MonoBehaviour {
	public ItemInstance itemInstance;
	public CatalogItem catlogItem;
	
	public InventoryController mainController;
	
	public Outline panelOutline;
	public Color32 selectedColor;
	public Color32 unselectedColor;
	
	public Button selectButton;
	public Text itemId;
	public Image icon; 
	
	/// <summary>
	/// Initializes the inventory item and sets up the proper action for when the item is clicked.
	/// </summary>
	/// <param name="controller">a reference to the inventory controller</param>
	/// <param name="item">a reference to the PlayFab item instance </para>.</param>
	public void Init(InventoryController controller, ItemInstance item)
	{
		this.itemInstance = item;
		this.mainController = controller;
		this.itemId.text = item.ItemId;

		
		this.catlogItem = PlayFab.Examples.PfSharedModelEx.GetCatalogItemById(item.ItemId, item.CatalogVersion);
		
		if(this.catlogItem == null)  // TODO determine what to do here. try to find the item in the first / default catalog?
		{
			this.catlogItem = PlayFab.Examples.PfSharedModelEx.GetCatalogItemById(item.ItemId, null);
		}
		
		// still not found, now just populate the info we can get from the ItemInstance.
		if(this.catlogItem == null)  
		{
			this.catlogItem = new CatalogItem();
			this.catlogItem.ItemId = item.ItemId;
			this.catlogItem.DisplayName = item.DisplayName;
			this.catlogItem.Description = "Corresponding CatalogItem not found. Ensure that you have " + item.CatalogVersion + " loaded.";
			this.catlogItem.CatalogVersion = item.CatalogVersion;
			this.catlogItem.ItemClass = item.ItemClass;
			this.catlogItem.Consumable = new CatalogItemConsumableInfo(){ UsageCount = (uint?)item.RemainingUses };
		}
		
		this.selectButton.onClick.RemoveAllListeners();
		
		if(this.catlogItem != null)
		{
			this.selectButton.onClick.AddListener(() => { mainController.ItemClicked(this); });
		}
		else
		{
			this.panelOutline.effectColor = Color.red;
		}
	}
}
