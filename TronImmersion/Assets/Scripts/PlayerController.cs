using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float m_turn_speed = 120.0f;
	public float m_speed;
	private Rigidbody m_rb;
    public bool m_is_grounded = false;
    Vector3 movementZ;
    Vector3 rotationY;
    public bool m_isAlive = true;
    public GameController m_gc;
    public GameObject explosion;
    public AudioClip m_explosionSound;
    public AudioSource m_audio;

    private void Awake() {
		m_rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate(){
        if (m_is_grounded)
        {
            float y = Input.GetAxisRaw("Horizontal");
            //Debug.Log(y);
            handleDrive();
            handleTurn(y);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("wall")) {
            m_isAlive = false;

            m_audio.PlayOneShot(m_explosionSound);
            Instantiate(explosion, transform.position, transform.rotation);

            this.gameObject.SetActive(false);
            if (!m_gc.m_gameOver) {
                m_gc.Lose();
                //m_gc.GameOver();
            }
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


    void OnParticleCollision(GameObject other) {
        if (other.gameObject.CompareTag("wall")) {
            m_isAlive = false;

            m_audio.PlayOneShot(m_explosionSound);
            Instantiate(explosion, transform.position, transform.rotation);

            this.gameObject.SetActive(false);
            if (!m_gc.m_gameOver) {
                m_gc.Lose();
                //m_gc.GameOver(false);
            }
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
