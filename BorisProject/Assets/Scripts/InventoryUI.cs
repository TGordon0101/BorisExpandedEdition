using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Sprite tempSprite;
    [SerializeField] PlayerController playerObj;

    [SerializeField] Image uiSpriteOne;
    [SerializeField] Image uiSpriteTwo;
    [SerializeField] Image uiSpriteThree;

    void Start()
    {
        uiSpriteOne = GameObject.Find("Type 1").GetComponent<Image>();
        uiSpriteTwo = GameObject.Find("Type 2").GetComponent<Image>();
        uiSpriteThree = GameObject.Find("Type 3").GetComponent<Image>();

        playerObj = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update()
    {
        uiSpriteOne.overrideSprite = playerObj.itemOne.GetComponent<SpriteRenderer>().GetComponent<Sprite>();
    }
}
