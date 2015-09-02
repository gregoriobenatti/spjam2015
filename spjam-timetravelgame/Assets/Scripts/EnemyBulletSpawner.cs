using UnityEngine;
using System.Collections;

public class EnemyBulletSpawner : MonoBehaviour {
	[SerializeField] GameObject m_EnemyBulletPrefab;
	[SerializeField] float m_FireDelay = 1.0f;

	void Awake () {
		InvokeRepeating ("Fire", m_FireDelay, m_FireDelay);
	}

	void Fire() {
		Instantiate (
			m_EnemyBulletPrefab,
			new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z),
			transform.rotation
		);
	}
}
