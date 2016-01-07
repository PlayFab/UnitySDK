using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;

public class ExampleSectionController : MonoBehaviour {
	public string SectionName;
	public int SectionOrder;
	
	public List<AssociatedButtons> Buttons = new List<AssociatedButtons>();
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void InitSection() // callback param?
	{
		// callback can send back a list of subsection buttons -- text / onClick
		
	}
	
	
	
	
}


[System.Serializable]
public class AssociatedButtons 
{
	public string ButtonName;
	public Transform ObjectToEnable;
}