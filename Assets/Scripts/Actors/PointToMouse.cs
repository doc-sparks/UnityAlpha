using UnityEngine;
using System.Collections;

public class PointToMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

		// Construct a quaternion from the position to the mouse pointer
		// TODO: Messes up when you go through the center of the object. Should do by hand probably
		Quaternion rotation = Quaternion.LookRotation(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position, 
		                                              transform.TransformDirection(Vector3.up));
		transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
	
	}
}
