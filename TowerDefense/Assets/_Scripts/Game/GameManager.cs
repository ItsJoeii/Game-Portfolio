using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameHasEnded = false;

    public GameObject gameOverUI;
    public float delayGame = 5f;

    public GameObject CompleteLevelUI;

	// Update is called once per frame
	void Update ()
    {
        if (gameHasEnded)
            return;

        //If the player lives is less than 0 the game will end and the player lost the game
		if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
	}

    void EndGame()
    {
        //Sets the boolean gameHasEnded to true and sets the gameobject gameOverUI to true. It will then plays a sound clip and then it will freeze the game
        gameHasEnded = true;
        gameOverUI.SetActive(true);

        FindObjectOfType<AudioManager>().Play("GameOverSound");

        Time.timeScale = 0f;

        //StartCoroutine(DelayGameRunTime());
    }

    //IEnumerator DelayGameRunTime()
    //{
    //    yield return new WaitForSeconds(delayGame);
    //    Time.timeScale = 0f;
    //}

    public void LevelWon()
    {
        gameHasEnded = true;

        FindObjectOfType<AudioManager>().Play("WinSound");

        Time.timeScale = 0f;

        //Sets the CompleteLevelUI gameobject to true
        CompleteLevelUI.SetActive(true);
    }

}
