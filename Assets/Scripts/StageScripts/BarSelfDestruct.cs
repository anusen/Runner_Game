using UnityEngine;
using System.Collections;

public class BarSelfDestruct : MonoBehaviour {

	public static float distanceToPlayer = 20.0f;
	public static GameObject player;

	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		if(transform.position.z < (player.transform.position.z - distanceToPlayer)) {
			DestroyObject(gameObject);
		}
	}
}
