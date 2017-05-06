using UnityEngine;
using System.Collections;

public class MinionAttack : MonoBehaviour
{

    public Transform target;


    public float speed = 10f;

    private Transform wayp;
    private int wavepointIndex = 0;
    public float range = 15f;

    public bool walk;
    
    //public GameObject bulletPrefab;
    //public float fireRate = 1f;
    //private float fireCountdown = 0f;

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
            //targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
            walk = true;
        }
    }

    void Update()
    {
        // if (GetComponent.
        if (walk) {
               Vector3 dir = wayp.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}