using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class MageAbility1 : MonoBehaviour {

	public GameObject ChanneledAbility;
	public GameObject Firepoint;

		   GameObject ability;
		   GameObject minionsTakeDamage; 

	public Texture2D ab1;
	public Texture2D ab1CD;

	public bool animationQ = false; 

	public float damagePerAttack = 0; 
	public float  ab1CDTime;
	public float charFreezeCD = 0;
	public float speed; 

    float ab1Timer = 0;

	void OnGUI(){

		ab1Timer -= Time.deltaTime;
		charFreezeCD -= Time.deltaTime;
	

		bool ab1Key = Input.GetKeyDown (KeyCode.Q);
		if (ab1Timer <= 0) {
			GUI.Label (new Rect (10, 10, 50, 50), ab1);
			if (ab1Key) {
				animationQ = true;
				AbilityOne ();
			}
		} else {
			GUI.Label (new Rect (10, 10, 50, 50), ab1CD);
		}
	}	

	void AbilityOne(){
	 ability = Instantiate(ChanneledAbility, Firepoint.transform.position, Firepoint.transform.rotation);
				ab1Timer = ab1CDTime;
				charFreezeCD = 8;
	}

	void Update(){
		if (GetComponent<MageAbility2> ().isTeleporting == true) {
			ability.transform.position = Firepoint.transform.position;
		}
	}
}
