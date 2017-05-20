using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class MageNetworkManager : Photon.MonoBehaviour {
	public GameObject Char; 
		public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
			if (stream.isWriting)
			{
				// We own this player: send the others our data
				stream.SendNext(transform.position);
				stream.SendNext(transform.rotation);
			Animator mage = Char.GetComponentInChildren<MageAnimator> ().m_animator;
			stream.SendNext ((bool) mage.GetBool("AutoAttacking"));
			stream.SendNext ((bool) mage.GetBool("IsRunning"));
			stream.SendNext ((bool) mage.GetBool("CastingQ"));
						
			}
			else
			{
				// Network player, receive data
				this.transform.position = (Vector3) stream.ReceiveNext();
				this.transform.rotation = (Quaternion) stream.ReceiveNext();
			Animator mage = Char.GetComponentInChildren<MageAnimator> ().m_animator;
			bool test;
			bool test1;
			bool test2;
			test = (bool)stream.ReceiveNext ();
			mage.SetBool ("AutoAttacking", test); 
			test1 = (bool)stream.ReceiveNext ();
			mage.SetBool ("IsRunning", test1); 
			test2 = (bool)stream.ReceiveNext ();
			mage.SetBool ("CastingQ", test2); 
			}
		}
	}