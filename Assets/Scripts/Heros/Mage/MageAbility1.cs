using System.Collections;
using UnityEngine;

public class MageAbility1 : MonoBehaviour {

	public GameObject ability;
	public GameObject Firepoint;

	public Texture2D ab1;
	public Texture2D ab1CD;

	public bool animationQ = false; 

	public float  ab1CDTime;
	public float charFreezeCD;
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
		
				Instantiate (ability, Firepoint.transform.position, Quaternion.identity);
		//ability.transform.RotateAround (transform.position, transform.up, Time.deltaTime * 90f);
				ab1Timer = ab1CDTime;
				charFreezeCD = 8;
	}
}
