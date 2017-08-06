using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private float m_turn_speed = 100.0f;
    public float m_speed;
    private Rigidbody m_rb;
    public bool m_is_grounded = false;
    Vector3 movementZ;
    Vector3 rotationY;

    public int m_intelligence = 0;
    public float m_prev_decision = 0;
    public int m_sight_range = 50;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (m_is_grounded)
        {
            float y = nextAction();
            
            handleDrive();
            handleTurn(y);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("You Lose Bitch");
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


    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("You Lose Bitch");
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

    private float nextAction()
    {
        float new_y = 0;

        if (m_intelligence == 0)
        {
            new_y = Random.Range(-1.0f, 1.0f);
        }
        else if (m_intelligence == 1)
        {
            if (Physics.Raycast(transform.position, transform.forward, m_sight_range))
            {
                Debug.Log("There is something in front of the object!");

                if (m_prev_decision != 0) {
                    Debug.Log("Keep Turning!");
                    new_y = m_prev_decision;
                }
                else
                {
                    Debug.Log("Better get out of the way!");
                    do
                    {
                        new_y = Random.Range(-1.0f, 1.0f);
                    }
                    while (new_y != 0);
                }
            }
            else
            {
                new_y = Random.Range(-1.0f, 1.0f);

                if (Mathf.Abs(new_y) < 0.5)
                {
                    new_y = 0;
                }
            }
        }

        m_prev_decision = new_y;
        return (new_y);
    }
}