using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour {
	public Transform m_target;
	public float m_distance			= 1.5f;
	public float m_height			= 2.5f;
	public float m_heightDamping	= 3.0f;
	public float m_rotationDamping	= 15.0f;

	void FixedUpdate() {
		// Getting the current rotation of the camera
		Quaternion currentRotation 	= transform.rotation;
		//Getting the current rotation of the target
		Quaternion wantedRotation 	= m_target.rotation;
		// Lerp the difference between the rotations
		Quaternion newRotation = Quaternion.Lerp(currentRotation, wantedRotation, m_rotationDamping * Time.deltaTime);
		// Set the rotation to the new Lerped rotation
		transform.rotation = newRotation;
		// Set the position minus the height and distance from target
		transform.position = m_target.position - (transform.forward * m_distance) + (m_target.up * m_height);
	}
}