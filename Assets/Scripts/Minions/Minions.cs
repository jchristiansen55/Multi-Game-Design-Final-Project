using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions : MonoBehaviour {

    public static float health;
    public static int level; //To Scale up overtime
    public static int autoAttack;
    public static int attackSpeed;
    public static int expWorth; //exp awarded when killed to scale with level for catch up mechanic?
    public static int goldWorth;

    public int startHealth = 35;
    public int startAA = 7;

    // Use this for initialization
    void Start ()
    {
        health = startHealth;
        level = 1;
        goldWorth = 20;
        autoAttack = startAA;
    }
    public void TakeDamage(float amount)
    {
        Debug.Log(health + "?");
        health -= amount;
        Debug.Log(health + "hi");

        if (health <= 0)
        {
            Die();
            Debug.Log(health);
            //PlayerStats.Money += 10;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update ()
    {

    }
}
