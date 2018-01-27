using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {
	private GameController myGameController;

	// Use this for initialization
	void Start () {
		// the Find() method can be slow, so we do it just once at start
		myGameController = GameObject.Find("GameControllerObject").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown () {
		myGameController.ProcessTouch();
	}
}
