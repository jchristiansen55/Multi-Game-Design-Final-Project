using UnityEngine;
using System.Collections;

public class JungleAttack : MonoBehaviour
{
    public Transform partToRotate;
    private Transform target;
    private Minions targetEnemy;

    public GameObject misslePrefab;
    public GameObject firePoint;

    public float speed = 10f;

    public float aggroRange = 40f;
    public float range = 40;


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

            targetEnemy = nearestEnemy.GetComponent<Minions>();
            kill = true;
            while (shortestDistance >= range)
            {

            }
        }
        else
        {
            target = null;

            kill = false;
        }
    }

    void Update()
    {
        // if (GetComponent.
        LockOnTarget();
        if (kill)
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 10f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }


    }

    void Shoot()
    {
        targetEnemy.TakeDamage(damage);

        GameObject bulletGO = (GameObject)Instantiate(misslePrefab, firePoint.transform.position, firePoint.transform.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void LockOnTarget()
    {
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * speed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}