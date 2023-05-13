using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] PlayerController playerObj;

    [SerializeField] Image uiOne;
    [SerializeField] Image uiTwo;
    [SerializeField] Image uiThree;

    [SerializeField] Sprite uiSpriteOne;
    [SerializeField] Sprite uiSpriteTwo;
    [SerializeField] Sprite uiSpriteThree;

    void Start()
    {
        uiOne = GameObject.Find("Type 1").GetComponent<Image>();
        uiTwo = GameObject.Find("Type 2").GetComponent<Image>();
        uiThree = GameObject.Find("Type 3").GetComponent<Image>();

        playerObj = GameObject.Find("Player").GetComponent<PlayerController>();

        uiOne.color = Color.clear;
        uiTwo.color = Color.clear;
        uiThree.color = Color.clear;
    }


    void Update()
    {
        if (playerObj.itemOne != null)
        {
            if (playerObj.itemOne.objectName == "Candle")
            {
                uiOne.overrideSprite = uiSpriteOne;
                uiOne.color = new Color(255, 255, 255, 255);
            }

            if (playerObj.itemOne.objectName == "Book")
            {
                uiOne.overrideSprite = uiSpriteTwo;
                uiOne.color = new Color(255, 255, 255, 255);
            }

            if (playerObj.itemOne.objectName == "Salt")
            {
                uiOne.overrideSprite = uiSpriteThree;
                uiOne.color = new Color(255, 255, 255, 255);
            }
        }


        if (playerObj.itemTwo != null)
        {
            if (playerObj.itemTwo.objectName == "Candle")
            {
                uiTwo.overrideSprite = uiSpriteOne;
                uiTwo.color = new Color(255, 255, 255, 255);
            }

            if (playerObj.itemTwo.objectName == "Book")
            {
                uiTwo.overrideSprite = uiSpriteTwo;
                uiTwo.color = new Color(255, 255, 255, 255);
            }

            if (playerObj.itemTwo.objectName == "Salt")
            {
                uiTwo.overrideSprite = uiSpriteThree;
                uiTwo.color = new Color(255, 255, 255, 255);
            }
        }



        if (playerObj.itemThree != null)
        {
            if (playerObj.itemThree.objectName == "Candle")
            {
                uiThree.overrideSprite = uiSpriteOne;
                uiThree.color = new Color(255, 255, 255, 255);
            }

            if (playerObj.itemThree.objectName == "Book")
            {
                uiThree.overrideSprite = uiSpriteTwo;
                uiThree.color = new Color(255, 255, 255, 255);
            }

            if (playerObj.itemThree.objectName == "Salt")
            {
                uiThree.overrideSprite = uiSpriteThree;
                uiThree.color = new Color(255, 255, 255, 255);
            }
        }
    }
}
