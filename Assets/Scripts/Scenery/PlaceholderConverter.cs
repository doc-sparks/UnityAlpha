using UnityEngine;
using System.Collections;

public class PlaceholderConverter : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// loop over all placeholders and replace with the given prefab
		// NOTE: Only required whie Unity doesn't support nested prefabs
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
			}

			// Destroy the placeholder
			Destroy(obj);
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
	}
}
