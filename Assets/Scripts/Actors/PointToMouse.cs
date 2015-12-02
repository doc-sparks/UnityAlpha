using UnityEngine;
using System.Collections;

public class PointToMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

		// Construct a quaternion from the position to the mouse pointer
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
		transform.Rotate (Vector3.forward * 90);
	}
}
