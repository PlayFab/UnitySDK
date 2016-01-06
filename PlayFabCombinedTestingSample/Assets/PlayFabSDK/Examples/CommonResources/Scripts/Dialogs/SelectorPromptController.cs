using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class SelectorPromptController : MonoBehaviour {
	public Text title;
	public List<string> options = new List<string>();
	public Transform optionItemPrefab;
    public Transform ListView;
    public Button closeButton;

	private UnityAction<int> callback;

	public void InitSelector(string title, List<string> options, UnityAction<int> callback = null)
	{
		this.title.text = title;
		this.options = options;
		this.callback = callback;
		CreateItemsToMatchOptions ();
	}


	public void ListItemClicked(int index)
	{
		if (this.callback != null) 
		{
			callback(index);
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

		if (this.options.Count > itemList.Count) {
			// not enough buttons, create more
			while (itemList.Count < this.options.Count) 
			{
				Transform item = Instantiate (this.optionItemPrefab);
				item.SetParent (this.ListView, false);
				itemList.Add(item.GetComponent<Button>());
			}

		} else if(this.options.Count < items.Length) 
		{
			// too many buttons, hide the extras.
			for(int z = this.options.Count; z < items.Length; z++)
			{
				items[z].gameObject.SetActive(false);
				if(z > 15)
				{
					DestroyImmediate(items[z].gameObject);
				}
			}
		}

		for(int z = 0; z < this.options.Count; z++)
		{
			itemList[z].gameObject.SetActive(true);
			itemList[z].GetComponentInChildren<Text>().text = this.options[z];
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
