using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] bool m_Display;
    [SerializeField] int ID;

    [SerializeField] GameObject TextOne;
    [SerializeField] GameObject TextTwo;
    [SerializeField] GameObject TextThree;

    public void Start()
    {
        TextOne = GameObject.Find("Text Box 1");
        TextTwo = GameObject.Find("Text Box 2");
        TextThree = GameObject.Find("Text Box 3");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        m_Display = true;

        if (col.gameObject.name == "Player")
        {
            if(ID == 1)
            {
                TextOne.SetActive(true);
            }

            if (ID == 2)
            {
                TextTwo.SetActive(true);
            }

            if (ID == 3)
            {
                TextThree.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        TextOne.SetActive(false);
        TextTwo.SetActive(false);
        TextThree.SetActive(false);

        m_Display = false;
    }
}
