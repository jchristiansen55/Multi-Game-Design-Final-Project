using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAbility3 : MonoBehaviour {

	public GameObject ability;
	public GameObject Character;
		   GameObject ability3;


	public Collider animationCollider;

    public AudioClip mage3sound;
    private AudioSource source;
    public float volumeLow = .3f;
    public float volumeHigh = .6f;

    public Texture2D ab3;
	public Texture2D ab3CD;

	bool castingE = false;

	public float ab3CDTime;

	float ab3Timer = 0;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnGUI(){

		ab3Timer -= Time.deltaTime;

		bool ab3Key = Input.GetKeyDown (KeyCode.E);
		if (ab3Timer <= 0) {
			GUI.Label (new Rect (835, 595, 50, 50), ab3);
			if (ab3Key) {
				castingE = true;
				AbilityThree ();
			}
		} else {
			GUI.Label (new Rect (835, 595, 50, 50), ab3CD);
		}
	}	

	void AbilityThree(){
        float vol = Random.Range(volumeLow, volumeHigh);
        source.PlayOneShot(mage3sound, vol);
        ability3 = Instantiate (ability, Character.transform.position, Quaternion.identity);
		ab3Timer = ab3CDTime;
	}
	void Update(){
		if (castingE == true) {
			ability3.transform.position = Character.transform.position;
		}

	}

}

