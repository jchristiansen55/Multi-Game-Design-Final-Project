    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Minions : MonoBehaviour {

    public float startHealth = 100;
    public int level; //To Scale up overtime
    public int expWorth; //exp awarded when killed to scale with level for catch up mechanic?
    public int goldWorth;
    public bool nexus = false;

    public Image healthBar;
    
    public float currentHealth;

    // Use this for initialization
    void Start ()
    {
        currentHealth = startHealth;
        level = 1;
        goldWorth = 20;
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        
        if (currentHealth <= 0)
        {
            Die();
            //PlayerStats.Money += 10;
        }
    }

    void Die()
    {
        if (nexus)
        {
            SceneManager.LoadScene("moba");
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update ()
    {
        healthBar.rectTransform.localScale = new Vector3((currentHealth / startHealth), 1, 1);
    }
    
}
