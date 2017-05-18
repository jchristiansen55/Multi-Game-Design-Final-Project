using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamAbility2 : MonoBehaviour {
	
	public GameObject ability;
	public GameObject Firepoint;

    public AudioClip sam2sound;
    private AudioSource source;
    public float volumeLow = .3f;
    public float volumeHigh = .6f;

	public Texture2D ab2;
	public Texture2D ab2CD;

	public bool isCasting = false; 

	public float  ab2CDTime;
	public float charFreezeCD = 0;


	float ab1Timer = 0;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnGUI(){

		ab1Timer -= Time.deltaTime;
		charFreezeCD -= Time.deltaTime;

		bool ab1Key = Input.GetKeyDown (KeyCode.W);
		if ((GetComponent<SamAuto> ().AutoAnimation == false)&&
			(GetComponent<SamAbility1> ().animationQ == false)&&
			(GetComponent<SamAbility4> ().animationR == false)) 
		{
			if (ab1Timer <= 0) {
				GUI.Label (new Rect (60, 10, 50, 50), ab2);
				if (ab1Key) {
					AbilityTwo ();
					isCasting = true;
				}
			} else {
				GUI.Label (new Rect (60, 10, 50, 50), ab2CD);
			}
		}
	}	

	void AbilityTwo(){
        float vol = Random.Range(volumeLow, volumeHigh);
        source.PlayOneShot(sam2sound,vol);
        Instantiate (ability, Firepoint.transform.position, Quaternion.identity);
		GetComponent<Minions> ().currentHealth =+ 20;
		ab1Timer = ab2CDTime;
		charFreezeCD = 2;
	}
}
