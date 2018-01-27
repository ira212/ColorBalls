using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {
	private GameController myGameController;
	public Ball myBall;

	// Use this for initialization
	void Start () {
		Debug.Log ("Start() for BallBehavior");
		// the Find() method can be slow, so we do it just once at start
		myGameController = GameObject.Find("GameControllerObject").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown () {
		Debug.Log ("In OnMouseDown()");
		this.GetComponent<Renderer> ().material.color = myBall.GetColor ();
		myGameController.ProcessTouch();
	}
}
