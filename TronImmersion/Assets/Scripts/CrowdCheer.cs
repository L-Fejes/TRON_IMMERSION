using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class CrowdCheer : MonoBehaviour {

    public AudioSource m_audio;
    GameObject m_me;

    void Start() {
        m_me = this.gameObject;
        //m_audio.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"));
        {
            m_audio.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"));
        {
            m_audio.Stop();
        }
    }

}