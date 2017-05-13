using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nexus : MonoBehaviour {


    public GameObject nexus;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // if (GetComponent<Minions>().currentHealth <= 20) 
       if ( nexus == null)
        {
            Debug.Log("Hello nexus destroyed");
           // SceneManager.LoadScene("moba");
        }

      
    }
}
