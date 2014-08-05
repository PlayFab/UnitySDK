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
		private bool angryBotsModActivated;
		private Texture2D[] sprites;
		private List<GameObject> prefabFiles = new List<GameObject>() ;
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
			angryBotsModActivated = PlayFabData.AngryBotsModActivated;
			ListFiles();
			pfLogo = (Texture2D)Resources.LoadAssetAtPath ("Assets/Playfab/Editor/PlayFablogo.png", typeof(Texture2D));
			hideFlags = HideFlags.HideAndDontSave;
			txtStyle.normal.textColor = Color.red;
			
		}

        public void OnGUI ()
        {
			GUILayout.Label(pfLogo);
			titleId    = EditorGUILayout.TextField ("Title Id", titleId);
			catalogVersion    = EditorGUILayout.TextField ("Catalog Version", catalogVersion);
			EditorGUIUtility.labelWidth = 200;
			keepSessionKey = EditorGUILayout.Toggle("Keep session key", keepSessionKey);
			EditorGUIUtility.labelWidth = 0;
			if(keepSessionKey)EditorGUILayout.LabelField ("Current authKey : "+PlayFabClientAPI.AuthKey,txtStyle);
			EditorGUIUtility.labelWidth = 200;
			angryBotsModActivated = EditorGUILayout.Toggle("AngryBots Demo Activated", angryBotsModActivated);
			EditorGUIUtility.labelWidth = 0;
			if (GUILayout.Button ("Save"))
			{
				SaveConfig ();
			}
			GUI.enabled = true;	
		
			GUILayout.Box ("", new GUILayoutOption[]{GUILayout.ExpandWidth (true), GUILayout.Height (1)});

			EditorGUILayout.LabelField ("Prefabs");
			EditorGUIUtility.labelWidth = 100;
			Vector2 scrollPosition  = new Vector2(0,200);
			scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
			foreach( GameObject pf in prefabFiles )
			{
				GUILayout.BeginHorizontal("box");

				EditorGUILayout.ObjectField( pf.name, pf, typeof( GameObject ),false );
				if (GUILayout.Button ("Add prefab"))
				{
					CreateSimplePrefab (pf);
				}
				GUILayout.EndHorizontal();
			} 
			EditorGUILayout.EndScrollView();
			EditorGUIUtility.labelWidth = 0;
		}
		
		private void SaveConfig ()
		{
			PlayFabData.TitleId = titleId;
			PlayFabData.CatalogVersion = catalogVersion;
			PlayFabData.KeepSessionKey = keepSessionKey;
			PlayFabData.AngryBotsModActivated = angryBotsModActivated;
			PlayFabData.SaveData ();
            AssetDatabase.Refresh ();
		}

		private void CreateSimplePrefab(GameObject tempGameObject )
		{
			var clone = Instantiate(tempGameObject) as GameObject;
			clone.name = tempGameObject.name;

		}

		/// <summary>
		/// Lists Prefabs files.
		/// </summary>

		private void ListFiles(){
			DirectoryInfo info = new DirectoryInfo(@"./Assets/PlayFab/Prefabs/");
			FileInfo[] fileInfo = info.GetFiles();
			foreach  (FileInfo file in fileInfo) {
				if(file.Extension==".prefab"){
					GameObject tempGameObject = (GameObject)Resources.LoadAssetAtPath ("Assets/Playfab/Prefabs/"+file.Name,typeof(GameObject) );
					prefabFiles.Add(tempGameObject);
				}
			}
		}
	}
}