using UnityEngine;
using System.Collections;

// This script locks the camera to a fixed position, looking at the target.
// The position is depending on the targets location.
// Vector3 distance sets the distance between camera and target.

public class LockedCamera : MonoBehaviour {

	public GameObject target;							
	public Vector3 distance =
		new Vector3(5,5,0);
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 campos = target.transform.position;			// getting target position
		campos += distance;									// add distance
		Camera.main.transform.position = campos;			// set camera position
		Camera.main.transform.LookAt (target.transform);  	// let camera look at target
	}
}
