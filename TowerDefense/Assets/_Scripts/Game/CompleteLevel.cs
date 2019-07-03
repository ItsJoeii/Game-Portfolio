using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);                  //Gives the player a key to unlock the next level
        SceneManager.LoadScene(nextLevel);                                  //Loads the next scene
    }

    public void Menu()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);                  //Gives the player a key to unlock the next level
        SceneManager.LoadScene(menuSceneName);                              //Loads the next scene
    }
}
