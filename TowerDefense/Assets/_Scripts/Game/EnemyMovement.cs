using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        //Make it so you can access the enemy script
        enemy = GetComponent<Enemy>();
        //Enemy goes to the first waypoint
        target = Waypoints.points[0];
    }

    void Update()
    {
        //ENemy walks towards the waypoint
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        //When the distance is less than 0.4f it will go to the next way point
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }

        //enemies speed is the same as the startSpeed
        enemy.speed = enemy.startSpeed;
    }

    void GetNextWayPoint()
    {
        //Goes to the next waypoint
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        //When the enemy reaches the end of the path it will take off X amount of Health off the player and destroys itself
        PlayerStats.Lives = PlayerStats.Lives - enemy.damageToPlayer;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

}
