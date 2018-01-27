using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour{

	// Make this public and assign the values in the inspector via drag-and-drop
	public AudioClip[] letterSFX;
	
	public void PlayLetterSFX (int letter) {

		// This method will play a SFX, but if this method gets called again while the SFX is still playing,
		// the currently-playing sound will cut off and the new sound will start.
		// That's not an issue for this game, but in a more complex game with many overlapping SFX, we would need to find a solution.
		//audio.clip = letterSFX[letter];
		//audio.Play();
	}
}
