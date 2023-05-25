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
    public AudioSource MenuClick;
    public AudioSource MenuMuic;

    void Update()
    {
       if(Input.GetMouseButtonDown(0))
       {
            
       }
    }

    private void Start()
    {
        FadeBlack = GameObject.Find("BlackFade").GetComponent<Image>();
        //if(FadeBlack != null ) {
            FadeBlack.color = new Color(255, 255, 255, 0);
       // }
        
        if (FadeBlack.color.a <= 0)
        {
            FadeBlack.color = new Color(255, 255, 255, 0);
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

    public void PlaySoundEffect()
    {
        float startVolume = MenuMuic.volume;

        while (MenuMuic.volume > 0)
        {
            MenuMuic.volume -= startVolume -= 0.001f;
        }

        //MenuMuic.Stop();
        //MenuMuic.volume = startVolume;

        MenuClick.Play();
    }

    public void SetTrigger()
    {
        animator.SetTrigger("FadeOut");
    }

    public void LoadLevel(int x)
    {
        FadeIntoLevel(x);
    }
}
