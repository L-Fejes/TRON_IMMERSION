using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {

    public GameObject LightCyclePrefab;
    public static int startZoneSize = 300;
    static int numOfAI = 10;
    public static GameObject[] allAI = new GameObject[numOfAI];

    public static Vector3 goalPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < numOfAI; i++)
        {
            Vector3 startPosition = new Vector3(Random.Range(-startZoneSize, startZoneSize), 0 , Random.Range(-startZoneSize, startZoneSize));
            Quaternion startRotation = Quaternion.AngleAxis(Random.Range(-180.0f, 180.0f), Vector3.up);
            allAI[i] = (GameObject)Instantiate(LightCyclePrefab, startPosition, startRotation);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Random.Range(0,10000) < 50)
        {
            goalPosition = new Vector3(Random.Range(-startZoneSize, startZoneSize), 0, Random.Range(-startZoneSize, startZoneSize));
        }
	}
}
