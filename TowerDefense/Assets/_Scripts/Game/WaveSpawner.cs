using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Transform spawnPoint;

    public float timeBetweenWaves = 10f;
    private float countdown = 3f;
    public float spawningDelay = 0.5f;

    public Text waveCountDownText;
    public Text currentWave;
    private Text startWave;

    private int waveNumber;

    private int waveNumberUI = 1;

    public GameManager gm;

    [Header("Spawn Waves")]
    public Wave[] waves;


    void Start()
    {
        currentWave.text = "0";
        startWave = currentWave;
    }

    void Update()
    {
        //When all the enemies are dead the timer will countdown and when the timer is 0 the next wave will spawn
        if(EnemiesAlive > 0)
        {
            return;
        }

        if (waveNumber == waves.Length)
        {
            gm.LevelWon();
            this.enabled = false;
        }

        currentWave.text = "Wave: " + waveNumberUI.ToString();

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        
        waveCountDownText.text = string.Format("{0:00.00}", countdown);
    }

    //Spawns a wave every X seconds
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveNumber];

        EnemiesAlive = wave.enemyCount;

        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(spawningDelay); //or 1f / wave.enemyRate
        }

        waveNumber++;
        waveNumberUI++;
    }

    //Spawns the enemy
    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
