using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {
	private GameController myGameController;
	public Ball myBall;
	public bool touched = false;

	// Use this for initialization
	void Start () {
		// the Find() method can be slow, so we do it just once at start
		myGameController = GameObject.Find("GameControllerObject").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown () {
		if (!touched) {
			touched = true;
			// new touch!
			myGameController.ProcessTouch (true, gameObject);
		}
		else {
			myGameController.ProcessTouch (false, gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		myGameController.ProcessCollision (gameObject, col.gameObject);
	}
}
