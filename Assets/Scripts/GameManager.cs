using UnityEngine;
using System.Collections;


public class GameManager : Photon.MonoBehaviour {

	public GameObject[] redSpawn;
	public GameObject[] blueSpawn;

	public GameObject lobbyCam; 

	public int state = 0;
	int spawnCounter = 0; 
	void Connect(){
		PhotonNetwork.ConnectUsingSettings("v1.0");
		}

	void OnJoinedLobby(){
		state = 1;
		}

	void OnPhotonRandomJoinFailed(){
		PhotonNetwork.CreateRoom (null);
		}
	void OnJoinedRoom(){
		state = 2;
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
			GUI.Label (new Rect (10, 40, 100, 30), "Connected");
			if (GUI.Button (new Rect (10, 10, 100, 30), "Que")) {
				PhotonNetwork.JoinRandomRoom();
			}
			 break;
		case 2: 
			//Champ Select
			GUI.Label (new Rect (10, 40, 200, 30), "Select Challenger");
			if (GUI.Button (new Rect (70, 10, 100, 30), "Katanami")) {
				Spawn (0, "Katanami");
			}
			if (GUI.Button (new Rect (180, 10, 100, 30), "Mage")) {
				Spawn (0, "Mage");
			}

			break;
				case 3: 
				// IN GAME
			break; 
		}
	}
		void Spawn(int team, string challenger){
			state = 3; 
				lobbyCam.SetActive (false);
		if( spawnCounter == 0 ){
		GameObject userSpawn1 = redSpawn [Random.Range (0, redSpawn.Length)];
		GameObject userPlayer1 = PhotonNetwork.Instantiate (challenger, userSpawn1.transform.position, userSpawn1.transform.rotation, 0);
			spawnCounter = 1;
		} else {
		GameObject userSpawn2 = blueSpawn [Random.Range (0, blueSpawn.Length)];
		GameObject userPlayer2 = PhotonNetwork.Instantiate (challenger, userSpawn2.transform.position, userSpawn2.transform.rotation, 0);
		}
	}
}