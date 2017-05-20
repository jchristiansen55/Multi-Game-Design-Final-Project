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
			/**
			Kat1.GetBool ("AutoAttacking") = (bool)stream.ReceiveNext ();
			Kat1.GetBool("QCast")= (bool)stream.ReceiveNext ();
			Kat1.GetBool("RCast")= (bool)stream.ReceiveNext ();
			Kat1.GetBool("WCast")= (bool)stream.ReceiveNext ();
			Kat1.GetBool("ECast")= (bool)stream.ReceiveNext ();
			Kat1.GetBool("walk")= (bool)stream.ReceiveNext ();
			*/
			}
		}
	}
