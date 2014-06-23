using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

	public float jumpPower = 10.0f;
	public float jumpTime = 2.0f;
	public float barDistance = 3;
	public bool jumpAllowed = true;

	private bool jumping;
	private Vector3 startPos;
	private Vector3 targetPos;
	private float height;
	private float verticalVelocity;
	private float currentTime;

	
	void FixedUpdate () {
		if(jumpAllowed) {
			if(jumping) {
				if(currentTime < jumpTime) {
					verticalVelocity = Mathf.Lerp(jumpPower, -jumpPower, currentTime / jumpTime);
					height += verticalVelocity * Time.deltaTime;
					Vector3 basePos = new Vector3(
						transform.position.x,startPos.y,
						Mathf.Lerp(startPos.z, targetPos.z, currentTime / jumpTime));
					Vector3 resultantPos = basePos + (Vector3.up * height);
					transform.position = resultantPos;
					//Debug.Log(resultantPos);
					Debug.Log(verticalVelocity);
					currentTime += Time.deltaTime;
				} else {
					transform.position = new Vector3(transform.position.x,targetPos.y,targetPos.z);
					jumping = false;
				}
			} else {
				float jumpDirection = Input.GetAxis ("Horizontal");
				if(jumpDirection != 0) {
					jumping = true;
					startPos = transform.position;
					if(jumpDirection > 0) {
						targetPos = startPos + (Vector3.forward * barDistance);
					} else {
						targetPos = startPos + (Vector3.back * barDistance);
					}
					height = 0.0f;
					currentTime = 0.0f;
				}
			}
		}
	}

}
