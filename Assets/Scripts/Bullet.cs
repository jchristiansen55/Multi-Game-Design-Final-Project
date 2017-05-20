using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;

	public float speed = 70f;

	public GameObject impactEffect;

	public void Seek (Transform _target)
	{
		target = _target;
	}


	void Update () {

		if (target == null)
		{
			Debug.Log("target is null");
			Destroy(gameObject);
			return;
		}


		Vector3 dir = target.position - transform.position;
				
		float distanceThisFrame = speed * Time.deltaTime;

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);

	}

	void HitTarget ()
	{

	}
}