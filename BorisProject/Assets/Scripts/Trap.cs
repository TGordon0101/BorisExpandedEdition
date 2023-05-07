using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] public bool primed;
    [SerializeField] public bool endGame;

    private void Start()
    {
        primed = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerController>().itemOne != null &&
                collision.gameObject.GetComponent<PlayerController>().itemTwo != null &&
                collision.gameObject.GetComponent<PlayerController>().itemThree != null)
            {
                primed = true;
            }

            endGame = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            if (primed == true)
            {

            }

            endGame = true;
        }

    }
}
