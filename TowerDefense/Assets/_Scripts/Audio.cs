using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip audioClip;

    public AudioSource source;
    public float volLowRange = 1f;
    public float volHighRange = 1f;

	// Use this for initialization
	void Awake ()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(audioClip, vol);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
