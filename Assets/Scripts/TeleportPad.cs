using System.Collections;
using UnityEngine;

public class TeleportPad : MonoBehaviour {
    public int Code;
    float disableTimer = 0;

    void Update()
    {
        if (disableTimer > 0)
        {
            disableTimer -= Time.deltaTime;
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Mage" && disableTimer <= 0)
        {
            foreach (TeleportPad tp in FindObjectsOfType<TeleportPad>())
            {
                if (tp.Code == Code && tp != this)
                {
                    tp.disableTimer = 2;
                    Vector3 position = tp.gameObject.transform.position;
                    position.y += 2;
                    collider.gameObject.transform.position = position;
                }
            }
        }
    }
}