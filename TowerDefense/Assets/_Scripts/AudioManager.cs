using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

	// Use this for initialization
	void Awake ()
    {
        if (instance == null)
            instance = this;
        else
        {
            DontDestroyOnLoad(gameObject);
            return;
        }


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = s.mixerGroup;
            s.source.clip = s.clip;

            s.source.volume = s.volume * (1 + UnityEngine.Random.Range(-s.randomVolume / 2f, s.randomVolume / 2f));
            s.source.pitch = s.pitch * (1 + UnityEngine.Random.Range(-s.randomPitch / 2f, s.randomPitch / 2f));
            s.source.playOnAwake = s.playOnAwake;
            s.source.loop = s.loop;
        }
	}

    void Start()
    {
        Play("BackgroundMusic");
    }
	
    public void Play(string name)
    {
        //Going through all the sounds
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            //If the sound is not found it will just return
            Debug.LogWarning("Audio clip: " + name + " not found!");
            return;
        }
        //Playing the sound
        s.source.Play();
    }
}
