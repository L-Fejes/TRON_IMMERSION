using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour{
    
    public GameObject m_grid;
    public PlayerController m_player;
    public GameObject[] m_walls;

    public bool m_gameOver;
    private bool m_winner;

    void Awake() {
        m_gameOver = false;
    }


    public void AIKilled()
    {
        Debug.Log("Someone is dead");
        
        for(int i = 0; i < AIManager.allAI.Length; i++)
        {
            if(AIManager.allAI[i].activeSelf)
            {
                return;
            }
        }

        Win();
    }

    void Win() {
        Time.timeScale = 0.0f;
        SceneManager.LoadScene("Win", LoadSceneMode.Additive);
        Time.timeScale = 1.0f;
        m_gameOver = true;
    }

    public void Lose() {
        Time.timeScale = 0.0f;
        SceneManager.LoadScene("Lose", LoadSceneMode.Additive);
        Time.timeScale = 1.0f;
        m_gameOver = true;
    }

}