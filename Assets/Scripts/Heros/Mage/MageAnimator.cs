using System.Collections;
using UnityEngine;

public class MageAnimator : MonoBehaviour {
	public GameObject RM;
	float charFreezeCD = 0;
	bool isTrue;

	Animator m_animator; 


	void Start () {
		m_animator = GetComponent<Animator> ();
		charFreezeCD = 4;
	}
	

	void Update () {
		
		// Running animation 
		m_animator.SetBool ("IsRunning", RM.GetComponent<RecieveMovement>().whileRunning);

		//Q animation 
		m_animator.SetBool ("CastingQ", RM.GetComponent<MageAbility1> ().animationQ);
		if (RM.GetComponent<MageAbility1> ().animationQ == true) {
			charFreezeCD -= Time.deltaTime;
			if (charFreezeCD <= 0) {
					Debug.Log("hi");
			}
			RM.GetComponent<MageAbility1> ().animationQ = false; 
		}
	}
}
