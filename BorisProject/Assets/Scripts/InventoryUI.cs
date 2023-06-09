using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] PlayerController playerObj;

    [SerializeField] Image uiOne;
    [SerializeField] Image uiTwo;
    [SerializeField] Image uiThree;

    [SerializeField] RawImage ExhaustedSprite;
    [SerializeField] RawImage BloodSprite;

    [SerializeField] Sprite uiSpriteOne;
    [SerializeField] Sprite uiSpriteTwo;
    [SerializeField] Sprite uiSpriteThree;

    [SerializeField] GameObject TextOne;
    [SerializeField] GameObject TextTwo;
    [SerializeField] GameObject TextThree;
    [SerializeField] GameObject Hint;
    public float Timer;

    bool Cleared;


    void Start()
    {
        uiOne = GameObject.Find("Type 1").GetComponent<Image>();
        uiTwo = GameObject.Find("Type 2").GetComponent<Image>();
        uiThree = GameObject.Find("Type 3").GetComponent<Image>();

        playerObj = GameObject.Find("Player").GetComponent<PlayerController>();

        uiOne.color = Color.clear;
        uiTwo.color = Color.clear;
        uiThree.color = Color.clear;

        Hint = GameObject.Find("Hint");
        Hint.SetActive(false);

        ExhaustedSprite = GameObject.Find("ExhaustedEffect").GetComponent<RawImage>();
        BloodSprite = GameObject.Find("Blood").GetComponent<RawImage>();

        ExhaustedSprite.color = Color.clear;
        BloodSprite.color = Color.clear;

        Timer = 0f;
    }


    void Update()
    {
        ExhaustedSprite.color = new Color(255,255,255, playerObj.Exhaust / 14f);
        BloodOnScreen();

        if (playerObj.itemOne != null && Cleared == false)
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

        if (playerObj.itemTwo != null && Cleared == false)
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

        if (playerObj.itemThree != null && Cleared == false)
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

    public void DisableUI()
    {
        Cleared = true;

        uiOne.color = new Color(255, 255, 255, 0);
        uiTwo.color = new Color(255, 255, 255, 0);
        uiThree.color = new Color(255, 255, 255, 0);
    }

    public void ShowText()
    {
        Hint.SetActive(true);
    }

    public void HideText()
    {
        Hint.SetActive(false);
    }

    public void BloodOnScreen()
    {
        Timer -= 0.5f / 60f;
        BloodSprite.color = new Color(255, 255, 255, Timer);
    }

    public void ChangePos()
    {
        BloodSprite.rectTransform.position = new Vector3(Random.Range(0, 500.0f), Random.Range(0, 700.0f), 0f);
        BloodSprite.rectTransform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0, 500.0f));
    }
}
