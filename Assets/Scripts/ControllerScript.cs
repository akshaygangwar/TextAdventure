﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControllerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClickStart(){
		Application.LoadLevel("MainScreen");
	}
}
