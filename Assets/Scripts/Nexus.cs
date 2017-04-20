using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour {

    public static int health;
    
    // Use this for initialization
    void Start()
    {
        health = 750;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            //death
            //endgame
        }
    }
}
