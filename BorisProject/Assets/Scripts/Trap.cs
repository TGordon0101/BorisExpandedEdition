using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] public bool primed;
    [SerializeField] public bool endGame;
    [SerializeField] public GameObject UI;

    private void Start()
    {
        primed = false;
        UI = GameObject.Find("UI");
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
                UI.GetComponent<InventoryUI>().DisableUI();
            }
        }
    }
}
