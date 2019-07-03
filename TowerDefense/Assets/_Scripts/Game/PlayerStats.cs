using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 150;

    public static int Lives;
    public int startLives = 50;

    public static int Rounds;

    public bool isSpedUp = false;

    //public GameObject shopUI;

    // Use this for initialization
    void Start ()
    {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            Money += 9999;
        }
        //if (Input.GetKeyDown("s"))
        //{
        //    shopUI.SetActive(true);
        //}
        //if (Input.GetKeyDown("d"))
        //{
        //    shopUI.SetActive(false);
        //}
    }

    public void Speedup()
    {
        //Speeds up the game by 2 times and if it is already sped up it will just put it on Time.timeScale = 1f;
        if (isSpedUp == false)
        {
            Time.timeScale = 2f;

            isSpedUp = true;
        }
        else
        {
            Time.timeScale = 1f;
            isSpedUp = false;
        }
    }

}
