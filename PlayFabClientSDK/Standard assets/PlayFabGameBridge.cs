using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Gun {
	public float Frequency;
	public float ConeAngle;
	public float DamagePerSecond;
	public float HitSoundVolume;
	public float Pitch;
}

public class PlayFabGameBridge : MonoBehaviour{
	
	/// Game Attributes that are custom to the game.
	/// The player health, kill, virtual currency and the current selected gun.
	public static int playerHealth = 100;
	public static int totalKills = 0;

	public static uint gameState = 2; // Can be used for game progress

	public static Dictionary<string,Gun> gunTypes;
	public static List<string> gunNames;
	public static Gun currentGun = new Gun{Frequency=10.0F, ConeAngle=1.5F, DamagePerSecond=20.0F, HitSoundVolume=0.5F, Pitch=1.0F};
	public static string currentGunName = "Default";

	// Disable firing when mouse is hovering over UI
	public static bool mouseOverGui = false;
	
	/// Hold the past and present of the item regarding the number of items
	public static Dictionary<string,int?> consumableItems = new Dictionary<string,int?>();
	public static Dictionary<string,int?> consumableItemsConsumed = new Dictionary<string,int?>();
	public static void consumeItem(string str){
			consumableItems[str] -= 1;
			consumableItemsConsumed[str] += 1;
	}
	public static void consumeItem(string str,int? count){
		consumableItems[str] -= count;
		consumableItemsConsumed[str] += count;
	}
	public static void recordConsumed(string str){
		consumableItemsConsumed[str] = 0;
	}
}

