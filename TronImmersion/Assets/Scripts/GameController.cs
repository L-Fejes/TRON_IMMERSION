using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour{
    
    public GameObject m_grid;
    public GameObject m_player;
    public GameObject m_challenger;
    public GameObject[] m_walls;

    private bool m_gameOver;

    void Awake() {
        m_gameOver = false;

    }

    void LateUpdate()
    {
        if (m_player == null) {
            //Lose();
            m_gameOver = true;
        }

        if (m_challenger == null) {
            //Win();
            m_gameOver = false;
        }
    }

}