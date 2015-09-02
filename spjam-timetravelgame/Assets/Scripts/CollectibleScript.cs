using UnityEngine;
using System.Collections;

public class CollectibleScript : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		Collector collector = other.gameObject.GetComponent<Collector> ();
		if (collector != null) {
			GameObject parent = gameObject.transform.parent.gameObject;
			collector.Collect(parent.GetComponent<CollectValue>());
			Destroy (parent);
		}
	}
}
