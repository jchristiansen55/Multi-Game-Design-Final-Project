using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAbility4 : MonoBehaviour {

	public GameObject Ability;
	public GameObject Firepoint;
	public GameObject FeetLocation;

	public Texture2D ab4;
	public Texture2D ab4CD;

	public bool animationQ = false; 

	public float  ab4CDTime;
	public float charFreezeCD = 0;
	public float speed; 

	float ab4Timer = 0;

	void OnGUI(){

		ab4Timer -= Time.deltaTime;
		charFreezeCD -= Time.deltaTime;


		bool ab4Key = Input.GetKeyDown (KeyCode.Q);
		if (ab4Timer <= 0) {
			GUI.Label (new Rect (10, 10, 50, 50), ab4);
			if (ab4Key) {
				AbilityFour ();
				animationQ = true;
			}
		} else {
			GUI.Label (new Rect (10, 10, 50, 50), ab4CD);
		}
	}	

	void AbilityFour(){

		Instantiate (Ability, Firepoint.transform.position, Firepoint.transform.rotation);
		ab4Timer = ab4CDTime;
		charFreezeCD = 0;
	}
}