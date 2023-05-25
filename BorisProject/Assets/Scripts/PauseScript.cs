using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject resumeButton;
    public GameObject quitButton;
    public GameObject UI;
    public GameObject transition;
    public bool paused;

    public void Start()
    {
        resumeButton = GameObject.Find("Resume");
        quitButton = GameObject.Find("Quit");
        UI = GameObject.Find("Menu");
        transition = GameObject.Find("Transition Canvas");

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

    public void RetryGame()
    {
        UI.SetActive(false);
        Time.timeScale = 1f;
        transition.GetComponent<Transition>().SetTrigger();
    }
}
