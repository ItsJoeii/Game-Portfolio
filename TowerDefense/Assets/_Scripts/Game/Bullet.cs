using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int damage = 50;
    public float explosionRadius = 0f;
    public GameObject impactParticle;

    public void Seek(Transform _target)
    {
        target = _target;
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	 
	// Update is called once per frame
	void Update ()
    {
		if (target == null)
        {
            //If there is no target the bullet disappears
            Destroy(gameObject);
            return;
        }

        //Follows the enemy
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        //Turns to the direction of the enemy
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
	}

    void HitTarget()
    {
        //Particle gets activated and destroys itself after 5 seconds
        GameObject effectIns = (GameObject)Instantiate(impactParticle, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        //If there is a explosionRadius it will shoot a missle, otherwise it will shoot a bullet
        if(explosionRadius > 0f)
        {
            Explode();
            FindObjectOfType<AudioManager>().Play("MissleShot");                //Sound
        }
        else
        {
            Damage(target);
            FindObjectOfType<AudioManager>().Play("EnemyDeath");                //Sound
        }
        //Destroy(target.gameObject);
        Destroy(gameObject);
    }

    void Explode()
    {
        //Missle explodes and damages the enemies inside the sphere
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemyGO)
    {
        //Enwmy gets damaged
        Enemy enemy = enemyGO.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.DamageTaken(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        //It shows the explosionRadius of the missle
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
