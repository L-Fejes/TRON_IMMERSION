using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour{
    
    public GameObject m_grid;
    public GameObject m_player;
    public GameObject m_challenger;
    public GameObject[] m_walls;

    private bool m_gameOver;
    private bool m_winner;

    void Awake() {
        m_gameOver = false;
    }

    void Update()
    {
        if (m_player) {
           m_winner = true;
           GameOver(m_winner);
        }

        if (m_challenger == null && m_player != null) {
            m_winner = false;
            GameOver(m_winner);
        }
    }

    public void GameOver(bool win) {
        Debug.Log("Someone is dead");
        if (win) {
            Win();
        } else {
            Lose();
        }

    }

    void Win() {
        SceneManager.LoadScene("Win", LoadSceneMode.Additive);
        m_gameOver = true;
    }

    void Lose() {
        SceneManager.LoadScene("Lose", LoadSceneMode.Additive);
        m_gameOver = true;
    }

}