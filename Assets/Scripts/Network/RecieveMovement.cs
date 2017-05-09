using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveMovement: MonoBehaviour {

	Vector3 newposition; 

	public float speed;
	public float walkRange;
	public bool whileRunning = false;

	public GameObject graphics;

	void Start () {
		newposition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponent<MageAbility1> ().charFreezeCD <= 0){
		if (Vector3.Distance (newposition, this.transform.position) > walkRange) {
			this.transform.position = Vector3.MoveTowards (this.transform.position, newposition, speed * Time.deltaTime); 
			Quaternion transRot = Quaternion.LookRotation (newposition - this.transform.position, Vector3.up);
			graphics.transform.rotation = Quaternion.Slerp (transRot, graphics.transform.rotation, 0.2f);
			whileRunning = true; 
		}
		if ((Vector3.Distance (newposition, this.transform.position) < walkRange) && (whileRunning == true)) {
			whileRunning = false; 
			} 
		} 
	}
	[PunRPC]
	public void RecievedMove(Vector3 movePos){
		newposition = movePos;


	}
}
