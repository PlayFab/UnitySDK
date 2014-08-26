using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;

namespace PlayFab.Examples{
	public class PlayFabTitleData : MonoBehaviour {

		public static bool PlayFabTitleDataLoaded = false;
		public static Dictionary<string,string> Data ;

		// Use this for initialization
		void Start () {
			GetTitleDataRequest request = new GetTitleDataRequest ();
			List<string> keys = new List<string> ();
			keys.Add ("connectionlost");
			keys.Add ("nocoins");
			keys.Add ("icon_currency");
			keys.Add ("icon_health");
			keys.Add ("icon_kill");
			request.Keys = keys;
			if (PlayFabData.AuthKey != null)
				PlayFabClientAPI.GetTitleData (request, OnTitleData, OnPlayFabError);
		}

		private void OnTitleData( GetTitleDataResult result){
			Data = result.Data;
			PlayFabTitleDataLoaded = true;
		}

		void OnPlayFabError(PlayFabError error)
		{
			Debug.Log ("Got an error: " + error.ErrorMessage);
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}
