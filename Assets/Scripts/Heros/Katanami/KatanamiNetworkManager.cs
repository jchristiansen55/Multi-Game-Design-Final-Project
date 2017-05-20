using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class KatanamiNetworkManager : Photon.MonoBehaviour {
	public GameObject Kat; 
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
			if (stream.isWriting)
			{
				// We own this player: send the others our data
				stream.SendNext(transform.position);
				stream.SendNext(transform.rotation);

			Animator Kat1 = Kat.GetComponentInChildren<Player> ().anim;
			stream.SendNext ((bool) Kat1.GetBool("AutoAttacking"));
			stream.SendNext ((bool) Kat1.GetBool("QCast"));
			stream.SendNext ((bool) Kat1.GetBool("RCast"));
			stream.SendNext ((bool) Kat1.GetBool("WCast"));
			stream.SendNext ((bool) Kat1.GetBool("ECast"));
			stream.SendNext ((bool) Kat1.GetBool("walk"));
			}
			
			else
			{
				// Network player, receive data
				this.transform.position = (Vector3) stream.ReceiveNext();
				this.transform.rotation = (Quaternion) stream.ReceiveNext();
			Animator Kat1 = Kat.GetComponentInChildren<Player> ().anim;
			bool test;
			bool test1;
			bool test2;
			bool test3;
			bool test4; 
			bool test5;
			test = (bool)stream.ReceiveNext ();
			Kat1.SetBool ("AutoAttacking", test); 
			test1 = (bool)stream.ReceiveNext ();
			Kat1.SetBool ("QCast", test1);
			test2 = (bool)stream.ReceiveNext ();
			Kat1.SetBool ("RCast", test2);
			test3= (bool)stream.ReceiveNext ();
			Kat1.SetBool ("WCast", test3); 
			test4= (bool)stream.ReceiveNext ();
			Kat1.SetBool ("ECast", test4);
			test5 = (bool)stream.ReceiveNext ();
			Kat1.SetBool ("walk", test5);
								
			}
		}
	}
