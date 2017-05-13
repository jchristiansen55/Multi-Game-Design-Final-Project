using System.Collections;
using UnityEngine;

public class MageAutoAttack : MonoBehaviour {

	public GameObject ability;
	public GameObject Firepoint;
	public GameObject mage;

	GameObject minionsTakeDamage; 

	public float maxRange;
	public float damagePerAttack = 0; 

	public bool AutoAnimation = false; 

	public float  ab1CDTime;
	public float charFreezeCD = 0;
	public float turnSpeed = 10f;

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
		
			distance = Vector3.Distance (mage.transform.position, hit.transform.position); 

			Debug.Log("distance = " + distance);

			if (ab1Key && (distance <= maxRange)) {
				AbilityOne ();
			    Instantiate (ability, hit.transform.position , Quaternion.identity);
				AutoAnimation = true;
			}
		}
	}
	void AbilityOne(){
		ab1Timer = ab1CDTime;
		charFreezeCD = 2;
		minionsTakeDamage.GetComponent<Minions> ().TakeDamage(damagePerAttack);
	}

}