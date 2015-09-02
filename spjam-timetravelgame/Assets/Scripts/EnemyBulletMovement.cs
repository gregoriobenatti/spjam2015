using UnityEngine;
using System.Collections;

public class EnemyBulletMovement : MonoBehaviour {
	[SerializeField] float m_Speed = 2.0f;
	[SerializeField] float m_LifeTime = 10.0f;

	void Awake () {
		Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D> ();
		rigidBody2D.velocity = new Vector2 (-m_Speed, 0.0f);
		Invoke ("DestroySelf", m_LifeTime);
	}

	void DestroySelf() {
		Destroy (gameObject);
	}
}
