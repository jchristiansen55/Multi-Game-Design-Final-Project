using System.Collections;
using UnityEngine;

public class KillSelf : MonoBehaviour {

	public float timer;
    private Minions tar;

    public float AbilityDMG = 0f;

	void Start () {
		
	}

	void Update () {
		timer -= Time.deltaTime;	
		if (timer < 0) {
			Destroy (this.gameObject);
		}

        Collider[] col = Physics.OverlapSphere(transform.position, 6.0f);
        foreach (Collider hit in col)
        {
            tar = hit.GetComponent<Minions>();
            if (hit.tag == "Blue")
            {
                if (tar != null)
                {
                    tar.TakeDamage(AbilityDMG);
                }
            }
        }
	}
}
