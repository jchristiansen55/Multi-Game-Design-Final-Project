using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAbility4 : MonoBehaviour {

	public GameObject Ability;
	public GameObject Firepoint;
	public GameObject Character; 
	GameObject Ability1;

	public Texture2D ab4;
	public Texture2D ab4CD;

	public float  ab4CDTime;

    bool animationR = false; 

	float ab4Timer = 0;

	void OnGUI(){

		ab4Timer -= Time.deltaTime;

		bool ab4Key = Input.GetKeyDown (KeyCode.R);
		if (ab4Timer <= 0) {
			GUI.Label (new Rect (160, 10, 50, 50), ab4);
			if (ab4Key) {
				animationR = true;
				AbilityFour ();
			}
		} else {
			GUI.Label (new Rect (160, 10, 50, 50), ab4CD);
		}
	}	

	void AbilityFour(){
		Ability1 = Instantiate (Ability, Firepoint.transform.position, Firepoint.transform.rotation);
		ab4Timer = ab4CDTime;
	}
	void Update(){
		if ((animationR == true)) {
			Ability1.transform.position = Character.transform.position;
		}
	}
}