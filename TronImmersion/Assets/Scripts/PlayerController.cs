﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float m_turn_speed = 100.0f;
	public float m_speed;
	private Rigidbody m_rb;
    public bool m_is_grounded = false;
    Vector3 movementZ;
    Vector3 rotationY;

    private void Awake() {
		m_rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate(){
        if (m_is_grounded)
        {
            float y = Input.GetAxisRaw("Horizontal");

            handleDrive();
            handleTurn(y);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("grid"))
        {
            //Debug.Log("in contact with ground");
            m_is_grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("grid"))
        {
            //Debug.Log("lost contact with ground");
            m_is_grounded = false;
        }
    }

    void handleDrive()
    {
        movementZ = transform.forward * m_speed * Time.deltaTime;
        m_rb.MovePosition(transform.position + movementZ);
    }

    void handleTurn(float y)
    {
        rotationY.Set(0f, y, 0f);
        rotationY = rotationY.normalized * m_turn_speed;
        Quaternion deltaRotation = Quaternion.Euler(rotationY * Time.deltaTime);
        m_rb.MoveRotation(m_rb.rotation * deltaRotation);
    }

}