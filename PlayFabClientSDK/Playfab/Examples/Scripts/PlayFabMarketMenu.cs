using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabMarketMenu : MonoBehaviour {

	public Texture2D marketIcon,marketMenu,gun2,gun3,health,close,cursor;

	public int titleSize;
	public int textSize;
	public int priceTextSize;
	public int textY;
	public int iconsSpace;
	public int iconsY;
	public int buttonX;
	public int buttonY;

	public bool showMenu;

	private bool drawCursor;

	private List<CatalogItem> items; 
	private bool renderCatalog = false;

	private void Start () {
		////
		/// Get's the specified version of the title's catalog of virtual goods, including purchase options and pricing details
		/// associated with the game title and catalog verion set in Playfab / Developer settings
		////
		GetCatalogItemsRequest request = new GetCatalogItemsRequest();
		request.CatalogVersion = PlayFabData.CatalogVersion;
		PlayFabClientAPI.GetCatalogItems (request,ConstructCatalog,OnPlayFabError);
	}
	
	void OnGUI () {
		if(renderCatalog){
			Rect marketIconRect = new Rect (iconsSpace,Screen.height-marketIcon.height-iconsSpace,marketIcon.width,marketIcon.height );
			if (GUI.Button (marketIconRect, marketIcon,GUIStyle.none)) {
				showMenu = !showMenu;
				PlayFabGameBridge.menuClosed = !PlayFabGameBridge.menuClosed;
			};
			drawCursor = false;
			if (Input.mousePosition.x < marketIconRect.x + marketIconRect.width && Input.mousePosition.x > marketIconRect.x && Screen.height - Input.mousePosition.y < marketIconRect.y + marketIconRect.height && Screen.height - Input.mousePosition.y > marketIconRect.y)
					drawCursor = true;

			if (showMenu) {
				Rect winRect = new Rect (Screen.width * 0.5f - marketMenu.width *0.5f,100,marketMenu.width,marketMenu.height );
				GUI.DrawTexture (winRect, marketMenu);
				if (Input.mousePosition.x < winRect.x + winRect.width && Input.mousePosition.x > winRect.x && Screen.height - Input.mousePosition.y < winRect.y + winRect.height && Screen.height - Input.mousePosition.y > winRect.y)
					drawCursor = true;

				Rect closeRect = new Rect (winRect.x+marketMenu.width-close.width,winRect.y,close.width,close.height );
				if (GUI.Button (closeRect, close,GUIStyle.none)) {
					showMenu = false;
				};



				GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
				centeredStyle.alignment = TextAnchor.UpperCenter;

				int btnWidth = 95;
				int btnHeight = 165;

				for(int x = 0; x < items.Count;  x++)	{
					Rect btn1Rect = new Rect (winRect.x+buttonX+(btnWidth*x)+(iconsSpace*x),winRect.y+buttonY,btnWidth,btnHeight );	
					Rect labelRect = GUILayoutUtility.GetRect(new GUIContent("<size="+titleSize+">"+items[x].DisplayName+"</size>"), "label");
					labelRect.x = btn1Rect.x + btn1Rect.width*0.5f-labelRect.width*0.5f;
					labelRect.y = btn1Rect.y+textY;
					Rect gun2Rect = new Rect (btn1Rect.x+btn1Rect.width*0.5f-gun2.width*0.5f,btn1Rect.y+iconsY,gun2.width, gun2.height);
					Rect labelRectb = GUILayoutUtility.GetRect(new GUIContent("<size="+textSize+">"+items[x].Description+"</size>"), "label");
					labelRectb.width = 100;
					labelRectb.height = 80;
					labelRectb.x = btn1Rect.x + btn1Rect.width*0.5f-labelRectb.width*0.5f;
					labelRectb.y = gun2Rect.y+gun2Rect.height+textY;
					foreach (KeyValuePair<string, uint> price in items[x].VirtualCurrencyPrices)
					{

						if (GUI.Button(btn1Rect,"")){
							PurchaseItemRequest request = new PurchaseItemRequest();
							request.CatalogVersion = items[x].CatalogVersion;
							request.VirtualCurrency = price.Key;
							request.Price = Convert.ToInt32(price.Value);
							request.ItemId = items[x].ItemId;
							PlayFabClientAPI.PurchaseItem(request,PlayFabItemsController.OnPurchase,OnPlayFabError);
						};
						GUI.Label (new Rect (btn1Rect.x+btn1Rect.width*0.5f-10,labelRectb.y+35,40, 40), "<size="+priceTextSize+">"+price.Value+" $</size>",centeredStyle);
					}
					GUI.Label (labelRect, "<size="+titleSize+">"+items[x].DisplayName+"</size>",centeredStyle);
					GUI.DrawTexture (gun2Rect, gun2);
					GUI.Label (labelRectb, "<size="+textSize+">"+items[x].Description+"</size>",centeredStyle);
				
				};
			}
			if (drawCursor) {
				Rect cursorRect = new Rect (Input.mousePosition.x,Screen.height-Input.mousePosition.y,cursor.width,cursor.height );
				GUI.DrawTexture (cursorRect, cursor);
			}
		}
	}

	void Update () {
		PlayFabGameBridge.menuClosed = !showMenu;
	}

	/////
	/// 
	/// 
	/// 		Construct and Render the Catalog based on the Catalog Version
	/// 
	/// 
	/////
	
	private void ConstructCatalog(GetCatalogItemsResult result){
		items = result.Catalog;
		renderCatalog = true;
	}

	void OnPlayFabError(PlayFabError error)
	{
		Debug.Log ("Got an error: " + error.ErrorMessage);
	}
}
