    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minions : MonoBehaviour {

    public static float currentHealth;
    public static int level; //To Scale up overtime
    public static int expWorth; //exp awarded when killed to scale with level for catch up mechanic?
    public static int goldWorth;

    public Image healthBar;

    public float startHealth = 40;

    // Use this for initialization
    void Start ()
    {
        currentHealth = startHealth;
        level = 1;
        goldWorth = 20;
    }
    public void TakeDamage(float amount)
    {
        Debug.Log(currentHealth + "?");
        currentHealth -= amount;
        
        if (currentHealth <= 0)
        {
            Die();
            Debug.Log("Killed minion");
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
        healthBar.rectTransform.localScale = new Vector3((currentHealth / startHealth), 1, 1);
    }
    
}
