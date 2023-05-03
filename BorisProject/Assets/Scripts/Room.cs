using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer[] m_spriteRenderers;
    public float alpha = 1.0f;
    private bool increaseAlpha = false;
    private bool decreaseAlpha = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        for (int i = 0; i < m_spriteRenderers.Length; i++)
        {
            m_spriteRenderers[i].color = new Color(0, 0, 0, alpha);

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
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            increaseAlpha = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            decreaseAlpha = true;
        }
    }

    private void AlphaUp()
    {
        alpha += 0.01f;
    }

    private void AlphaDown()
    {
        alpha -= 0.01f;
    }
}
