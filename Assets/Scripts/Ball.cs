using UnityEngine;
using System.Collections;


public class Ball {
	public GameObject ballObj;
	public bool pending;
	private int dirX, dirY, size, sizeBuffer, mySpeed;
	private Color color;

	public Ball (GameObject ballPrefab, Color myColor, int posX, int posY, int directionX, int directionY, int s) {
		// create the tile prefab
		ballObj = (GameObject) Object.Instantiate(ballPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
		ballObj.GetComponent<BallBehavior> ().myBall = this;
		dirX = directionX;
		dirY = directionY;
		size = s;
		color = myColor;

		mySpeed = Random.Range(GameController.minSpeed, GameController.maxSpeed);

		// I'm not sure why we need this, but the letter seems to take up less space than the actual size, so this is some extra size for proper bouncing.
		// There's probably a way to change the way the letter prefab is setup to avoid this entirely, but I didn't have time to figure it out.
		sizeBuffer = 0;
	}

	public Color GetColor () {
		return color;
	}

	public void Move () {
		// move the object based on it's direction and speed
		ballObj.transform.Translate(new Vector3(mySpeed * dirX, mySpeed * dirY, 0) * Time.deltaTime);

		// the object went off the left or right edge
		// swap the x direction so it bounces, and constrain it to the board
		if (ballObj.transform.position.x <= Screen.width/-2 + size + sizeBuffer) {
			dirX *= -1;
			ballObj.transform.position = new Vector3 (Screen.width /-2 + size + sizeBuffer, ballObj.transform.position.y, ballObj.transform.position.z);
		}
		if (ballObj.transform.position.x >= Screen.width / 2 - size - sizeBuffer) {
			dirX *= -1;
			ballObj.transform.position = new Vector3 (Screen.width / 2 - size - sizeBuffer, ballObj.transform.position.y, ballObj.transform.position.z);
		}

		// went off the top or bottom edge
		// swap the y direction so it bounces, and constrain it to the board
		if (ballObj.transform.position.y <= Screen.height/-2 + size + sizeBuffer) {
			dirY *= -1;
			ballObj.transform.position = new Vector3 (ballObj.transform.position.x, Screen.height /-2 + size + sizeBuffer, ballObj.transform.position.z);
		}
		if (ballObj.transform.position.y >= Screen.height / 2 - size - sizeBuffer) {
			dirY *= -1;
			ballObj.transform.position = new Vector3 (ballObj.transform.position.x, Screen.height / 2 - size - sizeBuffer, ballObj.transform.position.z);
		}
	}

	public void SetBig (bool big) {
		if (big) {
			ballObj.transform.localScale = new Vector3(3, 3, 1);

			// center it, offset from the center by its size.
			ballObj.transform.position = new Vector3(size * -1.5f, size * 1.5f, 0);
		}

		// small
		else {
			// reset scale
			ballObj.transform.localScale = new Vector3(1, 1, 1);

			// choose random location
			int randX = Random.Range(Screen.width/-2 + sizeBuffer, Screen.width/2 - size - sizeBuffer);
			int randY = Random.Range(Screen.height/-2 + size + sizeBuffer, Screen.height/2 - sizeBuffer);
			ballObj.transform.position = new Vector3(randX, randY, 0);
		}

	}

}
