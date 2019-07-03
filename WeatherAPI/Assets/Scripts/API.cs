using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;

public class API : MonoBehaviour
{
    private const string URL = "api.openweathermap.org/data/2.5/weather?q=Amsterdam&appid=" + API_KEY;
    private const string API_KEY = "9d555c538ff33e5450ae1575097d7b97";
    public Text responseText;

    public void Request()
    {
        WWW request = new WWW(URL);
        StartCoroutine(OnResponse(request));
    }

    private IEnumerator OnResponse(WWW req)
    {
        yield return req;

        responseText.text = req.text;
    }

}
