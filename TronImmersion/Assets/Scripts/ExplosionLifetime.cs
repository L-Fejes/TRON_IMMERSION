using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLifetime : MonoBehaviour {

    float lifetime = 5.0f;
	
	// Update is called once per frame
	void Update () {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0.0f)
        {
            DestroyObject(gameObject);
        }
    }
}
