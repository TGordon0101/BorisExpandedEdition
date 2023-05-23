using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Animator animator;
    private int leveltoLoad;
    public Image FadeBlack;

    void Update()
    {
       if(Input.GetMouseButtonDown(0))
       {
            //FadeIntoLevel(1);
       }
    }

    private void Start()
    {
        FadeBlack.color = new Color(255, 255, 255, 0);
    }

    public void FadeIntoLevel(int _levelIndex)
    {
        Time.timeScale = 1f;
        leveltoLoad = _levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(leveltoLoad);
    }
}
