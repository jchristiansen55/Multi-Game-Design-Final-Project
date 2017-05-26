using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magedmg1 : MonoBehaviour {

	private Minions tar;

	public float AbilityDMG = 0f;
	public Collider boxCollider;  
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		Collider[] col = Physics.OverlapBox (boxCollider.bounds.center, boxCollider.bounds.size);
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
	void OnDrawGizmosSelected()
	{
	//	Gizmos.color = Color.red;
		//Gizmos.DrawWireSphere(transform.position, range);
	}
}
