using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class WeatherAPI : MonoBehaviour
{
    public enum CountryType { Netherlands, London, Vancouver, Sydney };
    public CountryType countryType;

    public string URL;
    private const string API_KEY = "9d555c538ff33e5450ae1575097d7b97";

    public string retrievedCountry;
    public string retrievedCity;
    public int conditionID;
    public string conditionName;

    public Slider countrySlider;
    public Text countryText, cityText, temperatureText, conditionText;

    IEnumerator Start()
    {
        switch (countryType)
        {
            case CountryType.Netherlands:
                URL = "api.openweathermap.org/data/2.5/weather?q=Amsterdam&units=metric&appid=" + API_KEY;
                break;
            case CountryType.London:
                URL = "api.openweathermap.org/data/2.5/weather?q=London&units=metric&appid=" + API_KEY;
                break;
            case CountryType.Vancouver:
                URL = "api.openweathermap.org/data/2.5/weather?q=Vancouver&units=metric&appid=" + API_KEY;
                break;
            case CountryType.Sydney:
                URL = "api.openweathermap.org/data/2.5/weather?q=Sydney&units=metric&appid=" + API_KEY;
                break;
            default:
                Debug.Log("No Country selected");
                break;

        }

        WWW request = new WWW(URL);
        yield return request;
        if (request.error == null || request.error == "")
        {
            var N = JSON.Parse(request.text);

            retrievedCountry = N["sys"]["country"].Value;
            retrievedCity = N["name"].Value;

            string temp = N["main"]["temp"].Value;
            float tempTemp;
            float.TryParse(temp, out tempTemp);
            float finalTemp = Mathf.Round(tempTemp / 100);
            Debug.Log(temp);
            Debug.Log(tempTemp);

            int.TryParse(N["weather"][0]["id"].Value, out conditionID);
            conditionName = N["weather"][0]["description"].Value;

            countryText.text = "" + retrievedCountry;
            cityText.text = "City:\n" + retrievedCity;
            temperatureText.text = "Temperature:\n" + temp + " C";
            conditionText.text = "Condition:\n" + conditionName;

            countrySlider.value = finalTemp;
        }
        else
        {
            Debug.Log("WWW error: " + request.error);

        }
    }

}

// https://forum.unity.com/threads/current-weather-script.242009/ //