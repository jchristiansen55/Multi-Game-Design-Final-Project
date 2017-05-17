using System.Collections;
using UnityEngine;

public class MageAnimator : MonoBehaviour {
	public GameObject RM;

	bool isTrue;

	Animator m_animator; 


	void Start () {
		m_animator = GetComponent<Animator> ();
	
	}
	

	void Update () {
		// Teleport Animation
		/**
		m_animator.SetBool ("IsTeleporting",RM.GetComponent<MageAbility2>().isTeleporting);
		if (RM.GetComponent<MageAbility2> ().isTeleporting == true) {
			RM.GetComponent<MageAbility2> ().isTeleporting = false; 
		}
		*/

		// Auto Attack animation
		m_animator.SetBool ("AutoAttacking",RM.GetComponent<MageAutoAttack>().AutoAnimation);
		if (RM.GetComponent<MageAutoAttack> ().AutoAnimation == true) {
			RM.GetComponent<MageAutoAttack> ().AutoAnimation = false; 
		}
		// Walking animation 
		m_animator.SetBool ("IsRunning", RM.GetComponent<RecieveMovement>().whileRunning);

		//Q animation 
		m_animator.SetBool ("CastingQ", RM.GetComponent<MageAbility1> ().animationQ);
		if (RM.GetComponent<MageAbility1> ().animationQ == true) {
			RM.GetComponent<MageAbility1> ().animationQ = false; 
		}
	}
}
