using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject YouWin_Obj;
    public GameObject YouLose_Obj;
    public GameObject Buttons_Obj;

    public GameObject transition;

    void Start()
    {
        YouWin_Obj = GameObject.Find("You Win Text");
        YouLose_Obj = GameObject.Find("You Lose Text");
        Buttons_Obj = GameObject.Find("Buttons");

       // UI_Obj.SetActive(false);
        YouWin_Obj.SetActive(false);
        YouLose_Obj.SetActive(false);
        Buttons_Obj.SetActive(false);

        transition = GameObject.Find("Transition Canvas");
    }

    public void RetryGame()
    {
        transition.GetComponent<Transition>().LoadLevel(1);
    }

    public void ExitGame()
    {
        transition.GetComponent<Transition>().SetTrigger();
    }

    public void YouLose()
    {
        YouLose_Obj.SetActive(true);
        Buttons_Obj.SetActive(true);
    }

    public void YouWin()
    {
        YouWin_Obj.SetActive(true);
        Buttons_Obj.SetActive(true);
    }
}
