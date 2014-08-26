using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using PlayFab;
using PlayFab.ClientModels;

namespace PlayFab.Examples{
	public class PlayFabNews : MonoBehaviour {

		public Texture2D newsButton,newsBackground,close,cursor;
		public string newsToLoad;
		public int iconSpace;
		public int textSpace;
		public int dateFontSize;
		public int titleFontSize;
		public int contentFontSize;

		private List<TitleNewsItem> news;
		private bool newsLoaded = false;
		private bool showNews = false;
		private bool drawCursor;

		// Use this for initialization
		void Start () {
			GetTitleNewsRequest request = new GetTitleNewsRequest ();
			request.Count = Convert.ToInt32(newsToLoad);
			if (PlayFabData.AuthKey != null)
				PlayFabClientAPI.GetTitleNews (request, OnNewsResult, OnPlayFabError);
		}	

		private void OnNewsResult(GetTitleNewsResult result){
			news = result.News;
			newsLoaded = true;

			// as soon as the news gets loaded, show it -- as long as we're done logging in and registering the user
			if (PlayFabGameBridge.gameState == 3) {
				showNews = true;
			}
		}
		
		private void OnPlayFabError(PlayFabError error)
		{
			Debug.Log ("Got an error: " + error.ErrorMessage);
		}

		// Update is called once per frame
		void OnGUI () {
			if (newsLoaded) {
				Rect newsIconRect = new Rect (Screen.width-iconSpace -newsButton.width,0+iconSpace,newsButton.width,newsButton.height );
				if (GUI.Button (newsIconRect, newsButton,GUIStyle.none)) {
					showNews = !showNews;
					Time.timeScale = !showNews ? 1.0f : 0.0f;
				};
				drawCursor = false;
				if (Input.mousePosition.x < newsIconRect.x + newsIconRect.width && Input.mousePosition.x > newsIconRect.x && Screen.height - Input.mousePosition.y < newsIconRect.y + newsIconRect.height && Screen.height - Input.mousePosition.y > newsIconRect.y)
					drawCursor = true;
				Rect winRect = new Rect (Screen.width * 0.5f - newsBackground.width *0.5f,100,newsBackground.width,newsBackground.height );
				if (showNews) {
					Time.timeScale = 0.0f;
					GUI.DrawTexture (winRect, newsBackground);
					Rect closeRect = new Rect (winRect.x+newsBackground.width-close.width,winRect.y,close.width,close.height );
					if (GUI.Button (closeRect, close,GUIStyle.none)) {
						showNews = false;
						Time.timeScale = !showNews ? 1.0f : 0.0f;
					};
					GUI.skin.label.alignment = TextAnchor.UpperLeft;
					Rect prevRect = new Rect();
					prevRect.y = winRect.y+50;
					prevRect.x = winRect.x+10;
					for(int i = 0; i < news.Count;  i++)	{
						Rect labelRect = GUILayoutUtility.GetRect(new GUIContent("<size="+dateFontSize+">Published on : "+news[i].Timestamp+"</size>"), "label");
						labelRect.y = prevRect.y;
						labelRect.x = prevRect.x;
						GUI.Label (labelRect, "<size="+dateFontSize+">Published on : "+news[i].Timestamp+"</size>");

						labelRect.y += labelRect.height+textSpace;
						prevRect = labelRect;
						labelRect = GUILayoutUtility.GetRect(new GUIContent("<size="+titleFontSize+">"+news[i].Title+"</size>"), "label", GUILayout.MaxWidth(newsBackground.width-10));
						labelRect.y = prevRect.y;
						labelRect.x = prevRect.x;
						GUI.Label (labelRect, "<size="+titleFontSize+">"+news[i].Title+"</size>");

						labelRect.y += labelRect.height+textSpace;
						prevRect = labelRect;
						labelRect = GUILayoutUtility.GetRect(new GUIContent("<size="+contentFontSize+">"+news[i].Body+"</size>"), "label", GUILayout.MaxWidth(newsBackground.width-10));
						labelRect.y = prevRect.y;
						labelRect.x = prevRect.x;
						GUI.Label (labelRect, "<size="+contentFontSize+">"+news[i].Body+"</size>");

						labelRect.y += labelRect.height+textSpace;
						prevRect = labelRect;
						prevRect.y += textSpace*2;
					}
					if (Input.mousePosition.x < winRect.x + winRect.width && Input.mousePosition.x > winRect.x && Screen.height - Input.mousePosition.y < winRect.y + winRect.height && Screen.height - Input.mousePosition.y > winRect.y)
						drawCursor = true;
				}
				if (drawCursor) {
					Rect cursorRect = new Rect (Input.mousePosition.x,Screen.height-Input.mousePosition.y,cursor.width,cursor.height );
					GUI.DrawTexture (cursorRect, cursor);
					PlayFabGameBridge.mouseOverGui = true;
				}
			}
		}
	}
}
