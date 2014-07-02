using System.Collections.Generic;
using UnityEngine;


// This class compares to bars by their max z values.
public class BarComparer : IComparer<GameObject> {

	public int Compare(GameObject x, GameObject y) {
		float valueX = x.transform.position.z + x.renderer.bounds.size.z;
		float valueY = y.transform.position.z + y.renderer.bounds.size.z;
		return (int) -valueX.CompareTo (valueY);
	}
}

