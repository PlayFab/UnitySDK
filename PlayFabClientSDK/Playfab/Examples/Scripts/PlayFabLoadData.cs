using UnityEngine;
using PlayFab;
namespace PlayFab.Examples
{
	public class PlayFabLoadData : MonoBehaviour {
		// Simple script to load the PlayFabDataFile. 
		// ie : Usualy put on the first scene to have everything ready upon initiation.
		void Awake () {
			PlayFabData.LoadData ();
		}
	}
}
