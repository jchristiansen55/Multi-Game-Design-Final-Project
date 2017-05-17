using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamAuto : MonoBehaviour {

	public GameObject Katanami;

	GameObject minionsTakeDamage; 

	public float maxRange;
	public float damagePerAttack = 0; 

	public bool AutoAnimation = false; 

	public float  ab1CDTime;
	public float charFreezeCD = 0;

	float distance; 

	float ab1Timer = 0;


	void OnGUI(){

		ab1Timer -= Time.deltaTime;
		charFreezeCD -= Time.deltaTime;

		bool ab1Key = Input.GetMouseButtonDown (1);

		RaycastHit hit;

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if ((ab1Timer <= 0) && (Physics.Raycast (ray, out hit) && hit.transform.tag == "Blue") ) {

			minionsTakeDamage = hit.transform.gameObject;

			distance = Vector3.Distance (Katanami.transform.position, hit.transform.position); 

			if (ab1Key && (distance <= maxRange)) {
				
				AbilityOne ();
				AutoAnimation = true;

			}
		}
	}
	void AbilityOne(){
		ab1Timer = ab1CDTime;
		charFreezeCD = 1;
		minionsTakeDamage.GetComponent<Minions> ().TakeDamage(damagePerAttack);
	}
}