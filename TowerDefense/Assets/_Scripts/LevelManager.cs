using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject areYouSurePanel;

    public void ChangeScene(string Levelname)
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene (Levelname);
    }

    public void Retry()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AreYouSure()
    {
        areYouSurePanel.SetActive(true);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
		Application.Quit();
        #endif
    }

    public void NoQuitGame()
    {
        areYouSurePanel.SetActive(false);
    }

    public void ResetGameLevels()
    {
        PlayerPrefs.SetInt("levelReached", 1);
    }

}
