using System.Collections;
using UnityEngine;

public class BikeController : MonoBehaviour {
    private Rigidbody m_rb;
    private Transform m_transform;
    Vector3 m_maxVelocity;

    void Awake() {
        m_rb = GetComponent<Rigidbody>();
        m_transform = m_rb.transform;
    }

}