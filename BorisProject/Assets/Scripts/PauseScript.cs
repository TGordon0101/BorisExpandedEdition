using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject resumeButton;
    public GameObject quitButton;
    public GameObject UI;
    public bool paused;

    public void Start()
    {
        resumeButton = GameObject.Find("Resume");
        quitButton = GameObject.Find("Quit");
        UI = GameObject.Find("Menu");

        UI.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(paused)
            {
                ResumeGame();

            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        UI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void ResumeGame()
    {
        UI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void QuitGame()
    {
        UI.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
