using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {

    private float m_turn_speed = 120.0f;
    public float m_speed = 75;
    private Rigidbody m_rb;
    private bool m_is_grounded = false;
    private float m_previous_decision = 0;
    public int m_sight_range = 60;
    private Vector3 movementZ;
    private Vector3 rotationY;
    public bool m_isAlive;
    public GameController m_gc;

    Vector3 averageHeading;
    Vector3 averagePosition;
    float neighbourDistance = 100.0f;

    // Use this for initialization
    void Start () {
        m_rb = GetComponent<Rigidbody>();
        m_gc = GameObject.Find("GameController").GetComponent<GameController>();
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            m_isAlive = false;
            this.gameObject.SetActive(false);
            if (!m_gc.m_gameOver)
            {
                m_gc.AIKilled();
                //m_gc.GameOver(true);
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


    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("wall"))
        {
            m_isAlive = false;
            this.gameObject.SetActive(false);
            if (!m_gc.m_gameOver)
            {
                m_gc.AIKilled();
                //m_gc.GameOver(true);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        float y = 0;

        if (m_is_grounded)
        {
            y = applyRules();
        }

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

    float applyRules()
    {
        float new_y = 0;

        if (Physics.Raycast(transform.position - 2 * transform.right, transform.forward - 0.5f * transform.right, m_sight_range) ||
                Physics.Raycast(transform.position + 2 * transform.right, transform.forward + 0.5f * transform.right, m_sight_range))
        {

            if (m_previous_decision != 0)
            {
                //Debug.Log("Keep Turning!");
                new_y = m_previous_decision;
            }
            else
            {
                Debug.Log("There is something in front of the object!");

                RaycastHit hitForwardLeft;
                RaycastHit hitForwardRight;

                Physics.Raycast(transform.position - 2 * transform.right, transform.forward - 0.5f * transform.right, out hitForwardLeft);
                Physics.Raycast(transform.position + 2 * transform.right, transform.forward + 0.5f * transform.right, out hitForwardRight);

                Debug.Log("LeftDistance: " + hitForwardLeft.distance + ", RightDistance: " + hitForwardRight.distance);

                if (hitForwardLeft.distance < hitForwardRight.distance)
                {
                    Debug.Log("Turn right!");
                    new_y = 1;
                }
                else
                {
                    Debug.Log("Turn left!");
                    new_y = -1;
                }
            }
        }
        else if(Random.Range(0, 5) < 1) 
        {
            GameObject[] gos;
            gos = AIManager.allAI;

            Vector3 vcenter = Vector3.zero;
            Vector3 vavoid = Vector3.zero;
            Vector3 goalPosition = AIManager.goalPosition;

            float distance;
            int groupSize = 0;

            foreach (GameObject go in gos)
            {
                if (go != this.gameObject)
                {
                    distance = Vector3.Distance(go.transform.position, this.transform.position);
                    if (distance <= neighbourDistance)
                    {
                        vcenter += go.transform.position;
                        groupSize++;

                        if (distance < 30.0f)
                        {
                            vavoid = vavoid + (this.transform.position - go.transform.position);
                        }
                    }
                }

                if (groupSize > 0)
                {
                    vcenter = vcenter / groupSize + (goalPosition - this.transform.position);

                    Vector3 direction = (vcenter + vavoid) - transform.position;

                    if (direction != Vector3.zero)
                    {
                        new_y = Quaternion.LookRotation(direction).eulerAngles.normalized.y < 0 ? -1 : 1;
                    }
                }

            }
        }

        m_previous_decision = new_y;
        return (new_y);
    }

}
