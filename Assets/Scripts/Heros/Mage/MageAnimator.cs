using System.Collections;
using UnityEngine;

public class MageAnimator : MonoBehaviour {

	Animator m_animator; 

	void Start () {
		m_animator = GetComponent<Animator> ();
	}
	

	void Update () {
		bool isRunningPressed = Input.GetMouseButton (1);
		//while (GameObject.Find ("Mage").GetComponent<RecieveMovement> ().newposition != GameObject.Find ("Mage").GetComponent<RecieveMovement> ().movPosition) {
			m_animator.SetBool ("IsRunning", isRunningPressed);
	//	}

	}
}
