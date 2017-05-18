using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	public Animator anim;
	public Rigidbody rbody;
	public GameObject RM;

	private float inputH;
	private float inputV;

	void Start () 
	{
		anim = GetComponent<Animator>();
		rbody = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		anim.SetBool ("AutoAttacking", RM.GetComponent<SamAuto> ().AutoAnimation);
		if (RM.GetComponent<SamAuto> ().AutoAnimation == true) {
			RM.GetComponent<SamAuto> ().AutoAnimation = false; 
		}
		anim.SetBool ("QCast", RM.GetComponent<SamAbility1> ().animationQ);
		if (RM.GetComponent<SamAbility1> ().animationQ == true) {
			RM.GetComponent<SamAbility1> ().animationQ = false; 
		}
		anim.SetBool ("RCast", RM.GetComponent<SamAbility4> ().animationR);
		if (RM.GetComponent<SamAbility4> ().animationR == true) {
			RM.GetComponent<SamAbility4> ().animationR = false; 
		}
		anim.SetBool ("WCast", RM.GetComponent<SamAbility2>().isCasting);
		if (RM.GetComponent<SamAbility2> ().isCasting == true) {
			RM.GetComponent<SamAbility2> ().isCasting = false; 
		}


		anim.SetBool ("ECast", RM.GetComponent<SamAbility3> ().castingE);
	
		anim.SetBool ("walk", RM.GetComponent<RecieveMovementKatanami> ().whileRunning);
	}

}


