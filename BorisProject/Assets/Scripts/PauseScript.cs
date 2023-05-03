using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject Self;

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Self.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
