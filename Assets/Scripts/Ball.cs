using UnityEngine;
using System.Collections;


public class Ball {
	private GameObject ball;
	private int dirX, dirY, size, sizeBuffer;
	private Color color;

	public Ball (GameObject ballPrefab, Color myColor, int posX, int posY, int directionX, int directionY, int s) {
		// create the tile prefab
		ball = (GameObject) Object.Instantiate(ballPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
		dirX = directionX;
		dirY = directionY;
		size = s;
		color = myColor;

		// I'm not sure why we need this, but the letter seems to take up less space than the actual size, so this is some extra size for proper bouncing.
		// There's probably a way to change the way the letter prefab is setup to avoid this entirely, but I didn't have time to figure it out.
		sizeBuffer = 0;

		Debug.Log ("Screen width: " + Screen.width + "   Screen height: " + Screen.height);
	}

	public void Move () {
		// move the letter based on it's direction and speed
		ball.transform.Translate(new Vector3(GameController.speed * dirX, GameController.speed * dirY, 0) * Time.deltaTime);

		// the letter went off the left or right edge
		if (ball.transform.position.x <= Screen.width/-2 + sizeBuffer || ball.transform.position.x >= Screen.width/2 - size - sizeBuffer) {
			// swap the x direction so it bounces
			dirX *= -1;
		}

		// went off the top or bottom edge
		if (ball.transform.position.y <= Screen.height/-2 + size + sizeBuffer || ball.transform.position.y >= Screen.height/2 - sizeBuffer) {
			// swap the y direction so it bounces
			dirY *= -1;
		}
	}

	public void SetBig (bool big) {
		if (big) {
			ball.transform.localScale = new Vector3(3, 3, 1);

			// center it, offset from the center by its size.
			ball.transform.position = new Vector3(size * -1.5f, size * 1.5f, 0);
		}

		// small
		else {
			// reset scale
			ball.transform.localScale = new Vector3(1, 1, 1);

			// choose random location
			int randX = Random.Range(Screen.width/-2 + sizeBuffer, Screen.width/2 - size - sizeBuffer);
			int randY = Random.Range(Screen.height/-2 + size + sizeBuffer, Screen.height/2 - sizeBuffer);
			ball.transform.position = new Vector3(randX, randY, 0);
		}

	}

}
