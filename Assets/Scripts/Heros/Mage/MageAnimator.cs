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
		
		// Running animation 
		m_animator.SetBool ("IsRunning", RM.GetComponent<RecieveMovement>().whileRunning);

		//Q animation 
		m_animator.SetBool ("CastingQ", RM.GetComponent<MageAbility1> ().animationQ);
		if (RM.GetComponent<MageAbility1> ().animationQ == true) {
			RM.GetComponent<MageAbility1> ().animationQ = false; 
		}
	}
}
