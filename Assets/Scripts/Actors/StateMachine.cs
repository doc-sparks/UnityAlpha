using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachine : MonoBehaviour {

	public enum State {
		idle = 0,

		left,
		right,
		stop_moving,

		jumping,
		falling,
		landing,
	}
	
	public State currState_ = State.idle;
	public State nextState_ = State.idle;
	public float stateTimer_ = -1f;

	// ------------------------------------------------
	// allowed state changes
	private Dictionary<State, List<State> > allowed_state_change_;

	// Use this for initialization
	void Start () {

		// set up the state change array
		allowed_state_change_ = new Dictionary<State, List<State> > ();

		// set of states you can go to from this state
		allowed_state_change_[ State.idle ] = new List<State>();
		allowed_state_change_[ State.idle ].Add(State.left);
		allowed_state_change_[ State.idle ].Add(State.right);
		allowed_state_change_[ State.idle ].Add(State.jumping);
		allowed_state_change_[ State.idle ].Add(State.falling);

		allowed_state_change_[ State.left ] = new List<State>();
		allowed_state_change_[ State.left ].Add(State.right);
		allowed_state_change_[ State.left ].Add(State.jumping);
		allowed_state_change_[ State.left ].Add(State.stop_moving);
		allowed_state_change_[ State.left ].Add(State.falling);

		allowed_state_change_[ State.right ] = new List<State>();
		allowed_state_change_[ State.right ].Add(State.left);
		allowed_state_change_[ State.right ].Add(State.jumping);
		allowed_state_change_[ State.right ].Add(State.stop_moving);
		allowed_state_change_[ State.right ].Add(State.falling);

		allowed_state_change_[ State.stop_moving ] = new List<State>();
		allowed_state_change_[ State.stop_moving ].Add(State.left);
		allowed_state_change_[ State.stop_moving ].Add(State.right);
		allowed_state_change_[ State.stop_moving ].Add(State.jumping);
		allowed_state_change_[ State.stop_moving ].Add(State.idle);
		allowed_state_change_[ State.stop_moving ].Add(State.falling);

		allowed_state_change_[ State.jumping ] = new List<State>();
		allowed_state_change_[ State.jumping ].Add(State.falling);

		allowed_state_change_[ State.falling ] = new List<State>();
		allowed_state_change_[ State.falling ].Add(State.landing);

		allowed_state_change_[ State.landing ] = new List<State>();
		allowed_state_change_[ State.landing ].Add(State.idle);
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		// have we got a timed state to switch to?
		if ((stateTimer_ > 0f) && (Time.time > stateTimer_) &&
		    (allowed_state_change_ [currState_].Contains (nextState_)) ) {
				currState_ = nextState_;
		}
	}

	// attempt to change the state
	public bool changeState(State new_state) {

		// check if we can go to the new state from the current one
		if (allowed_state_change_ [currState_].Contains (new_state)) {
			currState_ = new_state;
			return true;
		} else {
			return false;
		}

	}

	// attempt to change the state but set a timer to change back/to second state
	public bool changeStateTimed( State new_state, float t, State next_state){

		// NOTE: Possible problem with negative times. Should probably set the state back straight away

		// check if we can go to the new state from the current one
		if (!allowed_state_change_ [currState_].Contains (new_state)) {
			return false;
		} 

		// set the variables to trigger the next state
		currState_ = new_state;
		stateTimer_ = Time.time + t;
		nextState_ = next_state;
		return true;
	}
}
