using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamAbility4 : MonoBehaviour {
	private Vector3 _direction;
	private Quaternion _lookRotation;

	public GameObject Ability;
	public GameObject Firepoint;
	public GameObject Character; 
	public GameObject MoveCamWithChar;

	Transform target = null; 

	GameObject Ability1;
	GameObject minionsTakeDamage; 

	public Texture2D ab4;
	public Texture2D ab4CD;

	public float damagePerAttack = 0; 
	public float maxRange;
	public float  ab4CDTime;
	public float maxDistanceBehind;
	public float charFreezeCD = 0;

	public bool animationR = false; 

	RaycastHit hit;

	float ab4Timer = 0;
	float distance; 

	void OnGUI(){

		ab4Timer -= Time.deltaTime;
		charFreezeCD -= Time.deltaTime;

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		bool ab4Key = Input.GetKeyDown (KeyCode.R);

		if (ab4Timer <= 0) {
			GUI.Label (new Rect (160, 10, 50, 50), ab4);
		} else {
			GUI.Label (new Rect (160, 10, 50, 50), ab4CD);
		}
		if ((ab4Timer <= 0) && (Physics.Raycast (ray, out hit) && hit.transform.tag == "Blue") ) {

			minionsTakeDamage = hit.transform.gameObject;
			target = minionsTakeDamage.transform;

		if (ab4Timer <= 0) {
				if (ab4Key&& (distance <= maxRange)) {
				animationR = true;
				AbilityFour ();
			}
		}
	}		
}

	void AbilityFour(){
		Instantiate(Ability, Firepoint.transform.position, Firepoint.transform.rotation);

		_direction = (target.position - transform.position).normalized;
		_lookRotation = Quaternion.LookRotation(_direction);

		Character.transform.rotation = _lookRotation;

		transform.position = minionsTakeDamage.transform.position;
		Vector3 blinkDirection = Character.transform.forward;

		float blinkLength = maxDistanceBehind;
		if(Physics.Raycast(Character.transform.position, blinkDirection, out hit, maxDistanceBehind)){
			blinkLength = hit.distance;

		}
		transform.position = transform.position + (blinkDirection * blinkLength);

		Instantiate(Ability, Firepoint.transform.position, Firepoint.transform.rotation);


		ab4Timer = ab4CDTime;
		minionsTakeDamage.GetComponent<Minions> ().TakeDamage(damagePerAttack);
		charFreezeCD = 1.5f;
	}
}
