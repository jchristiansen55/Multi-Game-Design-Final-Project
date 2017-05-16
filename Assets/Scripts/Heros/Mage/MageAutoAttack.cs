using System.Collections;
using UnityEngine;

public class MageAutoAttack : MonoBehaviour {

	public GameObject ability;
	public GameObject Firepoint;
	public GameObject mage;

	 Transform target = null; 

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
			target = minionsTakeDamage.transform;

			distance = Vector3.Distance (mage.transform.position, hit.transform.position); 

			if (ab1Key && (distance <= maxRange)) {
				
				Instantiate (ability, minionsTakeDamage.transform.position , Quaternion.identity);
				AbilityOne ();

				
				AutoAnimation = true;
			
			}
		}
	}
	void AbilityOne(){

	
		GameObject bulletGO = Instantiate(ability, Firepoint.transform.position, Firepoint.transform.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();

	
		if (bullet != null) {
			bullet.Seek (target);
		}


		ab1Timer = ab1CDTime;
		charFreezeCD = 2;
		minionsTakeDamage.GetComponent<Minions> ().TakeDamage(damagePerAttack);
	}
}