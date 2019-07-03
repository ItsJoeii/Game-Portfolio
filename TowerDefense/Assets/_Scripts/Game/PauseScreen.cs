using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    //public GameObject pausePanel;
    public GameObject blurredPanel;
    public bool isPaused;

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        //If the escape or P is getting pressed down and the game is not paused, it will pause the game, set the gameobject blurredPanel to true, plays an animation and freezes the game
        //If the game is already paused it will resume the game
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                isPaused = true;
                // pausePanel.SetActive(true);
                blurredPanel.SetActive(true);
                anim.Play("IsPaused_anim");
                Time.timeScale = 0f;
            }
        }
    }

    public void ResumeGame()
    {
        //Puts the boolean isPuased to false, deactivates the blurredPanel, plays an animation and unfreezes the time
        isPaused = false;
        //pausePanel.SetActive(false);
        blurredPanel.SetActive(false);
        anim.Play("NotPaused_anim");
        Time.timeScale = 1f;
    }

    public void PauseOptions()
    {
        //Plays an animation
        anim.Play("PauseInOptions_anim");
    }

    public void BackToPause()
    {
        //Plays an animation
        anim.Play("PauseBackOptions_anim");
    }

}