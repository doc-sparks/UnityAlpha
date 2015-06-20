using UnityEngine;
using System.Collections;

public class FiniteLifetime : MonoBehaviour {

	public float timeToDeath_ = 5f;

	private float initTime_;

	// Use this for initialization
	void Start () {
		initTime_ = Time.time;	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		// check if the death timer has been reached
		if (initTime_ + timeToDeath_ < Time.time) {
			Destroy(gameObject);
		}
	}
}
