using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamAuto : MonoBehaviour {
	private Vector3 _direction;
	private Quaternion _lookRotation;

	public GameObject Katanami;

	Transform target = null; 

	GameObject minionsTakeDamage;

    public AudioClip samAAsound;
    private AudioSource source;
    public float volumeLow = .3f;
    public float volumeHigh = .6f;


    public float maxRange;
	public float damagePerAttack = 0; 

	public bool AutoAnimation = false; 

	public float  ab1CDTime;
	public float charFreezeCD = 0;

	float distance; 

	float ab1Timer = 0;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    void OnGUI(){

		ab1Timer -= Time.deltaTime;
		charFreezeCD -= Time.deltaTime;

		bool ab1Key = Input.GetMouseButtonDown (1);

		RaycastHit hit;

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if ((ab1Timer <= 0) && (Physics.Raycast (ray, out hit) && hit.transform.tag == "Blue") ) {

            
            minionsTakeDamage = hit.transform.gameObject;
			target = minionsTakeDamage.transform;

			distance = Vector3.Distance (Katanami.transform.position, hit.transform.position); 

			if (ab1Key && (distance <= maxRange)) {
				
				AbilityOne ();
				AutoAnimation = true;
                float vol = Random.Range(volumeLow, volumeHigh);
                source.PlayOneShot(samAAsound, vol);

            }
		}
	}
	void AbilityOne(){
		_direction = (target.position - transform.position).normalized;
		_lookRotation = Quaternion.LookRotation(_direction);

		Katanami.transform.rotation = _lookRotation;

		ab1Timer = ab1CDTime;
		charFreezeCD = 1;
		minionsTakeDamage.GetComponent<Minions> ().TakeDamage(damagePerAttack);
	}
}