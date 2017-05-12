using System.Collections;
using UnityEngine;

public class MageAutoAttack : MonoBehaviour {

	public GameObject ability;
	public GameObject Firepoint;

	public bool AutoAnimation = false; 

	public float  ab1CDTime;
	public float charFreezeCD = 0;

	float ab1Timer = 0;

	void OnGUI(){

		ab1Timer -= Time.deltaTime;
		charFreezeCD -= Time.deltaTime;

		bool ab1Key = Input.GetMouseButtonDown (1);

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if ((ab1Timer <= 0) && (Physics.Raycast (ray, out hit) && hit.transform.tag == "Blue")) {
			if (ab1Key) {
				AbilityOne ();
				AutoAnimation = true;
			}
		}
	}	

	void AbilityOne(){

		Instantiate (ability, Firepoint.transform.position, Quaternion.identity);

		ab1Timer = ab1CDTime;
		charFreezeCD = 2;
	}
}