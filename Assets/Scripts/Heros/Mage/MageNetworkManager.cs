using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageNetworkManager : MonoBehaviour {
	void OnPhotonSerializeView ( PhotonStream stream, PhotonMessageInfo info ) 
	{
		SerializeState (stream, info);
			
		//MageVisuals.SerializeState (stream, info);
		//MageMovement.SerializeState (stream, info); 
	}
	void SerializeState(PhotonStream stream, PhotonMessageInfo info) 
	{
		//if (stream.isWriting == true) {
		//	stream.SendNext (m_Health);
		//}
		//else {
		//	float oldHealth = m_Health;
		//	m_Health = (float)stream.RecieveNext ();

		//	if(m_Health != oldHealth) 
		//	{
		//		OnHealthChanged();
		//	}
		//}
}
}
