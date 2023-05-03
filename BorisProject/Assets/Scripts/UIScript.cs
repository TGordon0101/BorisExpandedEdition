using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject YouWin_Obj;
    public GameObject YouLose_Obj;
    public GameObject Buttons_Obj;

    public GameManager GM_Obj;

    void Start()
    {
        YouWin_Obj = GameObject.Find("You Win Text");
        YouLose_Obj = GameObject.Find("You Lose Text");
        Buttons_Obj = GameObject.Find("Buttons");
        GM_Obj = GameObject.Find("GameTrigger").GetComponent<GameManager>();

       // UI_Obj.SetActive(false);
        YouWin_Obj.SetActive(false);
        YouLose_Obj.SetActive(false);
        Buttons_Obj.SetActive(false);
    }


    void Update()
    {
        if(GM_Obj.b_GameEnd == true)
        {
            YouWin_Obj.SetActive(true);
            Buttons_Obj.SetActive(true);
        }
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
