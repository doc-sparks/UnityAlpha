using UnityEngine;
using System.Collections;

public class KeyboardMovementController : MonoBehaviour {

	private float moveSpeed_ = 12.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		// check for keyboard input
		Vector3 scale = transform.localScale;
		if (Input.GetAxis ("Horizontal") < 0f) {
			// move left
			transform.Translate( new Vector3(moveSpeed_ * -1f * Time.deltaTime, 0f, 0f) );

			// point image in correct direction
			if (scale.x > 0f)
			{
				scale.x *= -1f;
				transform.localScale = scale;
			}

		} else if (Input.GetAxis ("Horizontal") > 0f) {
			// move right
			transform.Translate( new Vector3(moveSpeed_ * Time.deltaTime, 0f, 0f) );

			// point image in correct direction
			if (scale.x < 0f)
			{
				scale.x *= -1f;
				transform.localScale = scale;
			}
		}

		// separately check for jumping
		if (Input.GetAxis ("Jump") > 0.0f) {

		}
	}
}
