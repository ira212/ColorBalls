using UnityEngine;
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
		if (GameController.gameLength == 1) {
			summaryMessage = "You colored 1 ball!";
		}
		// the game was of some length other than 1
		{
			summaryMessage = "You colored " +GameController.gameLength+ " balls!";
		}
	}
	
	void OnGUI () {
		GUI.skin = mySkin;

		// should be centered, based on the screen 
		GUI.Label(new Rect(Screen.width/2-100,150,200,200), message);
		
		// Start game button
		if(GUI.Button(new Rect(Screen.width/2-200,290,400,120), "Play Again")) {
			SceneManager.LoadScene(1);
		}

		GUI.Label(new Rect(Screen.width/2-100,500,200,200), summaryMessage);
	
	}
}