using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class MageAbility2 : MonoBehaviour {

		public GameObject ability;
		public GameObject Firepoint;
		public GameObject character; 

		public Texture2D ab1;
		public Texture2D ab1CD;
		
		public bool isTeleporting = false; 
		
		public float  ab1CDTime;
		public float charFreezeCD = 0;
		
		public float maxBlinkLength;

		RaycastHit hit;
			
		float waitForAnim;
		float ab1Timer = 0;

		void OnGUI(){

			ab1Timer -= Time.deltaTime;
			charFreezeCD -= Time.deltaTime;
			waitForAnim -= Time.deltaTime;

			bool ab1Key = Input.GetKeyDown (KeyCode.W);
			if (ab1Timer <= 0) {
				GUI.Label (new Rect (60, 10, 50, 50), ab1);
				if (ab1Key) {
					AbilityOne ();
				isTeleporting = true;
				}
			} else {
				GUI.Label (new Rect (60, 10, 50, 50), ab1CD);
			}
		}	

		void AbilityOne(){

		Instantiate (ability, Firepoint.transform.position, Quaternion.identity);

		Vector3 blinkDirection = transform.forward;
		float blinkLength = maxBlinkLength;
		if(Physics.Raycast(transform.position, blinkDirection, out hit, maxBlinkLength)){
			blinkLength = hit.distance;
			waitForAnim = 1;
		}
			transform.position = transform.position + (blinkDirection * blinkLength);

		Instantiate (ability, Firepoint.transform.position, Quaternion.identity);

			ab1Timer = ab1CDTime;
			charFreezeCD = 2;
		}
	}
