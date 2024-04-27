using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
     public GameObject pauseScreen;
     bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused) //|| Input.GetButtonDown("Pause") && !isPaused)
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
            isPaused = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused) //|| Input.GetButtonDown("Pause") && isPaused)
        {
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
            isPaused = false;
        }
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameEnd()
    {
        if(!CheatManager.perma)
        {
            SceneManager.LoadScene(0);
        }
    }
}
