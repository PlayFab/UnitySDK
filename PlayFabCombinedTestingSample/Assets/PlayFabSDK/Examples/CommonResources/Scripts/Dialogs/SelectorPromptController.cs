using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class SelectorPromptController : MonoBehaviour {
	public Text Title;
	public List<string> Options = new List<string>();
	public Transform OptionItemPrefab;
    public Transform ListView;
    public Button CloseButton;

	private System.Action<int> _callback;

	public void InitSelector(string title, List<string> options, System.Action<int> callback = null)
	{
		this.Title.text = title;
		this.Options = options;
		this._callback = callback;
		CreateItemsToMatchOptions ();
	}
	
	public void ListItemClicked(int index)
	{
		if (this._callback != null) 
		{
			_callback(index);
		} 
		this.gameObject.SetActive (false);
	}

	public void CloseButtonClicked()
	{
		this.gameObject.SetActive (false);
	}

	public void CreateItemsToMatchOptions()
	{
		Button[] items = this.ListView.GetComponentsInChildren<Button> (true);
		List<Button> itemList = items.ToList ();

		if (this.Options.Count > itemList.Count) {
			// not enough buttons, create more
			while (itemList.Count < this.Options.Count) 
			{
				Transform item = Instantiate (this.OptionItemPrefab);
				item.SetParent (this.ListView, false);
				itemList.Add(item.GetComponent<Button>());
			}

		} else if(this.Options.Count < items.Length) 
		{
			// too many buttons, hide the extras.
			for(int z = this.Options.Count; z < items.Length; z++)
			{
				items[z].gameObject.SetActive(false);
				if(z > 15)
				{
					DestroyImmediate(items[z].gameObject);
				}
			}
		}

		for(int z = 0; z < this.Options.Count; z++)
		{
			itemList[z].gameObject.SetActive(true);
			itemList[z].GetComponentInChildren<Text>().text = this.Options[z];
			itemList[z].onClick.RemoveAllListeners();
			int capturedIndex = z;
			itemList[z].onClick.AddListener(() => 
			{ 
				this.ListItemClicked(capturedIndex); 
			});
			itemList[z].gameObject.SetActive(true);
		}
	}


}
