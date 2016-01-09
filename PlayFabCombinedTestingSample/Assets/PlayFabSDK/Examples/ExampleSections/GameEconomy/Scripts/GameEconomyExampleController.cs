using UnityEngine;
using System.Collections;

public class GameEconomyExampleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void RunOnStart()
	{
		//PlayFab.Examples.PfSharedModelEx
		//PlayFab.Examples.Client.InventoryExample.GetUserInventory;
		Debug.Log("Running game economy start sequence");
		
		//TODO add logic here to conditionally get new data based on cached info.
		PlayFab.Examples.Client.InventoryExample.LoadCatalogFromPlayFab();
		PlayFab.Examples.Client.InventoryExample.LoadInventoryFromPlayFab();
	}
	
	
	//public void 
	
}
