using UnityEngine;
using System.Collections;

public class DetonateGrenade : MonoBehaviour {

	public float timeToDeath_ = 2f;
	
	private float initTime_;
	
	// Use this for initialization
	void Start () {
		initTime_ = Time.time;	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		// check if the death timer has been reached
		if (initTime_ + timeToDeath_ < Time.time) {
			detonate();
		}
	}

	// detonate the grenade
	void detonate() {

		// set blocks in range free and produce force
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag ("Scenery")) {
			if (Vector3.Distance( obj.transform.position, transform.position ) < 5.0f )
			{
				Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
				body.isKinematic = false;

				//body.velocity = new Vector2(0f, 1f);
				body.AddForce( new Vector2(0f, 1000f) );
				//body.Sleep();
			}
		}

		Destroy (gameObject);
	}
}
