using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuetralCreeps : MonoBehaviour {

    public static int health;
    public static int level; //To Scale up jungle creeps overtime
    public static int autoAttack;
    public static int attackSpeed;
    public static int expWorth; //exp awarded when killed to scale with level for catch up mechanic?
    public static int goldWorth;

    public int startHealth = 50;
    public int startAA = 10;

    // Use this for initialization
    void Start()
    {
        health = startHealth;
        level = 1;
        goldWorth = 30;
        autoAttack = startAA;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            //Maybe if statement to give specific champ gold for last hit?
            //Death
        }
    }
}
