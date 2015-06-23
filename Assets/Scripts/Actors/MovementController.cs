using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	public float moveSpeed_ = 12.0f;

	private float jumpForceHorizontal_ = 500f;
	private float jumpForceVertical_ = 1250f;
	private float jumpingDelay_ = 0.1f;
	private float jumpTime_ = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		// NOTE: have changed the gravity option in the Input Manager to make it stop straight away
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
		if (Time.time > jumpTime_)
		{
			jumpTime_ = Time.time + jumpingDelay_;
		
			if (Input.GetAxis ("Jump") > 0.0f){
				Rigidbody2D body = GetComponent<Rigidbody2D>();
				body.AddForce( new Vector2( 0.0f * jumpForceHorizontal_, jumpForceVertical_ ) );
			}
		}
	}
	/*
	void OnCollisionEnter2D(Collision2D coll)
	{

			landed_ = true;

	}

	void OnCollisionExit2D(Collision2D coll)
	{

			landed_ = false;

	}*/
}
