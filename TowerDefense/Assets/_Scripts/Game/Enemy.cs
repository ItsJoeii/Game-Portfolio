using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //Enemy Stats
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public int damageToPlayer;

    public float startHealth = 100f;
    private float currentHealth;

    public int goldWorth = 30;
    public GameObject deathParticle;

    [Header("Unity")]
    public Image healthBar;

    private bool isDead = false;

    void Start()
    {
        speed = startSpeed;
        currentHealth = startHealth;
    }

    public void DamageTaken(float amount)
    {
        //Enemy takes X amount of damage and that goes off his health bar
        currentHealth -= amount;

        healthBar.fillAmount = currentHealth / startHealth;

        //If the Health is below 0 and the boolean isDead is true the enemy will die
        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float percentage)
    {
        //THe enemy gets slowed
        speed = startSpeed * (1 - percentage);
    }

    void Die()
    {
        //Sets the boolean isDead to true
        isDead = true;

        //The player gets gold
        PlayerStats.Money += goldWorth;

        //It spawns a particlesystem in the game where the enemy died and destroys itself after 5 seconds
        GameObject particle = (GameObject)Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(particle, 5f);

        //Takes off 1 enemy off the enemy count
        WaveSpawner.EnemiesAlive--;

        //Destroys the enemy gameobject
        Destroy(gameObject);
    }

}
