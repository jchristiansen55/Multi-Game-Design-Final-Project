using UnityEngine;
using System.Collections;

public class MinionAttack : MonoBehaviour
{

    public Transform target;
    private Minions targetEnemy;

    public float speed = 10f;

    private Transform wayp;
    public int wavepointIndex = 2;
    public float aggroRange = 30f;
    public float range = 15f;
    private Animator anim;
    public bool walk;
    public bool aggro;
    public bool kill = false;

    //public GameObject bulletPrefab;
    public float damage = 10f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public string enemyTag = "Red";

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        wayp = Waypoints.points[wavepointIndex];
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

        if (nearestEnemy != null && shortestDistance <= aggroRange)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Minions>();
            walk = false;
            aggro = true;
            if (nearestEnemy != null && shortestDistance <= range)
            {
                kill = true;
                aggro = false;
            }
        }
        else
        {
            target = null;
            walk = true;
            aggro = false;
            kill = false;
        }
    }

    void Update()
    {
        // if (GetComponent.
        if (walk)
        {
            Vector3 dir = wayp.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime);
        }
        if (aggro)
        {
            // Vector3.MoveTowards(transform.position, targetEnemy.transform.position , speed * Time.deltaTime);

            Vector3 dir = targetEnemy.transform.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime);
        }
        if (kill)
        {

            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 10f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
        isDying();

    }


    void isDying()
    {
        if (GetComponent<Minions>().currentHealth <= 0)
        {

            anim.SetBool("death", true);

            Destroy(gameObject, 1f);

        }

    }

    private void OnDestroy()
    {
        ScoreManager.redCS += 1;
        ScoreManager.redValue += 25;
    }
    void Shoot()
    {
        anim.SetBool("shoot", true);
        targetEnemy.TakeDamage(damage);
        Debug.Log("DMG'D MINION");
        anim.SetBool("shoot", false);

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}