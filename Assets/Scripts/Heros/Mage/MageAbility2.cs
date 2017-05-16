﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class MageAbility2 : MonoBehaviour {

		public GameObject ability;
		public GameObject Firepoint;
		public GameObject character; 

		public Texture2D ab2;
		public Texture2D ab2CD;
		
		public bool isTeleporting = false; 
		
		public float  ab2CDTime;
		public float charFreezeCD = 0;
		
		public float maxBlinkLength;

		RaycastHit hit;
			
		float ab2Timer = 0;

		void OnGUI(){

			ab2Timer -= Time.deltaTime;
			charFreezeCD -= Time.deltaTime;

			bool ab2Key = Input.GetKeyDown (KeyCode.W);
			if (ab2Timer <= 0) {
				GUI.Label (new Rect (60, 10, 50, 50), ab2);
				if (ab2Key) {
					AbilityTwo ();
				isTeleporting = true;
				}
			} else {
				GUI.Label (new Rect (60, 10, 50, 50), ab2CD);
			}
		}	

		void AbilityTwo(){

		Instantiate (ability, Firepoint.transform.position, Quaternion.identity);

		Vector3 blinkDirection = character.transform.forward;

		float blinkLength = maxBlinkLength;
		if(Physics.Raycast(transform.position, blinkDirection, out hit, maxBlinkLength)){
			blinkLength = hit.distance;

		}
			transform.position = transform.position + (blinkDirection * blinkLength);

		Instantiate (ability, Firepoint.transform.position, Quaternion.identity);

			ab2Timer = ab2CDTime;
			charFreezeCD = 2;
		}
	}
