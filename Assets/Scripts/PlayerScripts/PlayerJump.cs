using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

	public float jumpPower = 10.0f;
	public float jumpTime = 2.0f;
	public bool jumpAllowed = true;

	private bool jumping;
	private Vector3 startPos;
	private Vector3 targetPos;
	private float height;
	private float verticalVelocity;
	private float currentTime;
	private float barDistance;

	void Awake() {
		barDistance = StageProperties.barDistance;
	}

	
	void FixedUpdate () {
		if(jumpAllowed) {
			if(jumping) {
				if(currentTime < jumpTime) {
					verticalVelocity = Mathf.Lerp(jumpPower, -jumpPower, currentTime / jumpTime);
					height += verticalVelocity * Time.deltaTime;
					Vector3 basePos = new Vector3(
						Mathf.Lerp(startPos.x, targetPos.x, currentTime / jumpTime),
						startPos.y,transform.position.z);
					Vector3 resultantPos = basePos + (Vector3.up * height);
					transform.position = resultantPos;
					currentTime += Time.deltaTime;
				} else {
					transform.position = new Vector3(targetPos.x,targetPos.y,transform.position.z);
					jumping = false;
				}
			} else {
				float jumpDirection = Input.GetAxis ("Horizontal");
				if(jumpDirection != 0) {
					jumping = true;
					startPos = transform.position;
					if(jumpDirection > 0) {
						targetPos = startPos + (Vector3.right * barDistance);
					} else {
						targetPos = startPos + (Vector3.left * barDistance);
					}
					height = 0.0f;
					currentTime = 0.0f;
				}
			}
		}
	}

}
