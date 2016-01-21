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
	
	public UnityEvent RunOnEnable; 		// methods to run when this module is opened
	public UnityEvent RunOnDisable; 	// methods to run when this module is closed

	void OnEnable()
	{
		if(RunOnEnable != null)
		{
		 	RunOnEnable.Invoke();
		}
	}
	
	void OnDisable()
	{
		if(RunOnDisable != null)
		{
			RunOnDisable.Invoke();
		}
	}
	
	
	public void InitSection() // callback param?
	{
		// callback can send back a list of subsection buttons -- text / onClick
		// LOOP through delegates and fire ones registered
	}
}


[System.Serializable]
public class AssociatedButtons 
{
	public string ButtonName;
	public Transform ObjectToEnable;
}