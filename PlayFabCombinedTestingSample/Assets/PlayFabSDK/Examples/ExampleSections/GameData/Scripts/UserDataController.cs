using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Events;

using PlayFab.ClientModels;

public class UserDataController : MonoBehaviour {
	
	public enum UserDataStates { ReadWrite, ReadOnly, Publisher, Internal }
	public UserDataStates CurrentState = UserDataStates.ReadWrite;
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
