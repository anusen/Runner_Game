using UnityEngine;
using System.Collections;

// This script sets a playerIsDead variable if the player 
// is bejond a specific height.

// Here can be added later features for the players death.

public class PlayerDead : MonoBehaviour {

	public static bool playerIsDead;
	public float deadHeigth = -2.0f;
	
	void Awake() {
		playerIsDead = false;								// set playerIsDead to false 
	}

	void Update () {
		if (gameObject.transform.position.y < deadHeigth)	// checks if player is bejond specific heigth
						playerIsDead = true;				// and sets playerIsDead to true
	}
}
