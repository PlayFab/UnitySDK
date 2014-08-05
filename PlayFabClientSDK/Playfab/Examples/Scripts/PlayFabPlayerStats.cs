using UnityEngine;
using System.Collections;
using PlayFab.Examples;


public class PlayFabPlayerStats : MonoBehaviour {

	public Texture2D health,kills,money,cursor;


	void OnGUI () {
		if (PlayFabItemsController.InventoryLoaded) {
			Rect winRect = new Rect (0,4,health.width, 180);
			
			Rect healthRect = new Rect (winRect.x,winRect.y,health.width, health.height);
			GUI.DrawTexture (healthRect, health);
			GUI.Label (new Rect (healthRect.x + healthRect.width + 4, healthRect.y+health.height*0.5f, 80, 80), "<size=18>"+PlayFabGameBridge.playerHealth+"</size>");
			
			Rect killsRect = new Rect (winRect.x, winRect.y+healthRect.height+4, kills.width, kills.height);
			GUI.DrawTexture (killsRect, kills);
			
			GUI.Label (new Rect (killsRect.x + killsRect.width + 4, killsRect.y+kills.height*0.5f, 80, 80), "<size=18>"+PlayFabGameBridge.kills+"</size>");
			
			Rect moneyRect = new Rect (winRect.x, killsRect.y+killsRect.height+4, kills.width, kills.height);
			GUI.DrawTexture (moneyRect, money);
			
			GUI.Label (new Rect (moneyRect.x + moneyRect.width + 4, moneyRect.y+kills.height*0.5f, 80, 80), "<size=18>"+PlayFabItemsController.VirtualCurrency["GC"]+"</size>");
			GUI.skin.label.alignment = TextAnchor.UpperLeft;
			if(PlayFabTitleData.PlayFabTitleDataLoaded){
				if (Input.mousePosition.x < healthRect.x + healthRect.width && Input.mousePosition.x > healthRect.x && Screen.height - Input.mousePosition.y < healthRect.y + healthRect.height && Screen.height - Input.mousePosition.y > healthRect.y)
					renderToolTip("icon_health",moneyRect.x,healthRect.y);
				else if (Input.mousePosition.x < killsRect.x + killsRect.width && Input.mousePosition.x > killsRect.x && Screen.height - Input.mousePosition.y < killsRect.y + killsRect.height && Screen.height - Input.mousePosition.y > killsRect.y)
					renderToolTip("icon_kill",moneyRect.x,killsRect.y);
				else if (Input.mousePosition.x < moneyRect.x + moneyRect.width && Input.mousePosition.x > moneyRect.x && Screen.height - Input.mousePosition.y < moneyRect.y + moneyRect.height && Screen.height - Input.mousePosition.y > moneyRect.y)
					renderToolTip("icon_currency",moneyRect.x,moneyRect.y);
			}
		}
	}

	private void renderToolTip(string iconText,float posX,float posY){
		Rect cursorRect = new Rect (Input.mousePosition.x,Screen.height-Input.mousePosition.y,cursor.width,cursor.height );
		GUI.DrawTexture (cursorRect, cursor);
		GUI.Box (new Rect (posX +100, posY, 200, 50),"");
		GUI.Label (new Rect (posX +100, posY, 200, 200), "<size=12>"+PlayFabTitleData.Data[iconText]+"</size>");


	}
}
