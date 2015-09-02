using UnityEngine;
using System.Collections;

public class CharacterMovementController : MovementController {
	static int MOVEMENT_STATE_GROUNDED = 0;
	static int MOVEMENT_STATE_JUMPING = 1;
	static int MOVEMENT_STATE_JETPACKING = 2;
	static int MOVEMENT_STATE_FALLING = 3;

	public int m_State = MOVEMENT_STATE_GROUNDED;
	
	public bool m_HasStartedFalling = true;
	public float m_JetpackJuice = 0.0f;
	public int m_AirdashAvailable = 0;

	public float m_XSpeedMagnitude = 0.0f;
	public float m_XSpeedDirection = 1.0f;

	private Animator m_Animator;

	[SerializeField] public float m_HorizontalSpeed;
	[SerializeField] public float m_JumpSpeed;
	[SerializeField] public float m_JumpDuration;
	[SerializeField] public float m_JetpackSpeed;
	[SerializeField] public float m_JetpackAmount;
	[SerializeField] public float m_JetpackLossPerTick;
	[SerializeField] public float m_DashSpeed;
	[SerializeField] public float m_DashFalloff;
	[SerializeField] public int m_DashAmount;


	void Flip() {
		if (!Mathf.Approximately (m_XSpeedDirection, 0.0f)) {
			transform.localScale = new Vector3(Mathf.Abs (transform.localScale.x)*m_XSpeedDirection,transform.localScale.y,transform.localScale.z);
		}
	}


	void Awake() {
		m_AirdashAvailable = m_DashAmount;
		m_JetpackJuice = m_JetpackAmount;

		m_Animator = GetComponent<Animator> ();
	}

	void Update() {
		m_Animator.SetInteger ("m_State", m_State);
		m_Animator.SetFloat ("m_XSpeedMagnitude", m_XSpeedMagnitude);
	}


	void FixedUpdate () {
		// Horizontal movement
		float xSpeedMag = Mathf.Max(m_HorizontalSpeed * m_HorizontalMagnitude, m_XSpeedMagnitude * m_DashFalloff);
		if (Mathf.Approximately(0.0f,xSpeedMag)) {
			m_XSpeedDirection = 0.0f;
			m_XSpeedMagnitude = 0.0f;
		} else if (xSpeedMag > m_HorizontalSpeed) {
			m_XSpeedMagnitude = xSpeedMag;
		} else {
			m_XSpeedDirection = m_HorizontalSign;
			Flip ();
			if (m_DashKeyDown) { 
				m_DashKeyDown = false;
				if (m_AirdashAvailable > 0) {
					m_XSpeedMagnitude = m_DashSpeed;
					m_AirdashAvailable = m_AirdashAvailable - 1;
				} else {
					m_XSpeedMagnitude = m_HorizontalSpeed * m_HorizontalMagnitude;
				}
			} else {
				m_XSpeedMagnitude = m_HorizontalSpeed * m_HorizontalMagnitude;
			}
		}
		float currentYVelocity = m_RigidBody2D.velocity.y;
		m_RigidBody2D.velocity = new Vector2 (m_XSpeedMagnitude * m_XSpeedDirection, currentYVelocity);

		// Vertical movement
		if (m_State == MOVEMENT_STATE_GROUNDED) {
			if (m_JumpKey) {
				EnterStateJumping();
			} else if (currentYVelocity < -Mathf.Epsilon) {
				EnterStateFalling();
			}
		} else if (m_State == MOVEMENT_STATE_JETPACKING) {
			FixedUpdateJetpacking();

			if (!m_JumpKey) {
				EnterStateFalling();
			}
		} else if (m_State == MOVEMENT_STATE_FALLING) {
			FixedUpdateFalling();

			if (m_JumpKey && (m_JetpackJuice > -Mathf.Epsilon)) {
				EnterStateJetpacking();
			}
		}
	}


	void EnterStateGrounded() {
		m_State = MOVEMENT_STATE_GROUNDED;

		CancelInvoke ("TransitionOutOfJumping");
		
		m_AirdashAvailable = m_DashAmount;
		m_JetpackJuice = m_JetpackAmount;
	}

	void EnterStateJumping() {
		m_State = MOVEMENT_STATE_JUMPING;

		m_RigidBody2D.velocity = new Vector2 (m_RigidBody2D.velocity.x, m_JumpSpeed);
		Invoke ("TransitionOutOfJumping", m_JumpDuration);
	}

	void EnterStateJetpacking() {
		m_State = MOVEMENT_STATE_JETPACKING;

		CancelInvoke ("TransitionOutOfJumping");
	}

	void EnterStateFalling() {
		m_State = MOVEMENT_STATE_FALLING;
		if (m_RigidBody2D.velocity.y < -Mathf.Epsilon) {
			m_HasStartedFalling = true;
		} else {
			m_HasStartedFalling = false;	
		}

		CancelInvoke ("TransitionOutOfJumping");
	}


	void TransitionOutOfJumping() {
		if (m_JumpKey && (m_JetpackJuice > -Mathf.Epsilon)) {
			EnterStateJetpacking();
		} else {
			EnterStateFalling();
		}
	}

	void FixedUpdateJetpacking() {
		if (m_JetpackJuice > -Mathf.Epsilon) {
			m_RigidBody2D.velocity = new Vector2 (m_RigidBody2D.velocity.x, m_JetpackSpeed);
			m_JetpackJuice = m_JetpackJuice - m_JetpackLossPerTick;
		} else {
			EnterStateFalling();
		}
	}

	void FixedUpdateFalling() {
		if (m_RigidBody2D.velocity.y < -Mathf.Epsilon) {
			m_HasStartedFalling = true;
		}
		if (m_HasStartedFalling && (m_RigidBody2D.velocity.y >= -Mathf.Epsilon)) {
			EnterStateGrounded();
		}
	}
}
