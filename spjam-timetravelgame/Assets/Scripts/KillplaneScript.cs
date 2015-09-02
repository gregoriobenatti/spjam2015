using UnityEngine;
using System.Collections;

public class KillplaneScript : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {

		if (GameObject.Find ("Player") == other.gameObject) {
			Application.LoadLevel(Application.loadedLevel);
		}

		Destroy (other.gameObject);
	}
}
