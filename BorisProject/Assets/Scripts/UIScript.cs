using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject YouWin_Obj;
    public GameObject YouLose_Obj;
    public GameObject Buttons_Obj;

    void Start()
    {
        YouWin_Obj = GameObject.Find("You Win Text");
        YouLose_Obj = GameObject.Find("You Lose Text");
        Buttons_Obj = GameObject.Find("Buttons");

       // UI_Obj.SetActive(false);
        YouWin_Obj.SetActive(false);
        YouLose_Obj.SetActive(false);
        Buttons_Obj.SetActive(false);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void YouLose()
    {
        YouLose_Obj.SetActive(true);
        Buttons_Obj.SetActive(true);
    }
}
