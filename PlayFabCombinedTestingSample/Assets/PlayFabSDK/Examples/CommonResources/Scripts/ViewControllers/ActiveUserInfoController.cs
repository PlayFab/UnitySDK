using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Examples;

public class ActiveUserInfoController : MonoBehaviour {
	public LoginResult ActiveLogin;
	
	//UI 
	public Text DisplayName;
	public Text Pfid;
	//public Button AccountInfo;
	public Button ToggleCharacter;
	
	private const string Blank = "__________"; 
	
	// Use this for initialization
	void Start () {
		this.ToggleCharacter.onClick.AddListener(() => { OnToggleCharacterClick(); });
	}
	
	public void Init(LoginResult loginResult)
	{		
		this.Pfid.text = loginResult.PlayFabId;
		this.DisplayName.text =  PfSharedModelEx.CurrentUser.AccountInfo.TitleInfo == null ? Blank : PfSharedModelEx.CurrentUser.AccountInfo.TitleInfo.DisplayName;
		GetUserCharacters();
	}
	
	public void GetUserCharacters()
	{
		if(PfSharedModelEx.CurrentUser.PlayFabId == null)
			return;
			
		PfSharedControllerEx.PostEventMessage(PfSharedControllerEx.EventType.OnUserLogin, PfSharedModelEx.CurrentUser.PlayFabId, null, PfSharedControllerEx.Api.Client, false);
		var clientRequest = new ListUsersCharactersRequest();
		PlayFabClientAPI.GetAllUsersCharacters(clientRequest, GetUserCharactersCallBack, PfSharedControllerEx.FailCallback("C_GetAllUsersCharacters"));
	}
	
	public void GetUserCharactersCallBack(ListUsersCharactersResult charResult)
	{
		CharacterModel temp;
		foreach (var character in charResult.Characters)
		{
			if (!PfSharedModelEx.CurrentUser.UserCharacters.TryGetValue(character.CharacterId, out temp))
			{
				PfSharedModelEx.CurrentUser.UserCharacters[character.CharacterId] = new CharacterModel(character);
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
		if(PfSharedModelEx.ActiveMode != PfSharedModelEx.ModelModes.User)
		{
			string currentUserText = PfSharedModelEx.CurrentUser.AccountInfo != null && !string.IsNullOrEmpty(PfSharedModelEx.CurrentUser.AccountInfo.TitleInfo.DisplayName) ? PfSharedModelEx.CurrentUser.AccountInfo.TitleInfo.DisplayName : PfSharedModelEx.CurrentUser.AccountInfo.PlayFabId;
			idToNameMap.Add(string.Format("[User] - {0}", currentUserText), null);
		}
		
		
		foreach(var character in PfSharedModelEx.CurrentUser.UserCharacters)
		{
			// no need to list the active character
			if(character.Value != PfSharedModelEx.CurrentCharacter)
			{
				idToNameMap.Add(string.Format("[Char] - {0}", character.Value.Details.CharacterName), character.Value);
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
			PfSharedModelEx.ActiveMode = PfSharedModelEx.ModelModes.Character;
			PfSharedModelEx.CurrentCharacter = cm;
			this.Pfid.text = cm.Details.CharacterId;
			this.DisplayName.text = cm.Details.CharacterName;
		}
		else
		{
			// switch back to user
			PfSharedModelEx.ActiveMode = PfSharedModelEx.ModelModes.User;
			PfSharedModelEx.CurrentCharacter = null;
			this.Pfid.text = PfSharedModelEx.CurrentUser.AccountInfo.PlayFabId;
			this.DisplayName.text = string.IsNullOrEmpty(PfSharedModelEx.CurrentUser.AccountInfo.TitleInfo.DisplayName) ? Blank : PfSharedModelEx.CurrentUser.AccountInfo.TitleInfo.DisplayName;
		}
	}
}
