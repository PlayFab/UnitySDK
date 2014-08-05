using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayFabGameBridge : MonoBehaviour{
	
	/// Game Attributes that are custom to the game.
	/// The player health, kill, virtual currency and the current selected gun.
	public static int playerHealth = 0;
	public static int kills = 0;
	public static uint money = 0;
	public static int currentGun = 1;
	public static uint gameState = 1; // Can be used for game progress

	// Used to know when to stop the game when Menus are open. This is custom to any game UX.
	public static bool menuClosed = true;
	
	/// Hold the past and present of the item regarding the number of items
	public static Dictionary<string,uint?> consumableItems = new Dictionary<string,uint?>();
	public static Dictionary<string,uint?> consumableItemsConsumed = new Dictionary<string,uint?>();
	public static void consumeItem(string str){
			consumableItems[str] -= 1;
			consumableItemsConsumed[str] += 1;
	}
}