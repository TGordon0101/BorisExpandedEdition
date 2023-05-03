using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LightManager m_lightManager;
    public GameObject Player_Obj;
    public AI AI_Script_Obj;

    public AudioSource AmbientMusic;
    public AudioSource ChaseMusic;
    public AudioSource ChaseHeartBeat;

    public bool b_ChaseState;
    public bool b_GameEnd;
    public bool b_HasKey;

    void Start()
    {
        Player_Obj = GameObject.Find("Player");
        m_lightManager = GameObject.Find("Light Manager").GetComponent<LightManager>();
        AmbientMusic.Play();
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
                for (int i = 0; i < m_lightManager.GetLights().Length; i++)
                {
                    m_lightManager.GetLights()[i].GetComponent<LightChange>().ToggleLightColor();
                }
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