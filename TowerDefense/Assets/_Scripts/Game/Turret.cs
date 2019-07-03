using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]
    public float range = 15f;

    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;

    public int damageOverTime = 30;
    public float slowPercentage = .5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactParticle;
    public Light impactLight;

    [Header("Unity Setup")]

    public string enemyTag = "Enemy";

    public Transform rotateHead;
    public float turretTurnSpeed = 10f;

    public Transform firePoint;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            //Shoots at the nearest enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            //Updates the turret if there is another enemy in his range
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //If there is no enemy the laser stops shooting
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactParticle.Stop();
                    impactLight.enabled = false;
                }
            }

            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            //Turret uses the laser
            Laser();
        }
        else
        {
            //If the turret is not using a laser it will shoot a bullet or missle
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }



    void LockOnTarget()
    {
        //Follows the target current position
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotateHead.rotation, lookRotation, Time.deltaTime * turretTurnSpeed).eulerAngles;
        rotateHead.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        //Enemy takes damage over time
        targetEnemy.DamageTaken(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPercentage);

        if (!lineRenderer.enabled)
        {
            //enables the lineRenderer and plays a particle and light
            lineRenderer.enabled = true;
            impactParticle.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        //Shoots from this position
        Vector3 dir = firePoint.position - target.position;

        //Position of the particle
        impactParticle.transform.position = target.position + dir.normalized;

        impactParticle.transform.rotation = Quaternion.LookRotation(dir);

        FindObjectOfType<AudioManager>().Play("LaserBeam");
    }

    void Shoot()
    {
        //Shoots the bullet
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        FindObjectOfType<AudioManager>().Play("NormalShot");

        if (bullet != null)
            bullet.Seek(target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
