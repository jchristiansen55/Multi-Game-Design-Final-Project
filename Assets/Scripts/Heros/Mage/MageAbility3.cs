using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAbility3 : MonoBehaviour {

	public GameObject ability;
	public GameObject Character;

	public Texture2D ab3;
	public Texture2D ab3CD;

	public float  ab3CDTime;

	float ab3Timer = 0;

	void OnGUI(){

		ab3Timer -= Time.deltaTime;

		bool ab3Key = Input.GetKeyDown (KeyCode.E);
		if (ab3Timer <= 0) {
			GUI.Label (new Rect (110, 10, 50, 50), ab3);
			if (ab3Key) {
				AbilityThree ();
			}
		} else {
			GUI.Label (new Rect (110, 10, 50, 50), ab3CD);
		}
	}	

	void AbilityThree(){

		Instantiate (ability, Character.transform.position, Quaternion.identity);
		ab3Timer = ab3CDTime;
		if (GetComponent<MageAbility2> ().isTeleporting == true) {
		
		}
	}
}

