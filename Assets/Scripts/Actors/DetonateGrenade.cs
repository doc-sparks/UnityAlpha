using UnityEngine;
using System.Collections;

public class DetonateGrenade : MonoBehaviour {

	public float timeToDeath_ = 2f;
	public GameObject projectilePrefab_ = null;

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
		float max_dist = 7.0f;
		float fmax = 2000.0f;

		foreach (GameObject obj in GameObject.FindGameObjectsWithTag ("Scenery")) {
			float d = Vector3.Distance( obj.transform.position, transform.position );

			if ( (d < max_dist ) && ( d > 0 ) )
			{
				GameObject new_obj = (GameObject)Instantiate (projectilePrefab_);
				new_obj.transform.position = obj.transform.position;

				Destroy(obj);

				Rigidbody2D body = new_obj.GetComponent<Rigidbody2D>();

				//body.velocity = new Vector2(0f, 1f);
				float fmag = (fmax / 10.0f ) * max_dist / d;
				if (fmag > fmax) 
					fmag = fmax;
				body.AddForce( (new_obj.transform.position - transform.position).normalized * fmax );
				//body.Sleep();
			}
		}

		Destroy (gameObject);
	}
}
