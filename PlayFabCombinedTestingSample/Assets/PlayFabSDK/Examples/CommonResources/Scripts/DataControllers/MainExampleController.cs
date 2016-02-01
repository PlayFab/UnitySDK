using UnityEngine;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;

/// <summary>
/// This class begins the demo project and provides the bridge for going between example modules. This behavior is activated and triggered after a successful login via the PlayFabAuthenticationManager
/// </summary>
public class MainExampleController : MonoBehaviour {
	public Transform ModuleCanvas;						// scene reference to the module canvas, all samples will be loaded within this canvas
	public SharedDialogController DialogCanvas;			// scene reference to the dialog canvas, this supports common dialogs used across several modules
	public ExamplesMenuController ExamplesMenu;			// scene reference to the examples menu. This menu should have a button to start up any samples that are within the PlayFabExamples/ExampleSections
	public ExampleSubMenuController ExamplesSubMenu;	// scene reference to the examples sub menu. This will contain buttons that toggle sample sub sections on and off
	public ActiveUserInfoController ActiveUserInfo;		// scene reference to the details pane in the bottom left of the canvas. Player details and other options will be found here.
	public Transform WelcomeWindow;
	
	public List<ExampleSection> Sections = new List<ExampleSection>();	// scene reference to the various examples in the project
	
	private static readonly Dictionary<int, System.DateTime> CallTimes_InstGl = new Dictionary<int, System.DateTime>();
	
	void OnEnable()
	{
        PlayFab.PlayFabSettings.RegisterForResponses("/Client/LoginWithCustomID", GetType().GetMethod("AfterLogin", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
	}
	
	void OnDisable()
	{
        PlayFab.PlayFabSettings.UnregisterForResponses("/Client/LoginWithCustomID", GetType().GetMethod("AfterLogin", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public), this);
	}
	
	private void OnLoginWithCustomIDRequest(string url, int callId, object request, object customData)
	{
		CallTimes_InstGl[callId] = System.DateTime.UtcNow;
	}
	
	private void OnLoginWithCustomIDResponse(string url, int callId, object request, object result, PlayFabError error, object customData)
	{
		LoginResult lr = null;
		try
		{
			lr = PlayFab.Json.JsonConvert.DeserializeObject<LoginResult>((string)result);
		}
		catch(System.Exception)
		{
			Debug.Log("Cast Error on LoginResult");
			return;
		}
		
		var delta = System.DateTime.UtcNow - CallTimes_InstGl[callId];
		Debug.Log(url + " completed in " + delta.TotalMilliseconds + ", " + lr.SessionTicket);
		CallTimes_InstGl.Remove(callId);
	}
	
	/// <summary>
	/// Called after a successful login, will parse the resources directories and load all ExampleSectionController's found
	/// </summary>
	/// <param name="linkType">The login pathway used </param>
	/// <param name="result">Result the PlayFab model returned from the login request</param>
	public void AfterLogin(string url, int callId, object request, object result, PlayFab.PlayFabError error, object customData)
	{
		try
		{
			this.ActiveUserInfo.Init((LoginResult)result);
		}
		catch(System.Exception ex)
		{
			Debug.LogError(ex.Message);
		}
		
		FetchCloudScriptEndpoint();
		
		// load any ExampleSectionController found at the root of any Resources directory
		ExampleSectionController[] sections = Resources.LoadAll<ExampleSectionController>("");
		
		if(sections.Length > 0)
		{
			this.Sections.Clear();
			ClearLoadedAssets();
			
			foreach(var section in sections)
			{
				ExampleSection additional = new ExampleSection(){
					SectionController = section,
					SectionName = section.SectionName,
					SectionOrder = section.SectionOrder,
					IsInstantiated = false
				};
				
				this.Sections.Add(additional);
			}
			
			this.Sections.Sort((x, y) => x.SectionOrder.CompareTo(y.SectionOrder));
			
			ShowExamplesMenu();
			this.ExamplesMenu.Init(this.Sections, InstantiateOrActivateSection);
		}
		else
		{
			Debug.LogWarning("No example modules found in the project. ");
		}	
	}
	
	
	public void FetchCloudScriptEndpoint()
	{
		PlayFabClientAPI.GetCloudScriptUrl(new GetCloudScriptUrlRequest(), result => { }, null);
	}
	
	/// <summary>
	/// Instantiates a new section or reactivates already loaded objects. 
	/// </summary>
	/// <param name="index">Index.</param>
	public void InstantiateOrActivateSection(int index)
	{
		if(index < this.Sections.Count)
		{
			DeactivateAllSections();
			if(this.Sections[index].IsInstantiated)
			{
				this.Sections[index].SectionController.gameObject.SetActive(true);
			}
			else
			{
				if(this.Sections[index].SectionController != null)
				{
					var instance = GameObject.Instantiate(this.Sections[index].SectionController.gameObject);
					
					instance.transform.SetParent(this.ModuleCanvas.transform, false);
					instance.SetActive(true);
					
					this.Sections[index].IsInstantiated = true;
					this.Sections[index].SectionController = instance.GetComponent<ExampleSectionController>();
				}
			}
			HideExamplesMenu();
			this.ExamplesSubMenu.Init(this.Sections[index]);
		}
		else
		{
			Debug.Log("Index not found in section list.");
		}
	}
	
	public void DeactivateAllSections()
	{
		foreach(var section in this.Sections)
		{
			if(section.IsInstantiated == true)
			{
				section.SectionController.gameObject.SetActive(false);
			}
		}
		ShowExamplesMenu();
	}
	
	public void ClearLoadedAssets()
	{
		var children = this.ModuleCanvas.transform.GetComponentsInChildren<Transform>();
		
		for( int z = 0; z < children.Length; z++)
		{
			// dont delete the parent
			if(children[z] != this.ModuleCanvas.transform)
			{
				Destroy(children[z].gameObject);
			}
		}
		
		// cleanup anything left over from previous loads
		Resources.UnloadUnusedAssets();
	}
	
	
	public void HideExamplesMenu()
	{
		this.ExamplesMenu.gameObject.SetActive(false);
		ShowExamplesSubMenu();
	}
	
	public void ShowExamplesMenu()
	{
		this.ExamplesMenu.gameObject.SetActive(true);
		HideExamplesSubMenu();
	}
	
	public void HideExamplesSubMenu()
	{
		this.ExamplesSubMenu.gameObject.SetActive(false);
	}
	
	public void ShowExamplesSubMenu()
	{
		this.ExamplesSubMenu.gameObject.SetActive(true);
	}
	
	
	public static void OpenWebBrowser(string url)
	{
		if(!string.IsNullOrEmpty(url))
		{
			Application.OpenURL(url);
		}
	}
	
	// non-static version to be hooked up to from unity 
	public void OpenWebBrowserViaInstance(string url)
	{
		MainExampleController.OpenWebBrowser(url);
	}
	
	// temp function to output generic information
	public static void DebugOutput(string msg)
	{
		Debug.Log("DebugOut: " + msg);
	}
	
	public void CloseWelcomeWindow()
	{
		this.WelcomeWindow.gameObject.SetActive(false);
	}
}


[System.Serializable]
public class ExampleSection
{
	public string SectionName;
	public int SectionOrder;
	public ExampleSectionController SectionController;
	public bool IsInstantiated;
}


