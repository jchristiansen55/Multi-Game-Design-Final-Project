﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionHealth : MonoBehaviour {
    
    public float TotalHp;
    public float CurrentHp;

	// Use this for initialization
	void Start () {
        CurrentHp = TotalHp;

	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage();
        }
        
	}
    void TakeDamage()
    {
        CurrentHp -= 5;
        transform.localScale = new Vector3((CurrentHp / TotalHp), 1, 1);

    }
}
