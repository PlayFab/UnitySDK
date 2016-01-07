using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using PlayFab.ClientModels;
using System.Collections.Generic;

public class VCItemController : MonoBehaviour {
	public Text vc_code;
	public Button sub50Btn;
	public InputField vc_balance;
	public Button add50Btn;
	public Button setBtn;
	public Image banding;
	
	private EditVCController controller;
	public int _balance;
	public int _initialBalance;
	
	public void Add(int amt)
	{
		this._balance += amt;
		this.vc_balance.text = string.Format("{0:n0}", this._balance);

	}
	
	public void Sub(int amt)
	{
		this._balance = this._balance - amt >= 0 ? this._balance - amt : 0;
		this.vc_balance.text = string.Format("{0:n0}", this._balance);
		
		
	}
	
	public void Init(KeyValuePair<string, int> kvp, EditVCController controller, bool useBanding = false)
	{
		this.vc_code.text = kvp.Key;
		this.vc_balance.text = string.Format("{0:n0}", kvp.Value);
		this._balance = kvp.Value;
		this._initialBalance = this._balance;
		
		this.controller = controller;
		
		this.vc_balance.onEndEdit.RemoveAllListeners();
		this.vc_balance.onEndEdit.AddListener((string input) => { 
			OnBalanceEdited(this.vc_balance.text);
		});
		
		if(useBanding == true)
		{
			this.banding.enabled = true;
		}
		else
		{
			this.banding.enabled = false;
		}
	}
	
	
	public void SetBalance()
	{
		int net = _balance - _initialBalance;
		if(net > 0)
		{
			System.Action add = PlayFab.Examples.Server.VirtualCurrencyExample.AddUserVirtualCurrency(PlayFab.Examples.PfSharedModelEx.globalClientUser.playFabId, this.vc_code.text, net);
			add();
		}
		else if (net < 0)
		{
			// multiply by -1 to get back in the black
			System.Action sub = PlayFab.Examples.Server.VirtualCurrencyExample.SubtractUserVirtualCurrency(PlayFab.Examples.PfSharedModelEx.globalClientUser.playFabId, this.vc_code.text, net * -1);
			sub();
		}
	}
	
	// END EDIT STRING EVENT()
	// called after the input field has been manually updated
	public void OnBalanceEdited(string update)
	{
		int parsed;
		if(System.Int32.TryParse(update, out parsed) && parsed > 0)
		{
			this._balance = parsed;
			this.vc_balance.text = string.Format("{0:n0}", this._balance);
		}
		else
		{
			this.vc_balance.text = string.Format("{0:n0}", this._balance);
		}
	}
	
	
}
