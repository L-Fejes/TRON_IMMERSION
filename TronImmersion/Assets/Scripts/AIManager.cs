using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour {

    public GameObject LightCyclePrefab;
    public GameObject RecognizerPrefab;
    public static int startZoneSize = 300;
    public static int recognizerStartHeight = 100;
    public static int recognizerFlightBoundary = 500;
    static int numOfAI = 3;
    static int numOfRecognizer = 8;
    public static GameObject[] allAI = new GameObject[numOfAI];
    public static GameObject[] allRecognizer = new GameObject[numOfRecognizer];

    public static Vector3 goalPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < numOfAI; i++)
        {
            Vector3 startPosition = new Vector3(Random.Range(-startZoneSize, startZoneSize), 0 , Random.Range(-startZoneSize, startZoneSize));
            Quaternion startRotation = Quaternion.AngleAxis(Random.Range(-180.0f, 180.0f), Vector3.up);
            allAI[i] = (GameObject)Instantiate(LightCyclePrefab, startPosition, startRotation);
        }

        for (int i = 0; i < numOfRecognizer; i++)
        {
            Vector3 recognizerStartPosition = new Vector3(Random.Range(-recognizerFlightBoundary, recognizerFlightBoundary), 
                Random.Range(recognizerStartHeight -80, recognizerStartHeight), 
                Random.Range(-recognizerFlightBoundary, recognizerFlightBoundary));
            Quaternion startRotation = Quaternion.AngleAxis(Random.Range(-180.0f, 180.0f), Vector3.up);
            allRecognizer[i] = (GameObject)Instantiate(RecognizerPrefab, recognizerStartPosition, startRotation);
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
