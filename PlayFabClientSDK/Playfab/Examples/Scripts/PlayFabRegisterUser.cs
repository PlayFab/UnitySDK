using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PlayFab;
using PlayFab.ClientModels;

namespace PlayFab.Examples{
	public class PlayFabRegisterUser : MonoBehaviour{

		public string title = "Register User";
		public string userNameLabel = "User Name";
		public string emailLabel = "Email";
		public string passwordLabel = "Password";
		public string confirmPasswordLabel = "Confirm Password";
		public string nextScene = "PF_UserLoginScene";
		public string confirmScene = "PF_PurchaseScene";
		public Texture2D playfabBackground;

		private string emailValidLabel = "";
		private string passwordValidLabel = "";
		private string errorStackLabel = "";
		private string userNameField = "";
		private string emailField = "";
		private string passwordField = "";
		private string confirmPasswordField = "";
		private GUIStyle emailValidLabelStyle = new GUIStyle();
		private GUIStyle passwordValidLabelStyle = new GUIStyle();
		private float yStart;
		private bool isEmail = true;
		private bool isPassword = true;

		private void Start (){
			PlayFabData.LoadData ();
			emailValidLabelStyle.normal.textColor = Color.red;
			passwordValidLabelStyle.normal.textColor = Color.red;
		}

		void OnGUI () {
			if (PlayFabGameBridge.gameState == 1) {
				Rect winRect = new Rect (0,0,playfabBackground.width, playfabBackground.height);
				winRect.x = (int) ( Screen.width * 0.5f - winRect.width * 0.5f );
				winRect.y = (int) ( Screen.height * 0.5f - winRect.height * 0.5f );
				yStart = winRect.y + 80;
				GUI.DrawTexture (winRect, playfabBackground);
				
				emailValidLabel = isEmail ? "" : "Invalid email";
				passwordValidLabel = isPassword ? "" : "Password doesnt match";

				GUI.Label (new Rect (winRect.x + 18, yStart -16, 120, 30), "<size=18>"+title+"</size>");
				GUI.Label (new Rect (winRect.x + 18, yStart +25, 120, 20), userNameLabel);
				GUI.Label (new Rect (winRect.x +18, yStart +50, 120, 20), emailLabel);
				GUI.Label (new Rect (winRect.x +18, yStart +128, 120, 20), emailValidLabel, emailValidLabelStyle);
				GUI.Label (new Rect (winRect.x +18, yStart +75, 120, 20), passwordLabel);
				GUI.Label (new Rect (winRect.x +18, yStart +100, 120, 20), confirmPasswordLabel);
				if(isEmail)GUI.Label (new Rect (winRect.x +18, yStart +128, 120, 20), passwordValidLabel, passwordValidLabelStyle);
				GUI.Label (new Rect (winRect.x +18, yStart +200, 120, 20), "OR");
				
				userNameField = GUI.TextField (new Rect (winRect.x +135, yStart+25, 100, 20), userNameField);
				emailField = GUI.TextField (new Rect (winRect.x +135, yStart +50, 100, 20), emailField);
				passwordField = GUI.PasswordField  (new Rect (winRect.x +135, yStart +75, 100, 20), passwordField,"*"[0], 20);
				confirmPasswordField = GUI.PasswordField  (new Rect (winRect.x +135, yStart+100, 100, 20), confirmPasswordField,"*"[0], 20);
				
				if(errorStackLabel.Length>0)errorStackLabel = GUI.TextArea (new Rect (winRect.x +125, yStart+135, 200, 100), errorStackLabel, 200);		
				if(confirmPasswordField.Length>0)validatePassword ();
				
				if (GUI.Button (new Rect (winRect.x +18, yStart+155, 100, 30), "Register")||Event.current.Equals(Event.KeyboardEvent("[enter]"))) {
					validateEmail();
					validatePassword();
					if(isEmail && isPassword)
					{
						RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest();
						request.TitleId = PlayFabData.TitleId;
						request.Username = userNameField;
						request.Email = emailField;
						request.Password = passwordField;
						Debug.Log("TitleId : "+request.TitleId);
						PlayFabClientAPI.RegisterPlayFabUser(request,OnRegisterResult,OnPlayFabError);
					}	
				}
				
				if (GUI.Button(new Rect(winRect.x +18,yStart +235, 80, 20),"Log In"))
				{
					PlayFabGameBridge.gameState = 2;
					if(!PlayFabData.AngryBotsModActivated)Application.LoadLevel (nextScene);
				}
			}
		}

		// meet all requirments of RFCs 5321 & 5322
		const string pattern = @"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$";
		private void validateEmail(){
			isEmail = Regex.IsMatch(emailField, pattern);
		}

		private void validatePassword(){
			isPassword = ((passwordField == confirmPasswordField)&& emailField.Length>0); 
		}

		public void OnRegisterResult(RegisterPlayFabUserResult result){
			PlayFabGameBridge.gameState = 3;
			if(PlayFabData.AngryBotsModActivated)Application.LoadLevel ("Default");
			else Application.LoadLevel (confirmScene);
		}
		void OnPlayFabError(PlayFabError error)
		{
			Debug.Log ("Got an error: " + error.ErrorMessage);
		}
	}
}