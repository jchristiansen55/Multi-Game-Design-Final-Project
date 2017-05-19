using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamAbility1 : MonoBehaviour
{


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
    public float ab1CDTime;
    public float charFreezeCD = 0;

    bool ab1Key = false;
    bool ok = false;

    private Minions tar;

    float ab1Timer = 0;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void OnGUI()
    {

        ab1Timer -= Time.deltaTime;
        charFreezeCD -= Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.Q))
        {
            ab1Key = true;
        }
        //bool ab1Key = Input.GetMouseButtonDown (1);
        
        if (ab1Timer <= 0)
        {
            GUI.Label(new Rect(642, 595, 50, 50), ab1);

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (ab1Key && Physics.Raycast(ray, out hit) && hit.transform.tag == "Blue")
            {
                tar = hit.collider.GetComponent<Minions>();
                ok = true;
            } else
            {
                ab1Key = false;
            }
        }
        else
        {
            GUI.Label(new Rect(642, 595, 50, 50), ab1CD);
        }
        
    }

    

    void AbilityOne()
    {

        float vol = Random.Range(volumeLow, volumeHigh);
        source.PlayOneShot(sam1sound, vol);

        ability = Instantiate(Ability, Firepoint.transform.position, Firepoint.transform.rotation);
        ab1Timer = ab1CDTime;
        charFreezeCD = 3;
    }
    void Update()
    {
        if (animationQ == true)
        {
            ability.transform.position = Firepoint.transform.position;
        }
        if (ok)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, tar.transform.position);
            if (distanceToEnemy > 7)
            {
                gameObject.GetComponent<RecieveMovementKatanami>().RecievedMove(tar.transform.position);
            }
            if (distanceToEnemy <= 7)
            {
                gameObject.GetComponent<RecieveMovementKatanami>().RecievedMove(transform.position);
                AbilityOne();
                animationQ = true;
                tar.TakeDamage(damagePerAttack);
                ab1Key = false;
                ok = false;
            }
        }
    }
}