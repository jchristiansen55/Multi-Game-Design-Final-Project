using UnityEngine;
using System.Collections;

public class MinionAttack : MonoBehaviour
{

    public Transform target;
	private Minions targetEnemy;

    public float speed = 10f;

    private Transform wayp;
    private int wavepointIndex = 0;
    public float aggroRange = 30f;
    public float range = 10f;

    public bool walk;
    public bool kill = false;

    //public GameObject bulletPrefab;
    public float damage = 10f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public string enemyTag = "Red";

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        wayp = Waypoints.points[0];
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            walk = false;
            targetEnemy = nearestEnemy.GetComponent<Minions>();
            kill = true;
            while (shortestDistance >= range)
            {
                
            }
        }
        else
        {
            target = null;
            walk = true;
            kill = false;
        }
    }

    void Update()
    {
        // if (GetComponent.
        if (walk) {
            Vector3 dir = wayp.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime);
        }
        if (kill)
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }

    }
    
    void Shoot ()
    {
        targetEnemy.TakeDamage(damage);
        Debug.Log("DMG'D MINION");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}