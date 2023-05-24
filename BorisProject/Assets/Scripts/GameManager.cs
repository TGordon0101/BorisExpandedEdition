using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private LightManager m_lightManager;
    public GameObject Player_Obj;
    public AI AI_Script_Obj;
    public Trap Trap_obj;
    public UIScript UI_obj;

    public AudioSource AmbientMusic;
    public AudioSource ChaseMusic;
    public AudioSource ChaseHeartBeat;

    public bool b_ChaseState;
    public bool b_GameEnd;
    public bool b_HasKey;

    void Start()
    {
        Player_Obj = GameObject.Find("Player");
       // m_lightManager = GameObject.Find("LightManager 1").GetComponent<LightManager>();
        Trap_obj = GameObject.Find("Summon Trap").GetComponent<Trap>();
        UI_obj = GameObject.Find("EndGameCanvas").GetComponent<UIScript>();
        AI_Script_Obj = GameObject.Find("Monster").GetComponent<AI>();

        FindObjectOfType<AudioManager>().PlaySound("Amdience_Music");

        AmbientMusic.Play();
    }

    public void Update()
    {
        if (Trap_obj.endGame == true)
        {
            UI_obj.YouWin_Obj.SetActive(true);
            UI_obj.Buttons_Obj.SetActive(true);

            AI_Script_Obj.SetBoolChase(false);
            Time.timeScale = 0f;
        }

        if (Player_Obj.GetComponent<PlayerController>().b_playerDead == true)
        {
            UI_obj.YouLose_Obj.SetActive(true);
            UI_obj.Buttons_Obj.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        AmbientMusic.Stop();
        ChaseMusic.Play();
        ChaseHeartBeat.Play();

        if (col.gameObject.name == "Player")
        {
            if(!b_ChaseState)
            {
                //for (int i = 0; i < m_lightManager.GetLights().Length; i++)
                //{
                //    m_lightManager.GetLights()[i].GetComponent<LightChange>().ToggleLightColor();
                //}
            }

            b_ChaseState = true;
            AI_Script_Obj.SetBoolChase(true);
        }
    }

    public void SetGameEnd(bool _EndGameBool)
    {
        b_GameEnd = _EndGameBool;
    }

    public void SetKey(bool _SetKeyBool)
    {
        b_HasKey = _SetKeyBool;
    }
}