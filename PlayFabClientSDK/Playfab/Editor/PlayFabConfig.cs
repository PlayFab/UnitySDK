using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
 
namespace PlayFab.Editor
{
	public class PlayFabConfig : EditorWindow
    {
		private Texture2D pfLogo;
		private string titleId;
		private string catalogVersion;
		private bool keepSessionKey;
		private bool skipLogin;
		private Texture2D[] sprites;
		private GUIStyle txtStyle = new GUIStyle();

		[MenuItem ("Playfab/Game Config")]
		private static void ShowWindow ()
        {
			EditorWindow.GetWindow<PlayFabConfig> ("PlayFab Config", typeof (SceneView)).Show ();
		}
		
		 void Awake() {
			PlayFabData.LoadData ();
			titleId = PlayFabData.TitleId;
			catalogVersion = PlayFabData.CatalogVersion;
			keepSessionKey = PlayFabData.KeepSessionKey;
			pfLogo = (Texture2D)Resources.LoadAssetAtPath ("Assets/Playfab/Editor/PlayFablogo.png", typeof(Texture2D));
			hideFlags = HideFlags.HideAndDontSave;
			txtStyle.normal.textColor = Color.red;
			
		}

        public void OnGUI ()
        {
			GUILayout.Label(pfLogo);
			if (GUILayout.Button ("Operations Dashboard", GUILayout.Width(200)))
			{
				OpenDashboard ();
			}
			EditorGUILayout.Space();
			GUILayout.Box ("", new GUILayoutOption[]{GUILayout.ExpandWidth (true), GUILayout.Height (1)});
			EditorGUILayout.Space();
			titleId    = EditorGUILayout.TextField ("Title Id", titleId);
			catalogVersion    = EditorGUILayout.TextField ("Catalog Version", catalogVersion);
			EditorGUIUtility.labelWidth = 200;
			keepSessionKey = EditorGUILayout.Toggle("Keep session key", keepSessionKey);
			EditorGUIUtility.labelWidth = 0;
			if (keepSessionKey) {
				EditorGUILayout.LabelField ("Current authKey : "+PlayFabClientAPI.AuthKey,txtStyle);
				EditorGUIUtility.labelWidth = 200;
				skipLogin = EditorGUILayout.Toggle("  Skip Login", skipLogin);
				EditorGUIUtility.labelWidth = 0;
			}
			EditorGUIUtility.labelWidth = 200;
			EditorGUIUtility.labelWidth = 0;
			if (GUILayout.Button ("Save Configuration"))
			{
				SaveConfig ();
			}
			GUI.enabled = true;	
			EditorGUILayout.Space();
			GUILayout.Box ("", new GUILayoutOption[]{GUILayout.ExpandWidth (true), GUILayout.Height (1)});
			EditorGUILayout.Space();
			if (GUILayout.Button ("WebAPI Docs", GUILayout.Width(200)))
			{
				OpenWebApiDocs ();
			}
			if (GUILayout.Button ("Getting Started Guide", GUILayout.Width(200)))
			{
				OpenGettingStarted ();
			}
			GUI.enabled = true;	
		}
		
		private void SaveConfig ()
		{
			PlayFabData.TitleId = titleId;
			PlayFabData.CatalogVersion = catalogVersion;
			PlayFabData.KeepSessionKey = keepSessionKey;
			PlayFabData.SkipLogin = skipLogin;
			PlayFabData.SaveData ();
            AssetDatabase.Refresh ();
		}

		private void OpenWebApiDocs() {
			Application.OpenURL("http://api.playfab.com/documentation");
		}
		private void OpenGettingStarted() {
			Application.OpenURL("http://developer.playfab.com/gettingstarted.html");
		}
		private void OpenDashboard() {
			Application.OpenURL("https://developer.playfab.com/");
		}
	}
}