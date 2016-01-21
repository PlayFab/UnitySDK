using UnityEngine;
using System.Collections;
using PlayFab.Examples;

public class GameEconomyExampleController : MonoBehaviour {
	public string primaryCatalog = string.Empty;
	
	// Use this for initialization
	void Start () {
		PfSharedModelEx.primaryCatalogVersion = this.primaryCatalog;
	}
	
	public void RunOnStart()
	{
		Debug.Log("Running game economy start sequence");
		
		//TODO add logic here to conditionally get new data based on cached info.
		FetchCatalog();
		PlayFab.Examples.Client.InventoryExample.LoadInventoryFromPlayFab();
	}
	
	public void FetchCatalog()
	{
		if(PfSharedModelEx.titleCatalogs.Count == 0)
		{
			PlayFab.Examples.Client.InventoryExample.LoadCatalogFromPlayFab();
		}
	} 
}
