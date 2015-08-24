using UnityEngine;
using System.Collections;

public class JumpingAndFallingController : MonoBehaviour {

	public float jumpForceHorizontal_ = 750f;
	public float jumpForceVertical_ = 1250f;
	public float jumpingDelay_ = 0.1f;

	private float jumpTime_ = 0f;
	private StateMachine stateMachine_ = null;
	public int numCurrentColls = 0;
	public bool landed_ = false;

	// Use this for initialization
	void Start () {
	
		// We have states so grab it if there is one
		stateMachine_ = transform.parent.GetComponent<StateMachine>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		// ------------------------------------------------
		// separately check for jumping
		bool jump_flag = false;
		if ((Time.time > jumpTime_) && (landed_) && (Input.GetAxis ("Jump") > 0.0f)) {
			
			// check for the state machine
			if (stateMachine_) {
				stateMachine_.changeStateTimed ( StateMachine.State.jumping, -1f, StateMachine.State.falling );
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
			Rigidbody2D body = transform.parent.GetComponent<Rigidbody2D>();
			body.AddForce( new Vector2( Input.GetAxis ("Horizontal") * jumpForceHorizontal_, jumpForceVertical_ ) );
		}
	}
	
	void OnTriggerEnter2D( Collider2D obj )
	{
		// check if we've hit the ground
		landed_ = true;
		numCurrentColls++;

		if (stateMachine_) {
			// switch to a landing state
			stateMachine_.changeStateTimed ( StateMachine.State.landing, -1f, StateMachine.State.idle );
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		// check if we've left the ground
		numCurrentColls--;
		if (numCurrentColls <= 0)
		{
			landed_ = false;

			if (stateMachine_) {
				// we're falling
				stateMachine_.changeState( StateMachine.State.falling );
			}
		}


	}
}
