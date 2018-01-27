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
	public static int minSpeed;
	public static int maxSpeed;
	public static int colored;
	public static float gameLength;

	// private variables
	private Ball[] cubes; // the ball object
	private int numCubes = 20;
	private AudioController myAudioController;
	private int edgeBuffer = 40;
	private float endGameTime;



	// Use this for initialization
	void Start () {
		// TODO: Add UI to modify these from the StartScreen and EndScreen scenes. For now, just hard code it here.
		GameController.gameLength = 20; // number of seconds
		GameController.minSpeed = 15; // speed of movement in units per second
		GameController.maxSpeed = 200; // speed of movement in units per second
		endGameTime = Time.time + gameLength;

		// the Find() method can be slow, so we do it just once at start.
		// We need a reference to the AudioController script so we can tell it to play sounds.
		//myAudioController = GameObject.Find("AudioObject").GetComponent<AudioController>();

		// number of balls touched so far
		colored = 0;

		// start in a random position, going either left/right or up/down. half of size
		cubes = new Ball[numCubes];
		for (int i = 0; i < numCubes; i++) {
			cubes [i] = new Ball (cubePrefab, Color.red, Random.Range(-Screen.width/2+edgeBuffer, Screen.width/2-edgeBuffer), Random.Range(-Screen.height/2+edgeBuffer, Screen.height/2-edgeBuffer), Random.Range(0,2)*2-1, Random.Range(0,2)*2-1, 40);
		}
	}

	public void ProcessTouch (bool newTouch, GameObject myCube) {
		// increment the colored ball count
		if (newTouch) {
			colored++;
		}

		if (myCube.transform.position.x > 0) {
			myCube.GetComponent<Renderer> ().material.color = Color.red;
		}
		else {
			myCube.GetComponent<Renderer> ().material.color = Color.blue;
		}

	}

	public void ProcessCollision (GameObject cube1, GameObject cube2) {
		if (cube1.GetComponent<BallBehavior> ().myBall.pending || cube2.GetComponent<BallBehavior> ().myBall.pending) {
			if ((cube1.GetComponent<Renderer> ().material.color == Color.red && cube2.GetComponent<Renderer> ().material.color == Color.blue) ||
				(cube1.GetComponent<Renderer> ().material.color == Color.blue && cube2.GetComponent<Renderer> ().material.color == Color.red)) {
				cube1.GetComponent<Renderer> ().material.color = new Color (.7f, 0, .7f);
				cube2.GetComponent<Renderer> ().material.color = new Color (.7f, 0, .7f);
				cube1.GetComponent<BallBehavior> ().myBall.pending = false;
				cube2.GetComponent<BallBehavior> ().myBall.pending = false;
			}
				
			if (cube1.GetComponent<Renderer> ().material.color == Color.white) {
				if (cube2.GetComponent<Renderer> ().material.color != Color.white) {
					cube1.GetComponent<Renderer> ().material.color = cube2.GetComponent<Renderer> ().material.color;
					colored++;
					cube1.GetComponent<BallBehavior> ().myBall.pending = false;
					cube1.GetComponent<BallBehavior> ().touched = true;
					cube2.GetComponent<BallBehavior> ().myBall.pending = false;
				}
			}

			if (cube2.GetComponent<Renderer> ().material.color == Color.white) {
				if (cube1.GetComponent<Renderer> ().material.color != Color.white) {
					cube2.GetComponent<Renderer> ().material.color = cube1.GetComponent<Renderer> ().material.color;
					colored++;
					cube1.GetComponent<BallBehavior> ().myBall.pending = false;
					cube2.GetComponent<BallBehavior> ().myBall.pending = false;
					cube2.GetComponent<BallBehavior> ().touched = true;
				}
			}

		}
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < numCubes; i++) {
			cubes [i].Move ();
		}

		// go to game summary if needed
		if (Time.time > endGameTime) {
			// go to summary screen
			SceneManager.LoadScene(2);
		}

	}

	void LateUpdate () {
		for (int i = 0; i < numCubes; i++) {
			cubes [i].pending = true;
		}


	}
}
