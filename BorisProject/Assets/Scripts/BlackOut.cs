using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlackOut : MonoBehaviour
{
    [SerializeField] private Tilemap m_tilemap;
    [SerializeField] private float alpha = 1.0f;
    [SerializeField] private bool increaseAlpha = false;
    [SerializeField] private bool decreaseAlpha = false;

    private void Start()
    {
        m_tilemap = GetComponent<Tilemap>();
    }

    private void Update()
    {
        if (increaseAlpha)
        {
            if (alpha < 1.0f)
            {
                AlphaUp();
            }
            else
            {
                alpha = 1.0f;
                increaseAlpha = false;
            }
        }
        else if (decreaseAlpha)
        {
            if (alpha > 0.0f)
            {
                AlphaDown();
            }
            else
            {
                alpha = 0.0f;
                decreaseAlpha = false;
            }
        }
    }

    //Player Leaves Room
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            increaseAlpha = true;
        }
    }

    //Player Enters Room
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            decreaseAlpha = true;
        }
    }

    //Increase Tile Alpha
    private void AlphaUp()
    {
        alpha += 0.01f;
        m_tilemap.color = new Color(0, 0, 0, alpha);
    }

    //Decrease Tile Alpha
    private void AlphaDown()
    {
        alpha -= 0.01f;
        m_tilemap.color = new Color(0, 0, 0, alpha);
    }
}
