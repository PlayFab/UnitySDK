using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

using PlayFab.Internal;

namespace PlayFab{
	public class PlayFabData : SingletonMonoBehaviour<PlayFabData> {

		// Currently used to store Playfab config value from Editor

		public static string TitleId { get; set; }
		public static string CatalogVersion { get; set; }

		private static string _AuthKey;
		public static string AuthKey {  
			get { return _AuthKey; }
			set
			{
				_AuthKey = value;
				if (LoggedIn != null) LoggedIn(value);
			} 
		}
		public static event LoggedInEventHandler LoggedIn;

		public static bool KeepSessionKey { get; set; }
		public static bool SkipLogin { get; set; }

		/// 		SAVE % LOAD GAME DATA

		void Awake() {
			PlayFabData.LoadData ();
		}
		void OnApplicationQuit () {
			PlayFabData.SaveData ();
		}

		public static void LoadData(){
			PlayFabData.instance.LD();
		}

		private void LD(){
			StartCoroutine(LoadDataRoutine());
		}
		
		public IEnumerator LoadDataRoutine ()
		{
			string filePath = "";
			if (Application.platform == RuntimePlatform.Android)
				filePath = "jar:file://" + Application.dataPath + "!/assets"; 
			else if(Application.platform == RuntimePlatform.IPhonePlayer)
				filePath = Application.dataPath + "/Raw";
			else 
				filePath = Application.dataPath + "/StreamingAssets";
			filePath += "/playfab.data";
			FileStream file = null;
			BinaryFormatter bf = new BinaryFormatter ();
			PlayfabGameData data = null;
			if (Application.platform == RuntimePlatform.Android | Application.platform == RuntimePlatform.WindowsWebPlayer| Application.platform == RuntimePlatform.OSXWebPlayer) {
				WWW www = new WWW(filePath);
				yield return www;
				using(MemoryStream ms = new MemoryStream(www.bytes))
				{
					data = (PlayfabGameData)bf.Deserialize ( ms);
				}
			}else{
				file = File.Open (Application.streamingAssetsPath  + "/playfab.data", FileMode.Open, FileAccess.Read, FileShare.None);
				data = (PlayfabGameData)bf.Deserialize (file);
				file.Close ();
			}
			TitleId = data.TitleId;
			if (PlayFabSettings.TitleId == null)
								PlayFabSettings.TitleId = TitleId;
			CatalogVersion = data.CatalogVersion;
			KeepSessionKey = data.KeepSessionKey;
			SkipLogin = data.SkipLogin;

			if (KeepSessionKey && PlayFabClientAPI.AuthKey == null && data.AuthKey != null) {
				PlayFabClientAPI.AuthKey = AuthKey = data.AuthKey;
				Debug.Log ("Retrieved auth key: " + AuthKey);
			}
			else if(KeepSessionKey && PlayFabClientAPI.AuthKey!=null &&  data.AuthKey==null)
				SaveData();
		}
		
		public static void SaveData ()
		{

			string folderPath = Path.GetDirectoryName (Application.streamingAssetsPath  +"/playfab.data");
			if (!Directory.Exists (folderPath))
			{
				Directory.CreateDirectory (folderPath);
			}
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create(Application.streamingAssetsPath  +"/playfab.data");
			
			PlayfabGameData data = new PlayfabGameData ();
			data.TitleId = TitleId;
			data.CatalogVersion = CatalogVersion;
			data.KeepSessionKey = KeepSessionKey;
			data.SkipLogin = SkipLogin;
			if (KeepSessionKey && PlayFabClientAPI.AuthKey != null)
				data.AuthKey = AuthKey = PlayFabClientAPI.AuthKey;
			bf.Serialize (file,data);
			file.Close ();
		}
	}
}

public delegate void LoggedInEventHandler(string value);

[Serializable]
public class PlayfabGameData 
{
	public string TitleId;
	public string CatalogVersion;
	public bool KeepSessionKey;
	public bool SkipLogin;
	public string AuthKey;
}
