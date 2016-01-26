using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;

/// <summary>
/// Inventory item controller
/// </summary>
public class InventoryItemController : MonoBehaviour {
	public ItemInstance ItemInstance;
	public CatalogItem CatalogItem;
	
	public InventoryController MainController;
	
	public Outline PanelOutline;
	public Color32 SelectedColor;
	public Color32 UnselectedColor;
	
	public Button SelectButton;
	public Text ItemId;
	public Image Icon; 
	
	/// <summary>
	/// Initializes the inventory item and sets up the proper action for when the item is clicked.
	/// </summary>
	/// <param name="controller">a reference to the inventory controller</param>
	/// <param name="item">a reference to the PlayFab item instance </para>.</param>
	public void Init(InventoryController controller, ItemInstance item)
	{
		this.ItemInstance = item;
		this.MainController = controller;
		this.ItemId.text = item.ItemId;

		
		this.CatalogItem = PlayFab.Examples.PfSharedModelEx.GetCatalogItemById(item.ItemId, item.CatalogVersion);
		
		if(this.CatalogItem == null)  // TODO determine what to do here. try to find the item in the first / default catalog?
		{
			this.CatalogItem = PlayFab.Examples.PfSharedModelEx.GetCatalogItemById(item.ItemId, null);
		}
		
		// still not found, now just populate the info we can get from the ItemInstance.
		if(this.CatalogItem == null)  
		{
			this.CatalogItem = new CatalogItem();
			this.CatalogItem.ItemId = item.ItemId;
			this.CatalogItem.DisplayName = item.DisplayName;
			this.CatalogItem.Description = "Corresponding CatalogItem not found. Ensure that you have " + item.CatalogVersion + " loaded.";
			this.CatalogItem.CatalogVersion = item.CatalogVersion;
			this.CatalogItem.ItemClass = item.ItemClass;
			this.CatalogItem.Consumable = new CatalogItemConsumableInfo(){ UsageCount = (uint?)item.RemainingUses };
		}
		
		this.SelectButton.onClick.RemoveAllListeners();
		
		if(this.CatalogItem != null)
		{
			this.SelectButton.onClick.AddListener(() => { MainController.ItemClicked(this); });
		}
		else
		{
			this.PanelOutline.effectColor = Color.red;
		}
	}
}
