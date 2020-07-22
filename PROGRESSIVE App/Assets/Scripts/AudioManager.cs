
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioManager instance;
    public Sound[] sounds;

    private void Awake()
    {
        //// CODE TO SHIFT AUDIO CLIP FROM 1 SCENE TO ANOTHER
        if (instance == null) instance = this; // create obj if it is not exist

        else { Destroy(gameObject); return; } // destroy recreated objects

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.GetComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) return; // code below wont be executed

        s.source.Play();
    }

}
