using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;

namespace PlayFab.Examples{
	public class PlayFabLoginUser : MonoBehaviour{

		public string title = "User Login";
		public string userNameLabel = "User Name";
		public string passwordLabel = "Password";
		public string nextScene = "PF_PurchaseScene";
		public string previousScene = "PF_UserRegisterScene";
		public Texture2D playfabBackground;

		private string passwordValidLabel = "";
		private string errorStackLabel = "";
		private string userNameField = "";
		private string passwordField = "";
		private GUIStyle passwordValidLabelStyle = new GUIStyle();
		private float yStart;
		private bool isPassword = true;

		private void Start (){
			passwordValidLabelStyle.normal.textColor = Color.red;
		}

		void OnGUI () {
			if (PlayFabGameBridge.gameState == 2) {
				Rect winRect = new Rect (0,0,playfabBackground.width, playfabBackground.height);
				winRect.x = (int) ( Screen.width * 0.5f - winRect.width * 0.5f );
				winRect.y = (int) ( Screen.height * 0.5f - winRect.height * 0.5f );
				yStart = winRect.y + 80;
				GUI.DrawTexture (winRect, playfabBackground);

				passwordValidLabel = isPassword ? "" : "Password is not valid";

				GUI.Label (new Rect (winRect.x + 18, yStart -16, 120, 30), "<size=18>"+title+"</size>");
				GUI.Label (new Rect (winRect.x + 18, yStart+25, 120, 20), userNameLabel);
				GUI.Label (new Rect (winRect.x + 18, yStart+50, 120, 20), passwordLabel);
				GUI.Label (new Rect (winRect.x + 18, yStart+73, 120, 20), passwordValidLabel, passwordValidLabelStyle);
				GUI.Label (new Rect (winRect.x +18, yStart +145, 120, 20), "OR");
						
				userNameField = GUI.TextField (new Rect (winRect.x+130, yStart+25, 100, 20), userNameField);
				passwordField = GUI.PasswordField  (new Rect (winRect.x+130, yStart+50, 100, 20), passwordField,"*"[0], 20);

				if(errorStackLabel.Length>0)errorStackLabel = GUI.TextArea (new Rect (winRect.x+125, yStart+125, 200, 100), errorStackLabel, 200);

				if (GUI.Button (new Rect (winRect.x+18, yStart+100, 100, 30), "Login")||Event.current.Equals(Event.KeyboardEvent("[enter]"))) {
					if(userNameField.Length>0 && passwordField.Length>0)
					{
						LoginWithPlayFabRequest request = new LoginWithPlayFabRequest();
						request.Username = userNameField;
						request.Password = passwordField;
						request.TitleId = PlayFabData.TitleId;
						PlayFabClientAPI.LoginWithPlayFab(request,OnLoginResult,OnPlayFabError);
					}
					else
					{
						isPassword = false;
					}
				}

				if (GUI.Button(new Rect(winRect.x+18, yStart+175, 120, 20),"Register"))
				{
					PlayFabGameBridge.gameState = 1;
					if(!PlayFabData.AngryBotsModActivated)Application.LoadLevel (previousScene);
				}
			}
		}
		public void OnLoginResult(LoginResult result){
			errorStackLabel ="";
			PlayFabGameBridge.gameState = 3;
			if(PlayFabData.AngryBotsModActivated)Application.LoadLevel ("Default");
			else Application.LoadLevel (nextScene);

		}
		void OnPlayFabError(PlayFabError error)
		{
			Debug.Log ("Got an error: " + error.ErrorMessage);
		}




	}
}