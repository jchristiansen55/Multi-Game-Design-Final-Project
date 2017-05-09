using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionHealth : MonoBehaviour {
    
    public float TotalHp;
    public float CurrentHp;

	// Use this for initialization
	void Start () {
        CurrentHp = Minions.currentHealth;

	}

    // Update is called once per frame
    void Update()
    {
        
	}
    void TakeDamage()
    {
        transform.localScale = new Vector3((CurrentHp / TotalHp), 1, 1);

    }
}
