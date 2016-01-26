using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Wallet controller, this displays all currencies for a given player.
/// </summary>
public class WalletController : MonoBehaviour {
	public List<WalletItem> Items = new List<WalletItem>();
	public Transform CurrencyDisplayItemPrefab;
	public Transform DisplayContainer;
	
	public IEnumerator Init()
	{
		for(int i = 0; i < this.DisplayContainer.transform.childCount; i++)
		{
			Transform go = this.DisplayContainer.transform.GetChild(i);
			Destroy(go.gameObject);
		}
		this.Items.Clear ();
		
		yield return new WaitForEndOfFrame();	
		
		
		Dictionary<string, int> vc = new Dictionary<string, int>();
		if(PlayFab.Examples.PfSharedModelEx.ActiveMode == PlayFab.Examples.PfSharedModelEx.ModelModes.User)
		{
			vc = PlayFab.Examples.PfSharedModelEx.CurrentUser.UserVc;
		}
		else
		{
			vc = PlayFab.Examples.PfSharedModelEx.CurrentCharacter.CharacterVc;
		}
		
		// show player balances
		foreach(var kvp in vc)
		{
			Transform go = Instantiate(this.CurrencyDisplayItemPrefab);
			go.SetParent(DisplayContainer, false);
			WalletItem item = go.GetComponent<WalletItem>();
			item.Code.text = string.Format("{0}:", kvp.Key);
			item.Value.text = string.Format("{0:n0}", kvp.Value);
			
			this.Items.Add(item);
		}
	}
}
