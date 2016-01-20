using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

using PlayFab.ClientModels;

/// <summary>
/// Wallet controller, this displays all currencies for a given player.
/// </summary>
public class WalletController : MonoBehaviour {
	public List<WalletItem> items = new List<WalletItem>();
	public Transform CurrencyDisplayItemPrefab;
	public Transform DisplayContainer;
	
	public IEnumerator Init()
	{
		for(int i = 0; i < this.DisplayContainer.transform.childCount; i++)
		{
			Transform go = this.DisplayContainer.transform.GetChild(i);
			Destroy(go.gameObject);
		}
		this.items.Clear ();
		
		yield return new WaitForEndOfFrame();	
		
		
		if(PlayFab.Examples.PfSharedModelEx.activeMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		{
			// show player balances
			foreach(var kvp in PlayFab.Examples.PfSharedModelEx.currentUser.userVC)
			{
				Transform go = Instantiate(this.CurrencyDisplayItemPrefab);
				go.SetParent(DisplayContainer, false);
				WalletItem item = go.GetComponent<WalletItem>();
				item.Code.text = string.Format("{0}:", kvp.Key);
				item.Value.text = string.Format("{0:n0}", kvp.Value);
				
				this.items.Add(item);
			}
		}
		else
		{
			// show character balances
			foreach(var kvp in PlayFab.Examples.PfSharedModelEx.currentCharacter.characterVC)
			{
				Transform go = Instantiate(this.CurrencyDisplayItemPrefab);
				go.SetParent(DisplayContainer, false);
				WalletItem item = go.GetComponent<WalletItem>();
				item.Code.text = string.Format("{0}:", kvp.Key);
				item.Value.text = string.Format("{0:n0}", kvp.Value);
				
				this.items.Add(item);
			}
		}
	}
}
