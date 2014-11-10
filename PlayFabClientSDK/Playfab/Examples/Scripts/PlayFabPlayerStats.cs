using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab.Examples;
using PlayFab;
using PlayFab.ClientModels;

namespace PlayFab.Examples{
	public class PlayFabPlayerStats : MonoBehaviour {

		public Texture2D health,kills,money,cursor;

		private int totalKillsOld;

		static PlayFabPlayerStats instance;

		static PlayFabPlayerStats Instance
		{
			get
			{
				if (instance == null)
				{
					instance = (PlayFabPlayerStats)FindObjectOfType (typeof (PlayFabPlayerStats));
				}
				return instance;
			}
		}

		public void Start() {
			GetUserDataRequest request = new GetUserDataRequest ();
			if (PlayFabData.AuthKey != null)
				PlayFabClientAPI.GetUserData (request, LoadPlayerData, OnPlayFabError);
			InvokeRepeating("SavePlayerState", 10, 10);
		}

		private void LoadPlayerData(GetUserDataResult result)
		{
			Debug.Log ("Player data loaded.");
			if (result.Data.ContainsKey ("TotalKills"))	
				PlayFabGameBridge.totalKills = int.Parse (result.Data ["TotalKills"].Value);
			else
				PlayFabGameBridge.totalKills = 0;
			totalKillsOld = PlayFabGameBridge.totalKills;
		}
		
		private void SavePlayerState()
		{
			if (PlayFabGameBridge.totalKills != totalKillsOld && PlayFabData.AuthKey != null) {	// we need to save
				// first save as a player property (poor man's save game)
				Debug.Log ("Saving player data...");
				UpdateUserDataRequest request = new UpdateUserDataRequest ();
				request.Data = new Dictionary<string, string> ();
				request.Data.Add ("TotalKills", PlayFabGameBridge.totalKills.ToString ());
				PlayFabClientAPI.UpdateUserData (request, PlayerDataSaved, OnPlayFabError);

				// also save score as a stat for the leaderboard use...
				Dictionary<string,int> stats = new Dictionary<string,int> ();
				stats.Add("score", PlayFabGameBridge.totalKills);
				storeStats(stats);
			}
			totalKillsOld = PlayFabGameBridge.totalKills;
		}

		private void PlayerDataSaved(UpdateUserDataResult result)
		{
			Debug.Log ("PLayer Data saved.");
		}

		public void onDestroy()
		{
			SavePlayerState ();
		}

		public void storeStats(Dictionary<string,int> stats)
		{
			PlayFab.ClientModels.UpdateUserStatisticsRequest request = new PlayFab.ClientModels.UpdateUserStatisticsRequest ();
			request.UserStatistics = stats;
			if (PlayFabData.AuthKey != null)
				PlayFabClientAPI.UpdateUserStatistics (request, StatsUpdated, OnPlayFabError);
		}
		
		private void StatsUpdated(PlayFab.ClientModels.UpdateUserStatisticsResult result)
		{
			Debug.Log ("Stats updated");
		}


		void OnGUI () {
			if (PlayFabItemsController.InventoryLoaded) {
				Rect winRect = new Rect (0,4,health.width, 180);
				
				Rect healthRect = new Rect (winRect.x,winRect.y,health.width, health.height);
				GUI.DrawTexture (healthRect, health);
				GUI.Label (new Rect (healthRect.x + healthRect.width + 4, healthRect.y+health.height*0.5f, 80, 80), "<size=18>"+PlayFabGameBridge.playerHealth+"</size>");
				
				Rect killsRect = new Rect (winRect.x, winRect.y+healthRect.height+4, kills.width, kills.height);
				GUI.DrawTexture (killsRect, kills);
				
				GUI.Label (new Rect (killsRect.x + killsRect.width + 4, killsRect.y+kills.height*0.5f, 80, 80), "<size=18>"+PlayFabGameBridge.totalKills+"</size>");
				
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

		public void LogCustomEvent(string eventName, Dictionary<string,object> body)
		{
			PlayFab.ClientModels.LogEventRequest request = new LogEventRequest ();
			request.eventName = eventName;
			request.Body = body;
			if (PlayFabData.AuthKey != null)
				PlayFabClientAPI.LogEvent (request, EventLogged, OnPlayFabError);
		}
		
		private void EventLogged(LogEventResult result)
		{
				Debug.Log ("Event error " + result);
		}
		
		void OnPlayFabError(PlayFabError error)
		{
			Debug.Log ("Got an error: " + error.ErrorMessage);
		}
	}
}
