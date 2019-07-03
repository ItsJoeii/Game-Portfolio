using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;
	
	// Update is called once per frame
	void Update ()
    {
        //Updates the lives text
        livesText.text = "Lives: " + PlayerStats.Lives.ToString();
	}
}
