using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsPanel : MonoBehaviour
{
    public GameObject optionsPanel;

    public Animator anim;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    //Animates going to the options menu
    public void GoToOptions()
    {
        //optionsPanel.SetActive(true);
        anim.Play("Options_anim");
    }

    //Animates going back to the Main menu
    public void GoAwayFromOptions()
    {
        anim.Play("NoOptions_anim");
    }

}
