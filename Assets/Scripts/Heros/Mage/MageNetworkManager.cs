﻿using System.Collections;
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
			}
		}
	}