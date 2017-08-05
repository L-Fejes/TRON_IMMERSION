using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float m_turn_speed = 100.0f;
	public float m_speed;
	private Rigidbody m_rb;
    Vector3 movementZ;
    Vector3 rotationY;

    private void Awake() {
		m_rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate(){
        float y = Input.GetAxisRaw("Horizontal");

        handleDrive();
        handleTurn(y);
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
