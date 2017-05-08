using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inhibitors : MonoBehaviour {

    public static int health;
    public static bool active;
    
	// Use this for initialization
	void Start () {
        health = 500;
        active = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (health == 0)
        {
            active = true;
            //death
            //respawn();
        }
	}
}
