using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nexus : MonoBehaviour {

    void Update()
    {
       if (GetComponent<Minions>().currentHealth <= 0)
        {
            Debug.Log("Hello nexus destroyed");
        }
    }
}
