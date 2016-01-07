using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.Collections;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Examples;

public class ActiveUserInfoController : MonoBehaviour {
	
	public LoginResult ActiveLogin;
	
	//UI 
	public Text DisplayName;
	public Text PFID;
	public Button AccountInfo;
	public Button ToggleActiveAccount;
	
	private string _blank = "__________"; 
	
	// pick character // toggel // swap
	
	// Use this for initialization
	void Start () {
		PfSharedControllerEx.RegisterEventMessage(PfSharedControllerEx.EventType.OnUserCharactersLoaded, OnGetCharacterList);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Init(LoginResult loginResult)
	{
		this.ActiveLogin = loginResult;
		
		this.PFID.text = loginResult.PlayFabId;
		this.DisplayName.text =  string.IsNullOrEmpty(PlayFabAuthenticationManager.AccountInfo.TitleInfo.DisplayName) ? this._blank : PlayFabAuthenticationManager.AccountInfo.TitleInfo.DisplayName;
	}
	
		// CLIENT
		//			PfSharedModelEx.globalClientUser.playFabId = loginResult.PlayFabId;
		//			PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserLogin, loginResult.PlayFabId, null, PfSharedControllerEx.Api.Client, false);
		//			var clientRequest = new ListUsersCharactersRequest();
		//			PlayFabClientAPI.GetAllUsersCharacters(clientRequest, ClientCharCallBack, PfSharedControllerEx.FailCallback("C_GetAllUsersCharacters"));
		
	//		
	//		public static void ClientCharCallBack(ListUsersCharactersResult charResult)
	//		{
	//			CharacterModel temp;
	//			foreach (var character in charResult.Characters)
	//			{
	//				if (!PfSharedModelEx.globalClientUser.clientCharacterModels.TryGetValue(character.CharacterId, out temp))
	//					PfSharedModelEx.globalClientUser.clientCharacterModels[character.CharacterId] = new PfInvClientChar(PfSharedModelEx.globalClientUser.playFabId, character.CharacterId, character.CharacterName);
	//				PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserCharactersLoaded, PfSharedModelEx.globalClientUser.playFabId, character.CharacterId, PfSharedControllerEx.Api.Client, false);
	//			}
	//		}
	
	
	public void GetUserCharacters()
	{
		if(PfSharedModelEx.globalClientUser.playFabId == null)
			return;
			
		PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserLogin, PfSharedModelEx.globalClientUser.playFabId, null, PfSharedControllerEx.Api.Client, false);
		var clientRequest = new ListUsersCharactersRequest();
		PlayFabClientAPI.GetAllUsersCharacters(clientRequest, ClientCharCallBack, PfSharedControllerEx.FailCallback("C_GetAllUsersCharacters"));
	}
	
	
	public static void ClientCharCallBack(ListUsersCharactersResult charResult)
	{
		CharacterModel temp;
		foreach (var character in charResult.Characters)
		{
			if (!PfSharedModelEx.globalClientUser.clientCharacterModels.TryGetValue(character.CharacterId, out temp))
				PfSharedModelEx.globalClientUser.clientCharacterModels[character.CharacterId] = new PfInvClientChar(PfSharedModelEx.globalClientUser.playFabId, character.CharacterId, character.CharacterName);
		}
		// send event here...
		//PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserCharactersLoaded, PfSharedModelEx.globalClientUser.playFabId, character.CharacterId, PfSharedControllerEx.Api.Client, false);
	}
	
	public void OnToggleActiveAccountClicked()
	{
		Debug.Log("User to Character switching not yet enabled.");
	}
	
	public void OnGetCharacterList(string playFabId, string characterId, PfSharedControllerEx.Api eventSourceApi, bool requiresFullRefresh)
	{
		Debug.Log("!!!!!");
	}
	
	
	
}
