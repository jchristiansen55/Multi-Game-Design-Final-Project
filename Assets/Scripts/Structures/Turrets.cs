using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour {

    public static int health;
    public static int autoAttack;
    public static int attackSpeed;
    public static bool active;

    public int startAA = 15;

    // Use this for initialization
    void Start()
    {
        health = 750;
        active = false;
        autoAttack = startAA;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            active = true;
            //death
        }
    }
}
