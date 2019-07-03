using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelecter : MonoBehaviour
{
    public Button[] levelButtons;

    int levelReached;

    void Start()
    {
        //TODO: SERIALIZATION
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelReached)
            levelButtons[i].interactable = false;
        }
    }

    public void Select(string Levelname)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Levelname);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

}
