using System.Collections;
using UnityEngine;


public class SendInfo : MonoBehaviour {
	public bool whileRunning = false;
	void Start () {
		
	}
	

	void Update () {

		bool RMB = Input.GetMouseButtonDown (1);
		if (RMB) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit) && hit.transform.tag == "Ground") {
			this.GetComponent<PhotonView> ().RPC ("RecievedMove", PhotonTargets.All, hit.point);

			}
		}
	} 
}
