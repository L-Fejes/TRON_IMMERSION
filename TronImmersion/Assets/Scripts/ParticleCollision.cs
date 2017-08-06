using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour {

    void Start()
    {
        ParticleSystem m_ps = GetComponent<ParticleSystem>();
        var coll = m_ps.collision;
        coll.enabled = true;
        coll.bounce = 0.5f;
    }
	

}
