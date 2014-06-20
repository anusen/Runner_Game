using UnityEngine;
using System.Collections;

// This script lets the player continuously move forward.
// The distance and speed are variable.
// It uses the CharacterControler SimpleMove function.


public class ForwardMoving : MonoBehaviour {
	
	public Vector3 direction =				
		new Vector3(-1,0,0);
	public float speed = 5.0f;

	private CharacterController controller;

	void Awake () {
		controller = 
			GetComponent<CharacterController>(); 		// gets the CharacterController for the player	
	}

	void Update () {
		Vector3 movement = direction;					// gets the direction to move
		movement.Normalize ();							// normalizes the direction to use only the 
														// speed variable as speed factor
		movement *= speed;								// multiplicats the speed to the direction
		controller.SimpleMove 
			(movement * Time.deltaTime); 				// moves the player
	}
}
