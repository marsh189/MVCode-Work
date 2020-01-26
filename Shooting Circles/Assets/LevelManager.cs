using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public Enemy[] enemyTypes;
    public Transform[] enemySpawnPoints;
    public float spawnRate;
    public float waveCount;
    public Texture2D cursor;
    float nextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawn = Time.time;
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
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
