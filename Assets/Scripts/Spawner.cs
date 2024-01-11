using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate;
    public float randomRange;
    public GameObject spawnObject;

    float spawnCountdown = 0;

    private void Update()
    {
        if(spawnCountdown < 0)
        {
            spawnCountdown = spawnRate + (Random.value*2-1) * randomRange;
            Instantiate(spawnObject, transform.position, transform.rotation);
        }

        spawnCountdown -= Time.deltaTime;
    }
}
