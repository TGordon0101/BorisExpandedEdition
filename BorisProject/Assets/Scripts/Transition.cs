using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Animator animator;
    private int leveltoLoad;

    void Update()
    {
       if(Input.GetMouseButtonDown(0))
       {
            //FadeIntoLevel(1);
       }
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
