using UnityEngine;
using System.Collections;

// This script resets the position of the player if he is dead.
// The position the player respawns is defined by the "Respawn" tag.
// There should only be one GameObject with the tag "Respawn".

public class PlayerRespawn : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (PlayerDead.playerIsDead) {							// checks for the players death
			GameObject respawn = 								// gets the respawn point
				GameObject.FindGameObjectWithTag ("Respawn");	
			gameObject.transform.position = 					// sets the players position to the respawn
				respawn.transform.position;
			PlayerDead.playerIsDead = false;					// sets the playerIsDead variable to false
		}
	}
}
