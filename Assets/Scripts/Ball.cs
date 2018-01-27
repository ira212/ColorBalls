using UnityEngine;
using System.Collections;


public class Ball {
	private GameObject ballObj;
	private int dirX, dirY, size, sizeBuffer;
	private Color color;

	public Ball (GameObject ballPrefab, Color myColor, int posX, int posY, int directionX, int directionY, int s) {
		// create the tile prefab
		ballObj = (GameObject) Object.Instantiate(ballPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
		ballObj.GetComponent<BallBehavior> ().myBall = this;
		dirX = directionX;
		dirY = directionY;
		size = s;
		color = myColor;

		// I'm not sure why we need this, but the letter seems to take up less space than the actual size, so this is some extra size for proper bouncing.
		// There's probably a way to change the way the letter prefab is setup to avoid this entirely, but I didn't have time to figure it out.
		sizeBuffer = 0;

		Debug.Log ("Screen width: " + Screen.width + "   Screen height: " + Screen.height);
	}

	public Color GetColor () {
		return color;
	}

	public void Move () {
		// move the letter based on it's direction and speed
		ballObj.transform.Translate(new Vector3(GameController.speed * dirX, GameController.speed * dirY, 0) * Time.deltaTime);

		// the letter went off the left or right edge
		if (ballObj.transform.position.x <= Screen.width/-2 + sizeBuffer || ballObj.transform.position.x >= Screen.width/2 - size - sizeBuffer) {
			// swap the x direction so it bounces
			dirX *= -1;
		}

		// went off the top or bottom edge
		if (ballObj.transform.position.y <= Screen.height/-2 + size + sizeBuffer || ballObj.transform.position.y >= Screen.height/2 - sizeBuffer) {
			// swap the y direction so it bounces
			dirY *= -1;
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
