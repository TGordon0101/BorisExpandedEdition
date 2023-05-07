using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private string objectName;
    [SerializeField] private SpriteRenderer objectRender;

    [SerializeField] private Sprite candleSprite;
    [SerializeField] private Sprite bookSprite;
    [SerializeField] private Sprite saltSprite;

    // Start is called before the first frame update
    void Start()
    {
        if (objectName == "Candle")
        {
            objectRender.sprite = candleSprite;
        }

        else if (objectName == "Salt")
        {
            objectRender.sprite = saltSprite;
        }

        else if (objectName == "Book")
        {
            objectRender.sprite = bookSprite;
        }

        else
        {
            objectRender.sprite = null;
        }

        this.gameObject.name = "Obtainable: " + objectName ;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
}
