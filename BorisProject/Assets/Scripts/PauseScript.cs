using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject resumeButton;
    public GameObject quitButton;

    public void Start()
    {
        resumeButton = GameObject.Find("Resume");
        quitButton = GameObject.Find("Quit");

        resumeButton.SetActive(false);
        quitButton.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1) 
        {
            PauseGame();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;

        resumeButton.SetActive(true);
        quitButton.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;

        resumeButton.SetActive(false);
        quitButton.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
