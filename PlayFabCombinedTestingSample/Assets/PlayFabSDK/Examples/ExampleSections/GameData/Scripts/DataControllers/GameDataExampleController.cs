using UnityEngine;
using System.Collections;

public class GameDataExampleController : MonoBehaviour {
	public string[] publisherKeys;

	public void RunOnStart()
	{
		GetPublisherData();
		GetTitleData();
		GetPlayerData();
	}
	
	void GetTitleData()
	{
		PlayFab.Examples.Client.TitleDataExample.GetTitleData();
	}
	
	void GetPublisherData()
	{
		PlayFab.Examples.Client.TitleDataExample.GetPublisherData();
	}
	
	void GetPlayerData()
	{
		if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		{
			PlayFab.Examples.Client.UserDataExample.GetUserData();
			PlayFab.Examples.Client.UserDataExample.GetUserReadOnlyData();
			PlayFab.Examples.Client.StatsExample.GetUserStatistics();
		}
		else
		{
			PlayFab.Examples.Client.UserDataExample.GetActiveCharacterData();
			PlayFab.Examples.Client.UserDataExample.GetActiveCharacterReadOnlyData();
			//PlayFab.Examples.Client.StatsExample.GetActiveCharacterStatistics();
		}
		
		// TODO find a way to check for a publisher first?
		PlayFab.Examples.Client.UserDataExample.GetUserPublisherData();
		PlayFab.Examples.Client.UserDataExample.GetUserPublisherReadOnlyData();
		
	}
	
}
