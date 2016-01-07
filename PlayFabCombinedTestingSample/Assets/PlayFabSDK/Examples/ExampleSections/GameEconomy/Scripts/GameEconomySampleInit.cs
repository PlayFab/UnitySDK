using UnityEngine;
using System.Collections;

public class GameEconomySampleInit : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		PlayFab.Examples.Client.VirtualCurrencyExample.SetUp();
		PlayFab.Examples.Client.InventoryExample.SetUp();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
