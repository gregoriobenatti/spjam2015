using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
public class InputHandler : MonoBehaviour {
	MovementController m_Controller;

	void Awake() {
		m_Controller = GetComponent<MovementController> ();
	}

	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Horizontal");
		m_Controller.m_HorizontalMagnitude = Mathf.Abs(horizontal);
		m_Controller.m_HorizontalSign = Mathf.Sign(horizontal);
		m_Controller.m_JumpKey = Input.GetKey(KeyCode.X);
		m_Controller.m_DashKeyDown = m_Controller.m_DashKeyDown || Input.GetKeyDown(KeyCode.C);
	}
}
