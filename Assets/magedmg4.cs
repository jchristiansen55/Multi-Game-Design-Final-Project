using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magedmg4 : MonoBehaviour {

    private Minions tar;

    public float AbilityDMG = 0f;
    public float AbilityRange = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Collider[] col = Physics.OverlapSphere(transform.position, AbilityRange);
        foreach (Collider hit in col)
        {
            tar = hit.GetComponent<Minions>();
            if (hit.tag == "Blue")
            {
                if (tar != null)
                {
                    tar.TakeDamage(AbilityDMG);
                }
            }
        }
    }
}
