using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningBlueRightLane : MonoBehaviour
{
    public Transform MeleeMinion;
    public Transform CasterMinion;
    public Transform CannonMinion;
    public Transform SuperMinion;

    public Transform spawnPoint;

    public float timeBetweenWaves = 7f;
    private float countdown = 2f;

    private int waveNumber = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnMelee();
            yield return new WaitForSeconds(0.5f);
        }
        if (waveNumber % 3 == 0)
        {
            SpawnCannon();
            yield return new WaitForSeconds(0.5f);
        }
        for (int i = 0; i < 3; i++)
        {
            SpawnCaster();
            yield return new WaitForSeconds(0.5f);
        }

        waveNumber++;
    }
    void SpawnCaster()
    {
        Instantiate(CasterMinion, spawnPoint.position, spawnPoint.rotation);
    }
    void SpawnCannon()
    {
        Instantiate(CannonMinion, spawnPoint.position, spawnPoint.rotation);
    }
    void SpawnMelee()
    {
        Instantiate(MeleeMinion, spawnPoint.position, spawnPoint.rotation);
    }
}
