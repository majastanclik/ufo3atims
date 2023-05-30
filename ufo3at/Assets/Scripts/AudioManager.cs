using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class AudioManager : MonoBehaviour
{
    public Sound[] muzyka;
    public Sound[] sfx;
 
    public AudioSource muzykaSource;
    public AudioSource sfxSource;

    public static AudioManager instance;

    private void Awake () 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else 
        {
            Destroy(gameObject);
        }
    }
 
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(muzyka, x => x.name == name);
        if(s==null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            muzykaSource.clip = s.audioClip;
            muzykaSource.Play();
        }
    }
 
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfx, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.audioClip);
        }
    }
}