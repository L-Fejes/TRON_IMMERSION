using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecognizerAI : MonoBehaviour {

    Vector3 movementZ;
    float m_speed = 20.0f;
    Rigidbody m_rb;

    float m_flight_boundary = 500.0f;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }

	// Update is called once per frame
	private void FixedUpdate () {
        handleFlyForward();
	}

    void handleFlyForward()
    {
        movementZ = transform.forward * m_speed * Time.deltaTime;
        m_rb.MovePosition(transform.position + movementZ);
    }

}
