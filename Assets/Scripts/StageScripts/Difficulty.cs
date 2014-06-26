using UnityEngine;
using System.Collections;


// Creates stochasticly floats for generating a random stage.
// Changes the boundaries, between which the floats are choosen, to display difficulty.
public class Difficulty : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Returns a distance to set the beging of a new bar behind an old bar.
	// The distance is computed stochasticly between two interval boundaries.
	public static float GetBarDistance () {
		return 0.0f;
	}

	// Returns a length for a new bar.
	// The length is computed stochasticly between two interval boundaries.
	public static float GetBarLength () {
		return 0.0f;
	}
}
