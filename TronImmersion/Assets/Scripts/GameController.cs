using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour{
    
    public GameObject m_grid;
    public PlayerController m_player;
    public AIController m_challenger;
    public GameObject[] m_walls;

    public bool m_gameOver;
    private bool m_winner;

    void Awake() {
        m_gameOver = false;
    }

    /*void Update()
    {
        if (m_player.m_isAlive && !m_challenger.m_isAlive) {
            m_winner = true;
            GameOver(m_winner);
        }

        if (m_challenger.m_isAlive && !m_player.m_isAlive) {
            m_winner = false;
            GameOver(m_winner);
        }
    } */

    public void GameOver(bool win) {
        Debug.Log("Someone is dead");
        if (win) {
            Win();
        } else {
            Lose();
        }

    }

    void Win() {
        Time.timeScale = 0.0f;
        SceneManager.LoadScene("Win", LoadSceneMode.Additive);
        Time.timeScale = 1.0f;
        m_gameOver = true;
    }

    void Lose() {
        Time.timeScale = 0.0f;
        SceneManager.LoadScene("Lose", LoadSceneMode.Additive);
        Time.timeScale = 1.0f;
        m_gameOver = true;
    }

}