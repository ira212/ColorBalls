using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenController : MonoBehaviour {
	public GUISkin mySkin;

	// Use this for initialization
	void Start () {
		// number of characters until victory
		GameController.gameLength = 2;

		// speed of movement in units per second
		GameController.speed = 200;

	}

	void OnGUI () {
		GUI.skin = mySkin;

		// Instructions
		// should be centered, based on the screen 
		GUI.Label(new Rect(Screen.width/2-100,100,200,200), "Make Red!");
		
		// Start game button
		if(GUI.Button(new Rect(Screen.width/2-75,Screen.height/2+50,150,80), "Play")) {
			SceneManager.LoadScene (1);
		}
		
	}
}