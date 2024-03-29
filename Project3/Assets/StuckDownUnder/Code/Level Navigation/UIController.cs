using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public GameObject pausePanel;
    public GameObject pauseScreen;
    private bool isPaused = false;

    void Start()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

    void Update()
    {
        // Check if current scene is not Scene 1
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                isPaused = !isPaused;

                if (isPaused)
                {
                    Pause();
                }
                else
                {
                    Resume();
                }
            }
        }
    }

    void Pause()
    {
        // Pause the game
        Time.timeScale = 0f;

        // Show the pause panel
        if (pausePanel != null)
        {
            pausePanel.SetActive(true);
        }

        if (pauseScreen != null)
        {
            pauseScreen.SetActive(true);
        }
    }

    void Resume()
    {
        // Unpause the game
        Time.timeScale = 1f;

        // Hide the pause panel
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }

        if (pauseScreen != null)
        {
            pauseScreen.SetActive(false);
        }

        isPaused = false;
    }
}
