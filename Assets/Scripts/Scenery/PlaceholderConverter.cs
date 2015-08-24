using UnityEngine;
using System.Collections;

public class PlaceholderConverter : MonoBehaviour {

	public GameObject floorPrefab_ = null;

	// Use this for initialization
	void Start () {

		// loop over all placeholders and replace with the given prefab
		// NOTE: Only required while Unity doesn't support nested prefabs
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag ("Placeholder"))
		{
			// check for a prefab replacement script
			ReplaceWithPrefab rep = obj.gameObject.GetComponent<ReplaceWithPrefab>();
			if ((rep != null) && (rep.prefab_ != null))
			{
				// instantiate the prefab replacement
				GameObject new_obj = (GameObject) Instantiate(rep.prefab_);
				new_obj.transform.position = obj.transform.position;
				new_obj.transform.parent = transform;
				//new_obj.GetComponent<Rigidbody2D>().isKinematic = true;
			}

			// Destroy the placeholder
			Destroy(obj);
		}

		// create a floor at 0
		for (int i = -50; i < 50; i++) {
			for (int j = -20; j < 0; j++){
				GameObject new_obj = (GameObject)Instantiate (floorPrefab_);
				new_obj.transform.position = new Vector3 ((float)i, (float)j, 0);
				//new_obj.GetComponent<Rigidbody2D>().isKinematic = true;
			}
		}

	}
	
	// Update is called once per frame
	void LateUpdate () {
	
	}
}
