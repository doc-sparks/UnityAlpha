using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

	public Transform objectToFollow_ = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		// seet position to parent position
		transform.position = objectToFollow_.position;
	}
}
