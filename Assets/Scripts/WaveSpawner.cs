using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform Test_Creep_Pref;

    public Transform SpawnPont;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    void Update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    void SpawnWave()
    {
        Instantiate(Test_Creep_Pref, SpawnPont.position, SpawnPont.rotation);
    }
}
