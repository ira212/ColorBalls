﻿using UnityEngine;
using UnityEngine.SceneManagement;
//using System.Collections;
//using System.Collections.Generic;

public class EndScreenController : MonoBehaviour {
	public GUISkin mySkin;
	private string message;
	private string summaryMessage;
	
	// Use this for initialization
	void Start () {
		message = "Good job, Sam and Sara!";

		// ensure we get singular/plural correct for 1 letter
		if (GameController.colored == 1) {
			summaryMessage = "You colored 1 cube!";
		}
		// the game was of some length other than 1
		{
			summaryMessage = "You colored " +GameController.colored+ " cubes!";
		}
	}
	
	void OnGUI () {
		GUI.skin = mySkin;

		// should be centered, based on the screen 
		GUI.Label(new Rect(Screen.width/2-100,150,200,200), message);
		
		// Start game button
		if(GUI.Button(new Rect(Screen.width/2-300,290,600,150), "Play Again")) {
			SceneManager.LoadScene(1);
		}

		GUI.Label(new Rect(Screen.width/2-100,500,200,200), summaryMessage);
	
	}
}