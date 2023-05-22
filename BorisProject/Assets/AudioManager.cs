using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour{

    public Sound[] sounds;
    Sound s;

    // Start is called before the first frame update
    void Awake ()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

     
    }

    public void PlaySound (string name)
    {
        s = Array.Find( sounds, sound => sound.name == name);
        //s.source.Play();
    }

    public void StopSound()
    {
        //s.source.Stop();
    }
}
