using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Examples menu controller.
/// </summary>
public class ExamplesMenuController : MonoBehaviour {
	
	public Button BaseButton;											//  prefab for the menu buttons
	public Transform ListView;											//	scene reference for the button container

	public delegate void OnExampleClickedSignature(int index);			// signature for the examples callback

	
	/// <summary>
	/// Init the examples menu. 
	/// </summary>
	/// <param name="sections"> a list of the ExampleSections found in the project </param>
	/// <param name="onClick">the callback after clicking an example button </param>
	public void Init( List<ExampleSection> sections, OnExampleClickedSignature onClick)
	{
		ClearButtons(); 
		
		for(int z = 0; z < sections.Count; z++)
		{
			var additional = GameObject.Instantiate(BaseButton);
			additional.transform.SetParent(this.ListView, false);
			
			Text text = additional.GetComponentInChildren<Text>();
			text.text = string.Format("{0}. {1}", sections[z].SectionOrder, sections[z].SectionName);
			
			int zCapture = z;
			additional.onClick.RemoveAllListeners();
			additional.onClick.AddListener(() => 
			{
				onClick(zCapture);	
			});
		}
	}
	
	public void ClearButtons()
	{
		var children = this.ListView.transform.GetComponentsInChildren<Transform>();
		
		for( int z = 0; z < children.Length; z++)
		{
			// dont delete the parent
			if(children[z] != this.ListView.transform)
			{
				Destroy(children[z].gameObject);
			}
		}
	}
	
	public void ClosePrompt()
	{
		this.gameObject.SetActive(false);
	}
}


