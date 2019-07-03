using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}

    public void ChangeToSettings()
    {
        anim.Play("Settings_anim");
    }

    public void ChangeToMenu()
    {
        anim.Play("MainMenu_anim");
    }

    // Update is called once per frame
    void Update ()
    {

	}

}
