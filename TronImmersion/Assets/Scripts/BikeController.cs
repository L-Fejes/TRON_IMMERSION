using System.Collections;
using UnityEngine;

public class BikeController : MonoBehaviour {
    private Rigidbody m_rb;

    void Awake() {
        m_rb = GetComponent<Rigidbody>();
    }

    public void Move(float lean) {
        ApplyThrottle();
        ApplyLean(-lean);
    }

    void ApplyThrottle() {
        m_rb.AddRelativeForce(transform.forward*100.0f);
    }

    void ApplyLean(float input) {
        m_rb.transform.Rotate(0, input, 0);
    }
}