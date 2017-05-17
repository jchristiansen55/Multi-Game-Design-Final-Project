using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamAbility3 : MonoBehaviour {


	public GameObject ability;
	public GameObject Character;
	GameObject ability3;

	public Texture2D ab3;
	public Texture2D ab3CD;

	public bool castingE = false;

	public float ab3Length;
	float continueLength; 

	public float ab3CDTime =0;

	float ab3Timer = 0;

	float speedInAbiltiy; 
	float oldSpeed; 

	void OnGUI(){

		ab3Timer -= Time.deltaTime;

		bool ab3Key = Input.GetKeyDown (KeyCode.E);
		if (ab3Timer <= 0) {
			GUI.Label (new Rect (110, 10, 50, 50), ab3);
			if (ab3Key) {
				AbilityThree ();
				castingE = true;
			}
		} else {
			GUI.Label (new Rect (110, 10, 50, 50), ab3CD);
		}
	}	

	void AbilityThree(){
		continueLength = ab3Length;
		speedInAbiltiy = GetComponent<RecieveMovementKatanami> ().speed;
		oldSpeed = speedInAbiltiy;
		speedInAbiltiy = speedInAbiltiy * 2.0f;
		GetComponent<RecieveMovementKatanami> ().speed = speedInAbiltiy;

		ability3 = Instantiate (ability, Character.transform.position, Character.transform.rotation);
		ab3Timer = ab3CDTime;


	}
	void Update(){
		if (castingE == true) {
			ab3Length -= Time.deltaTime;
			ability3.transform.position = Character.transform.position;
			ability3.transform.rotation = Character.transform.rotation;
		}
		if (ab3Length <= 0) {
			castingE = false; 
			GetComponent<RecieveMovementKatanami> ().speed = oldSpeed;
			ab3Length = continueLength;

		}
	}

}

