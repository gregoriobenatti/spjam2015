using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {
	// Controls
	public float m_HorizontalMagnitude = 0.0f;
	public float m_HorizontalSign = 0.0f;
	public bool m_JumpKey = false;
	public bool m_DashKeyDown = false;

	// Vars
	protected Rigidbody2D m_RigidBody2D;

	void Start() {
		m_RigidBody2D = GetComponent<Rigidbody2D>();
	}
}
