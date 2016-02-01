using UnityEngine;
using UnityEngine.UI;

public class ExampleSubMenuController : MonoBehaviour {
	public Button BaseButton;
	public Transform ListView;
	
	public void Init(ExampleSection section)
	{
		ClearButtons(); 
		//BACK HERE
		
		for(int z = 0; z < section.SectionController.Buttons.Count; z++)
		{
			var additional = GameObject.Instantiate(BaseButton);
			additional.transform.SetParent(this.ListView, false);
			
			Text text = additional.GetComponentInChildren<Text>();
			text.text = string.Format("{0}", section.SectionController.Buttons[z].ButtonName );
			
			
			int zCapture = z;
			additional.onClick.RemoveAllListeners();
			additional.onClick.AddListener(() => 
			{
				section.SectionController.Buttons[zCapture].ObjectToEnable.gameObject.SetActive(true);
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
}
