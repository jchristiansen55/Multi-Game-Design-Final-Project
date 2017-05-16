using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class MageAbility1 : MonoBehaviour {

	public GameObject ChanneledAbility;
	public GameObject GroundEffect;
	public GameObject Firepoint;
	public GameObject Mage; 

	public Texture2D ab1;
	public Texture2D ab1CD;

	public bool animationQ = false; 

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
				AbilityOne ();
				animationQ = true;
			}
		} else {
			GUI.Label (new Rect (10, 10, 50, 50), ab1CD);
		}
	}	

	void AbilityOne(){
		
		Instantiate (ChanneledAbility, Firepoint.transform.position, Firepoint.transform.rotation);

				ab1Timer = ab1CDTime;
				charFreezeCD = 8;
	}
	void Start(){}
	void Update(){
		if (GetComponent<MageAbility2> ().isTeleporting == true) {
			Debug.Log ("I HATE LIFE");
			//Instantiate (ChanneledAbility, Firepoint.transform.position, Firepoint.transform.rotation);
			ChanneledAbility.transform.position = Firepoint.transform.position;
			if (ChanneledAbility.transform.position == Firepoint.transform.position) {
				Debug.Log ("WHY WONT THIS WORK GDSFKLHGLKDFHJ GK:");
			}

		}
	}
}
