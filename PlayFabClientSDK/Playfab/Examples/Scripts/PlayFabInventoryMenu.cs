using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayFabInventoryMenu : PlayFabItemsController {

	public Texture2D item1,item2,item3,item1Selected,item2Selected,item3Selected;
	public int spaceInBetween;
	public bool autoUpdateConsumeItems = true;
	public int UpdateEverySeconds = 10;

	private List<Texture2D>itemTextures;
	private List<Texture2D>itemSelectedTextures;
	private Rect[] itemsRect = new Rect[4];
	private int currentItemSelected = 1;
	private int textureWidth = 1;
	private int totalWidth = 1;

	public void Start(){
		itemTextures = new List<Texture2D>(new Texture2D[] { item1,item2,item3 });
		itemSelectedTextures = new List<Texture2D>(new Texture2D[] { item1Selected,item2Selected,item3Selected });
		textureWidth = itemTextures[0].width;
		UpdateInventory ();
		if(autoUpdateConsumeItems)InvokeRepeating("ConsumeNow", 0, UpdateEverySeconds);
	}

	void OnGUI () {
		if(InventoryLoaded){
			totalWidth = (textureWidth * itemTextures.Count) + (spaceInBetween * itemTextures.Count - 1);
			itemsRect[0] = new Rect (Screen.width * 0.5f - totalWidth * 0.5f-itemTextures[0].width-spaceInBetween, Screen.height - itemTextures[0].height - 20, totalWidth, itemTextures[0].height - 20);

			for (int i = 1; i<=itemTextures.Count; i++) {
				itemsRect[i] = new Rect (itemsRect[i-1].x+spaceInBetween+itemTextures[0].width,Screen.height - itemTextures[0].height - 20,itemTextures[0].width, itemTextures[0].height);
				if (currentItemSelected == i) {
					itemsRect[i].y -= 10;
					GUI.DrawTexture (itemsRect[i], itemSelectedTextures[i-1]);	
				}
				else GUI.DrawTexture (itemsRect[i], itemTextures[(i-1)]);
				uint? num = 0;
				if(i==2){
					if (PlayFabGameBridge.consumableItems.ContainsKey("ammo_pack_1"))num = PlayFabGameBridge.consumableItems["ammo_pack_1"];
					GUI.Label (new Rect (itemsRect[i].x, itemsRect[i].y-itemsRect[i].height+55, 80, 80), "<size=22>"+num+"</size>");
				}
				else if(i==3){
					if (PlayFabGameBridge.consumableItems.ContainsKey("ammo_pack_2"))num = PlayFabGameBridge.consumableItems["ammo_pack_2"];
					GUI.Label (new Rect (itemsRect[i].x, itemsRect[i].y-itemsRect[i].height+55, 80, 80), "<size=22>"+num+"</size>");
				}
			}
		}
	}
	private void ConsumeNow(){
		ConsumeItems ();
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.Alpha1))currentItemSelected=1;
		if (Input.GetKeyDown (KeyCode.Alpha2))currentItemSelected=2;
		if (Input.GetKeyDown (KeyCode.Alpha3))currentItemSelected=3;
		PlayFabGameBridge.currentGun = currentItemSelected;
	}
}