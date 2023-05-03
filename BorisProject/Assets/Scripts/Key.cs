using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject Player_Obj; 
    public GameManager GM_Obj;
    public GameObject Self;

    // Start is called before the first frame update
    void Start()
    {
        Player_Obj = GameObject.Find("Player");
        GM_Obj = GameObject.Find("GameTrigger").GetComponent<GameManager>();
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GM_Obj.SetKey(true);
            this.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void Destroy()
    {
        throw new NotImplementedException();
    }
}
