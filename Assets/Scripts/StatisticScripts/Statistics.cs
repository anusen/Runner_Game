using UnityEngine;
using System.Collections;

// This script saves statistics about the game
public class Statistics : MonoBehaviour {

	public static float currentWalkedMeters;			// The meters the player walked since the last respawn.
														// Use this to create difficulty over time.

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Adds walked meters to the current walked meters.
	// Should be called by the player moving script.
	public static void addWalkedMeters (float walkedMeters) {
		currentWalkedMeters += walkedMeters;
	}
}
