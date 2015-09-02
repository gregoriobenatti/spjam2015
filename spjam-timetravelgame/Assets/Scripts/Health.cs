using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	private int m_Health = 1;
	
	public void Damage(int amount) {
		m_Health = (int)(Mathf.Round(Mathf.Max(m_Health - amount, 0.0f)));
		if (m_Health <= 0) {
			Application.LoadLevel(Application.loadedLevel);
			Destroy(gameObject);
		}
	}
}
