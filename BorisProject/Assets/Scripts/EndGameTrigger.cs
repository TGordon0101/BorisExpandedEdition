using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    public GameManager GM_Obj;
    public bool b_DetectedPlayer;

    void Start()
    {
        GM_Obj = GameObject.Find("GameTrigger").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        b_DetectedPlayer = true;

        if (GM_Obj.b_ChaseState == true && GM_Obj.b_HasKey == true)
        {
            GM_Obj.SetGameEnd(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        b_DetectedPlayer = false;
    }
}
