using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	// prefabs and other variables assigned via drag-and-drop in the inspector
	public GameObject ballPrefab;
	public GameObject cubePrefab;
	public GUISkin myGameplaySkin;

	// global variables so we remember them scene-to-scene
	public static int gameLength;
	public static int speed;

	// private variables
	private int coloredBalls;
	private Ball[] cubes; // the ball object
	private int numCubes = 20;
	private AudioController myAudioController;
	private int edgeBuffer = 40;


	// Use this for initialization
	void Start () {
		// TODO: Add UI to modify these from the StartScreen and EndScreen scenes. For now, just hard code it here.
		GameController.gameLength = numCubes; // number of touches until victory
		GameController.speed = 150; // speed of movement in units per second

		// the Find() method can be slow, so we do it just once at start.
		// We need a reference to the AudioController script so we can tell it to play sounds.
		//myAudioController = GameObject.Find("AudioObject").GetComponent<AudioController>();

		// number of balls touched so far
		coloredBalls = 0;

		// start in a random position, going either left/right or up/down. size 20, half of size
		cubes = new Ball[numCubes];
		for (int i = 0; i < numCubes; i++) {
			cubes [i] = new Ball (cubePrefab, Color.red, Random.Range(-Screen.width/2+edgeBuffer, Screen.width/2-edgeBuffer), Random.Range(-Screen.height/2+edgeBuffer, Screen.height/2-edgeBuffer), Random.Range(0,2)*2-1, Random.Range(0,2)*2-1, 20);
		}
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
		for (int i = 0; i < numCubes; i++) {
			cubes [i].Move ();
		}

	}
}
