using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class VCItemController : MonoBehaviour {
	public Text VcCode;
	public Button Sub50Btn;
	public InputField VcBalance;
	public Button Add50Btn;
	public Button SetBtn;
	public Image Banding;

	public int Balance;
	public int InitialBalance;
	
	public void Add(int amt)
	{
		this.Balance += amt;
		this.VcBalance.text = string.Format("{0:n0}", this.Balance);

	}
	
	public void Sub(int amt)
	{
		this.Balance = this.Balance - amt >= 0 ? this.Balance - amt : 0;
		this.VcBalance.text = string.Format("{0:n0}", this.Balance);
	}
	
	public void Init(KeyValuePair<string, int> kvp, bool useBanding = false)
	{
		this.VcCode.text = kvp.Key;
		this.VcBalance.text = string.Format("{0:n0}", kvp.Value);
		this.Balance = kvp.Value;
		this.InitialBalance = this.Balance;
		
		this.VcBalance.onEndEdit.RemoveAllListeners();
		this.VcBalance.onEndEdit.AddListener((string input) => { 
			OnBalanceEdited(this.VcBalance.text);
		});
		
		if(useBanding == true)
		{
			this.Banding.enabled = true;
		}
		else
		{
			this.Banding.enabled = false;
		}
	}
	
	
	public void SetBalance()
	{
		int net = Balance - InitialBalance;
		
		PlayFab.Examples.Client.InventoryExample.ModifyVcBalance(this.VcCode.text, net);
	}
	
	public void OnBalanceEdited(string update)
	{
		int parsed;
		if(System.Int32.TryParse(update, out parsed))
		{
			this.Balance = parsed;
			this.VcBalance.text = string.Format("{0:n0}", this.Balance);
		}
		else
		{
			this.VcBalance.text = string.Format("{0:n0}", this.Balance);
		}
	}
}
