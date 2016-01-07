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
		
		PlayFab.Examples.PfSharedModelEx.clientCatalog.TryGetValue(item.ItemId, out this.catlogItem);
		
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
