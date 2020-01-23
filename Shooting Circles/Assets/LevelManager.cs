using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public Enemy[] enemyTypes;
    public Transform[] enemySpawnPoints;
    public float spawnRate;
    public float waveCount;

    float nextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnWave();
    }

    void SpawnWave()
    {
        if (Time.time >= nextSpawn)
        {
            Instantiate(enemyTypes[0].gameObject, enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position, enemyTypes[0].gameObject.transform.rotation);
            nextSpawn = Time.time + spawnRate;
        }
    }
}
