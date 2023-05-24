using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] public bool primed;
    [SerializeField] public bool endGame;
    [SerializeField] public GameObject UI;
    [SerializeField] public SpriteRenderer CurrentSprite;
    [SerializeField] public Sprite StartSprite;
    [SerializeField] public Sprite EndSprite;

    private void Start()
    {
        primed = false;
        UI = GameObject.Find("UI");
        CurrentSprite.sprite = StartSprite;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerController>().itemOne != null &&
                collision.gameObject.GetComponent<PlayerController>().itemTwo != null &&
                collision.gameObject.GetComponent<PlayerController>().itemThree != null)
            {
                CurrentSprite.sprite = EndSprite;
                primed = true;
                UI.GetComponent<InventoryUI>().DisableUI();
            }
        }
    }

    public void ShowHint()
    {
        UI.GetComponent<InventoryUI>().ShowText();
    }

    public void DisableHint()
    {
        UI.GetComponent<InventoryUI>().HideText();
    }
}
