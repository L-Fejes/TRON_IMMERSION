using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float m_maxLean = 180;
	private float m_speed = 2.0f;
	private float m_currentSpeed;
	public Vector3 m_maxVelocity;
	private Rigidbody m_rb;

	private void Awake() {
		m_rb = GetComponent<Rigidbody>();
	}


	void Start()
	{
		//m_rb.AddRelativeForce(transform.forward * 250.0f);
	}

	void Update() {
		Move();
		if (Input.GetKey(KeyCode.D)) {
    		transform.Rotate(0, 1.5f ,0);
		}
 		if (Input.GetKey(KeyCode.A)) {
    		transform.Rotate(0,-1.5f,0);
		}
	}
	

	void FixedUpdate(){
		Move();
		m_currentSpeed = m_rb.velocity.magnitude;
	}

	private void Move() {
		m_rb.AddRelativeForce(transform.forward * m_speed);
	}
}
