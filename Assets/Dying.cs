using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dying : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Minions>().currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
