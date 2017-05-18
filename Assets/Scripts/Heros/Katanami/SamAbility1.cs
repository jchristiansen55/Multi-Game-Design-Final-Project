using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamAbility1 : MonoBehaviour {


	public GameObject Ability;
	public GameObject Firepoint;

	GameObject ability;
	GameObject minionsTakeDamage; 

	public Texture2D ab1;
	public Texture2D ab1CD;

    public AudioClip sam1sound;
    private AudioSource source;
    public float volumeLow = .3f;
    public float volumeHigh = .6f;

    public bool animationQ = false; 

	public float damagePerAttack = 0; 
	public float  ab1CDTime;
	public float charFreezeCD = 0;

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
			GUI.Label (new Rect (10, 10, 50, 50), ab1);
			if (ab1Key) {
				AbilityOne ();
				animationQ = true;
			}
		} else {
			GUI.Label (new Rect (10, 10, 50, 50), ab1CD);
		}
	}	

	void AbilityOne(){
        float vol = Random.Range(volumeLow, volumeHigh);
        source.PlayOneShot(sam1sound, vol);

        ability = Instantiate(Ability, Firepoint.transform.position, Firepoint.transform.rotation);
		ab1Timer = ab1CDTime;
		charFreezeCD = 3;
	}
	void Update(){
		if (animationQ == true) {
		ability.transform.position = Firepoint.transform.position;
		}
	}
}