using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMovementREDLeftLane : MonoBehaviour
{

    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 4;

    void Start()
    {
        target = Waypoints.points[4];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);
    }

}
