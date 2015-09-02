using UnityEngine;
using System.Collections;

public class EnemySwapDirectionTrigger : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		GameObject parent = transform.parent.gameObject;
		EnemyMovementController parentMovementController = parent.GetComponent<EnemyMovementController> ();

		int direction = -parentMovementController.m_EnemyDirection;
		parentMovementController.m_EnemyDirection = direction;

		Rigidbody2D rigidBody2D = parent.GetComponent<Rigidbody2D>();
		rigidBody2D.velocity = new Vector2 (direction*parentMovementController.m_EnemySpeed, rigidBody2D.velocity.y);
	}
}
