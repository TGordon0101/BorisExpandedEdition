using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] string objectName;
    [SerializeField] public SpriteRenderer objectRender;

    [SerializeField] public Sprite candleSprite;
    [SerializeField] public Sprite bookSprite;
    [SerializeField] public Sprite saltSprite;

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

    public Sprite ReturnSprite()
    {
        return objectRender.GetComponent<Sprite>();
    }
}
