using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour {
	[SerializeField] public float m_EnemySpeed = 5.0f;

	public int m_EnemyDirection = 1;

	void Awake() {
		Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D>();
		rigidBody2D.velocity = new Vector2(m_EnemySpeed*m_EnemyDirection,rigidBody2D.velocity.y);
	}
}
