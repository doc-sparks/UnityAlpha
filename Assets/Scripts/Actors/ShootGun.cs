using UnityEngine;
using System.Collections;

public class ShootGun : MonoBehaviour {

	public GameObject bulletPrefab_ = null;
	public float bulletSpeed_ = 45f;
	public float firingDelay_ = 0f;

	public GameObject grenadePrefab_ = null;

	private float fireTime_ = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		// Check for fire
		if (Input.GetAxis ("Fire1") > 0f) {

			// Check delay
			if (Time.time > fireTime_)
			{
				fireTime_ = Time.time + firingDelay_;
				/*
				// launch the bullet
				GameObject bullet = (GameObject) Instantiate(bulletPrefab_);
				bullet.transform.position = transform.position;
				Rigidbody2D body = bullet.GetComponent<Rigidbody2D>();
				body.velocity = transform.right * bulletSpeed_;
				*/

				// set the grenade
				GameObject grenade = (GameObject) Instantiate(grenadePrefab_);
				grenade.transform.position = new Vector3(0, 1, 0);
			}
		}
	}
}
