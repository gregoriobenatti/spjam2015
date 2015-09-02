using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Damage))]
public class EnemyAttackScript : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		Health health = other.gameObject.GetComponent<Health>();
		if (health != null) {
			int damage = GetComponent<Damage>().m_Damage;
			health.Damage(damage);
		}
	}
}
