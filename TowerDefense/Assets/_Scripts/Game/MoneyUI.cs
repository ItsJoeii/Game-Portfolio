using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text goldText;

	// Update is called once per frame
	void Update () {
        //Updates the gold text
        goldText.text = PlayerStats.Money.ToString() + " gold";
		
	}
}
