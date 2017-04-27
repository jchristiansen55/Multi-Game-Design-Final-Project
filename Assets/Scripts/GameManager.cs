using System.Collections;
using UnityEngine;

public class GameManager : Photon.MonoBehaviour {

	public GameObject[] redSpawn;
	public GameObject[] blueSpawn;

	public int state = 0;

	void Connect(){
		PhotonNetwork.ConnectToBestCloudServer ("v1.0");
			state = 1;		
		}
	

	void Start () 
	{
		
	}

	void Update () 
	{
	
	}
		void OnGUI(){
		switch (state) {
		case 0:	
			if(GUI.Button(new Rect(10,10,100,30), "Connect")){
				Connect ();
			}
			 break;
		case 1:
			GUI.Label (new Rect (10, 10, 100, 30), "Connected");
			 break;
		}
	}
}