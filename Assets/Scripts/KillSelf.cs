using System.Collections;
using UnityEngine;

public class KillSelf : MonoBehaviour {

	public float timer;	

	void Start () {
		
	}

	void Update () {
		timer -= Time.deltaTime;	
		if (timer < 0) {
			Destroy (this.gameObject);
		}
	}
}
