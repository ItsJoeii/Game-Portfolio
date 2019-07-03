using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;                     //Name of the audio clip

    public AudioMixerGroup mixerGroup;      //Audiomixer output

    public AudioClip clip;                  //Put your audioclip here

    [Range(0f, 1f)]
    public float volume;                    //Change the volume
    [Range(.5f, 3f)]
    public float pitch;                     //Change the pitch

    [Range(0f, .5f)]
    public float randomVolume = 0.1f;       //Random Volume
    [Range(0f, .5f)]
    public float randomPitch = 0.1f;        //Random Pitch

    public bool playOnAwake;                //Play sound if the game just started

    public bool loop;                       //Loop the audio clip if it's true

    [HideInInspector]
    public AudioSource source;              //Source of the audio

    void Start()
    {
        source.outputAudioMixerGroup = mixerGroup;
        source.playOnAwake = playOnAwake;
    }
}
