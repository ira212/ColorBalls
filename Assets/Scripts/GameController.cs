using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	// prefabs and other variables assigned via drag-and-drop in the inspector
	public GameObject ballPrefab;
	public GUISkin myGameplaySkin;

	// global variables so we remember them scene-to-scene
	public static int gameLength;
	public static int speed;

	// private variables
	private int coloredBalls;
	private Ball ball; // the ball object
	private AudioController myAudioController;


	// Use this for initialization
	void Start () {
		// TODO: Add UI to modify these from the StartScreen and EndScreen scenes. For now, just hard code it here.
		GameController.gameLength = 2; // number of touches until victory
		GameController.speed = 200; // speed of movement in units per second

		// the Find() method can be slow, so we do it just once at start.
		// We need a reference to the AudioController script so we can tell it to play sounds.
		myAudioController = GameObject.Find("AudioObject").GetComponent<AudioController>();

		// number of balls touched so far
		coloredBalls = 0;

		// start the first letter in the middle of the screen (0,0), going up and to the right (1,1), at size 10
		ball = new Ball(ballPrefab, Color.red, 0, 0, 1, 1, 10);
	}

	public void ProcessTouch () {
		// increment the colored ball count, and go to game summary if needed
		if (++coloredBalls == gameLength) {
			// go to summary screen
			SceneManager.LoadScene(2);
		}

	}

	// Update is called once per frame
	void Update () {
		// move the letter around the screen
		ball.Move();
	}
}
