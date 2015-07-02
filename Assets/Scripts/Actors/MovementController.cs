using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	public float moveSpeed_ = 12.0f;
	public float jumpForceHorizontal_ = 750f;
	public float jumpForceVertical_ = 1250f;
	public float jumpingDelay_ = 0.1f;

	private float jumpTime_ = 0f;
	private StateMachine stateMachine_ = null;

	// Use this for initialization
	void Start () {
	
		// We have states so grab it if there is one
		stateMachine_ = GetComponent<StateMachine>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		// NOTE: have changed the gravity option in the Input Manager to make it stop straight away
		// NOTE: keyboard input and actual moving is seperated as with a state machine, could be triggered
		//			by something else

		// check for keyboard input
		Vector3 scale = transform.localScale;

		// flag to set the stop_moving state
		bool no_move = true;

		// ------------------------------------------------
		// Move Left
		bool move_left = false;
		if (Input.GetAxis ("Horizontal") < 0f) {

			// check the state machine if given
			if (stateMachine_) {
				stateMachine_.changeState(StateMachine.State.left);
				no_move = false;
			}

			// set the flag in case we're not running in a state machine
			move_left = true;
		}

		// change flag based on state machine if present
		if (stateMachine_) {
			move_left = (stateMachine_.currState_ == StateMachine.State.left);
		}

		// Now actually do the moves
		if (move_left) {

			// move left
			transform.Translate (new Vector3 (moveSpeed_ * -1f * Time.deltaTime, 0f, 0f));

			// point image in correct direction
			if (scale.x > 0f) {
				scale.x *= -1f;
				transform.localScale = scale;
			}
		}

		// ------------------------------------------------
		// Move Right
		bool move_right = false;
		if (Input.GetAxis ("Horizontal") > 0f) {
			
			// check the state machine if given
			if (stateMachine_) {
				stateMachine_.changeState(StateMachine.State.right);
				no_move = false;
			}
			
			// set the flag in case we're not running in a state machine
			move_right = true;
		}
		
		// change flag based on state machine if present
		if (stateMachine_) {
			move_right = (stateMachine_.currState_ == StateMachine.State.right);
		}
		
		// Now actually do the moves
		if (move_right) {
			
			// move left
			transform.Translate (new Vector3 (moveSpeed_ * 1f * Time.deltaTime, 0f, 0f));
			
			// point image in correct direction
			if (scale.x < 0f) {
				scale.x *= -1f;
				transform.localScale = scale;
			}
		}

		// ------------------------------------------------
		// sort out no horizontal movement
		if ((no_move) && (stateMachine_)) {
			stateMachine_.changeStateTimed ( StateMachine.State.stop_moving, -1f, StateMachine.State.idle );
		}

		// ------------------------------------------------
		// separately check for jumping
		bool jump_flag = false;
		if ((Time.time > jumpTime_) && (Input.GetAxis ("Jump") > 0.0f)) {

			// check for the state machine
			if (stateMachine_) {
				stateMachine_.changeState (StateMachine.State.jumping);
			}

			// set the flag in case we're not running in a state machine
			jump_flag = true;
		}

		// change flag based on state machine if present
		if (stateMachine_) {
			jump_flag = (stateMachine_.currState_ == StateMachine.State.jumping);
		}

		if (jump_flag) {
			jumpTime_ = Time.time + jumpingDelay_;
			Rigidbody2D body = GetComponent<Rigidbody2D>();
			body.AddForce( new Vector2( Input.GetAxis ("Horizontal") * jumpForceHorizontal_, jumpForceVertical_ ) );
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
