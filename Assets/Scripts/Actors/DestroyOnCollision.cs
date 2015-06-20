using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	public string dangerousObjectTag_ = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

	}

	// have we collided with the appropriate object?
	void OnTriggerEnter2D(Collider2D obj)
	{
		// first, pass on the trigger to any other objects using this script
		// This means not every object needs to have 'IsTrigger' Colliders
		DestroyOnCollision des_on_col = obj.gameObject.GetComponent<DestroyOnCollision>();
		if (des_on_col != null)
		{
			des_on_col.checkDestroyTrigger(gameObject.tag);
		}

		// Now check if we should destroy ourselves
		checkDestroyTrigger (obj.tag);
	}

	public void checkDestroyTrigger( string tag )
	{
		// is this the dangerous tag?
		if (tag == dangerousObjectTag_) {
			Destroy (gameObject);
		}
	}
}
