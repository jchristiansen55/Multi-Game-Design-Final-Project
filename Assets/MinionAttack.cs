using UnityEngine;
using System.Collections;

public class MinionAttack : MonoBehaviour
{

    private Transform target;
    private Enemy targetEnemy;

    public float range = 15f;

    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public int damageOverTime = 30;
    public float slowAmount = .5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    public string enemyTag = "Red";

    public Transform firePoint;

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
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        
        if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
        fireCountdown -= Time.deltaTime;

    }

   // void Laser()
   // {
  //      targetEnemy.TakeDamage((int)(damageOverTime * Time.deltaTime * 1.75));

   //     if (!lineRenderer.enabled)
  //      {
   //         lineRenderer.enabled = true;
   //         impactEffect.Play();
   //         impactLight.enabled = true;
   //     }
//
   //     lineRenderer.SetPosition(0, firePoint.position);
   //     lineRenderer.SetPosition(1, target.position);
//
   //     Vector3 dir = firePoint.position - target.position;
//
  //      impactEffect.transform.position = target.position + dir.normalized;
  //
  //      impactEffect.transform.rotation = Quaternion.LookRotation(dir);
  //  }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Bullet bullet = bulletGO.GetComponent<Bullet>();

        //if (bullet != null)
            //bullet.Seek(target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}