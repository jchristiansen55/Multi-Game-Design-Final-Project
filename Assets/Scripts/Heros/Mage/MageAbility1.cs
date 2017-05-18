using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class MageAbility1 : MonoBehaviour {

	public GameObject ChanneledAbility;
	public GameObject Firepoint;

		   GameObject ability;
		   GameObject minionsTakeDamage; 

	public Texture2D ab1;
	public Texture2D ab1CD;

    public AudioClip mage1sound;
    private AudioSource source;
    public float volumeLow = .3f;
    public float volumeHigh = .6f;

    public bool animationQ = false; 

	public float damagePerAttack = 0; 
	public float  ab1CDTime;
	public float charFreezeCD = 0;
	public float speed; 

    float ab1Timer = 0;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnGUI(){

		ab1Timer -= Time.deltaTime;
		charFreezeCD -= Time.deltaTime;
	

		bool ab1Key = Input.GetKeyDown (KeyCode.Q);
		if (ab1Timer <= 0) {
			GUI.Label (new Rect (642, 595, 50, 50), ab1);
			if (ab1Key) {
				animationQ = true;
				AbilityOne ();
			}
		} else {
			GUI.Label (new Rect (642, 595, 50, 50), ab1CD);
		}
	}	

	void AbilityOne(){
        float vol = Random.Range(volumeLow, volumeHigh);
        source.PlayOneShot(mage1sound, vol);

        ability = Instantiate(ChanneledAbility, Firepoint.transform.position, Firepoint.transform.rotation);
				ab1Timer = ab1CDTime;
				charFreezeCD = 8;
	}

	void Update(){
		if (GetComponent<MageAbility2> ().isTeleporting == true) {
			ability.transform.position = Firepoint.transform.position;
		}
	}
}
