using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Examples;

public class ActiveUserInfoController : MonoBehaviour {
	public LoginResult ActiveLogin;
	
	//UI 
	public Text DisplayName;
	public Text PFID;
	public Button AccountInfo;
	public Button ToggleCharacter;
	
	private const string _blank = "__________"; 
	
	// Use this for initialization
	void Start () {
		this.ToggleCharacter.onClick.AddListener(() => { OnToggleCharacterClick(); });
	}
	
	public void Init(LoginResult loginResult)
	{		
		this.PFID.text = loginResult.PlayFabId;
		this.DisplayName.text =  string.IsNullOrEmpty(PfSharedModelEx.currentUser.accountInfo.TitleInfo.DisplayName) ? _blank : PfSharedModelEx.currentUser.accountInfo.TitleInfo.DisplayName;
		GetUserCharacters();
	}
	
	public void GetUserCharacters()
	{
		if(PfSharedModelEx.currentUser.playFabId == null)
			return;
			
		PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserLogin, PfSharedModelEx.currentUser.playFabId, null, PfSharedControllerEx.Api.Client, false);
		var clientRequest = new ListUsersCharactersRequest();
		PlayFabClientAPI.GetAllUsersCharacters(clientRequest, GetUserCharactersCallBack, PfSharedControllerEx.FailCallback("C_GetAllUsersCharacters"));
	}
	
	public void GetUserCharactersCallBack(ListUsersCharactersResult charResult)
	{
		CharacterModel temp;
		foreach (var character in charResult.Characters)
		{
			if (!PfSharedModelEx.currentUser.userCharacters.TryGetValue(character.CharacterId, out temp))
			{
				PfSharedModelEx.currentUser.userCharacters[character.CharacterId] = new CharacterModel(character);
			}
		}
		
		this.ToggleCharacter.interactable = true;
		
		Debug.Log("All characters loaded. (" + charResult.Characters.Count + ")");
	}
	
	public void OnToggleActiveAccountClicked()
	{
		Debug.Log("User to Character switching not yet enabled.");
	}
	
	public void OnToggleCharacterClick()
	{
		Dictionary<string, CharacterModel> idToNameMap = new Dictionary<string, CharacterModel>();
		
		// Add base account as an option if we have a character enabled
		if(PfSharedModelEx.activeMode != PfSharedModelEx.ModelModes.User)
		{
			string currentUserText = PfSharedModelEx.currentUser.accountInfo != null && !string.IsNullOrEmpty(PfSharedModelEx.currentUser.accountInfo.TitleInfo.DisplayName) ? PfSharedModelEx.currentUser.accountInfo.TitleInfo.DisplayName : PfSharedModelEx.currentUser.accountInfo.PlayFabId;
			idToNameMap.Add(string.Format("[User] - {0}", currentUserText), null);
		}
		
		
		foreach(var character in PfSharedModelEx.currentUser.userCharacters)
		{
			// no need to list the active character
			if(character.Value != PfSharedModelEx.currentCharacter)
			{
				idToNameMap.Add(string.Format("[Char] - {0}", character.Value.details.CharacterName), character.Value);
			}
		}
		
		// run after user makes a selection
		System.Action<int> afterInput = (int index) => 
		{
			UpdateActiveModel(idToNameMap.ElementAt(index).Value);
		};
		
		SharedDialogController.RequestSelectorPrompt("Select an account:", idToNameMap.Keys.ToList(), afterInput);
	}
	
	public void UpdateActiveModel(CharacterModel cm = null )
	{
		// switch to character
		if(cm != null)
		{
			PfSharedModelEx.activeMode = PfSharedModelEx.ModelModes.Character;
			PfSharedModelEx.currentCharacter = cm;
			this.PFID.text = cm.details.CharacterId;
			this.DisplayName.text = cm.details.CharacterName;
		}
		else
		{
			// switch back to user
			PfSharedModelEx.activeMode = PfSharedModelEx.ModelModes.User;
			PfSharedModelEx.currentCharacter = null;
			this.PFID.text = PfSharedModelEx.currentUser.accountInfo.PlayFabId;
			this.DisplayName.text = string.IsNullOrEmpty(PfSharedModelEx.currentUser.accountInfo.TitleInfo.DisplayName) ? _blank : PfSharedModelEx.currentUser.accountInfo.TitleInfo.DisplayName;
		}
	}
}
