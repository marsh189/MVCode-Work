using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public Enemy[] enemyTypes;
    public Transform[] enemySpawnPoints;
    public float spawnRate;

    public string gameState;
    public Texture2D cursor;
    public GameObject pauseCanvas;
    public Text text;

    public float timeLeft = 5f;//countDown time
    float nextSpawn; //time for next enemy spawn
    float level;
    float waveCount; //amount of waves in level (level + 2)
    float currentWave = 1;
    float enemiesInWave; //num of enemies in each wave (level * 10)   
    float enemiesSpawned;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Level") > 0)
        {
            level = PlayerPrefs.GetInt("Level");
        }
        else
        {
            level = 1;
        }
        waveCount = level + Conversions.waves;
        enemiesInWave = level * Conversions.enemies;

        nextSpawn = Time.time;
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        gameState = "Starting";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == "Playing")
        {
            if (currentWave <= waveCount)
            {
                SpawnWave();
            }
        }
        if(gameState == "Paused")
        {
            pauseCanvas.SetActive(true);
        }
        if(gameState == "Starting")
        {
            CountDown();
        }

        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameState == "Playing")
            {
                gameState = "Paused";
            }
            else if(gameState == "Paused")
            {
                pauseCanvas.SetActive(false);
                text.gameObject.SetActive(true);
                gameState = "Starting";
            }
        }
    }

    void SpawnWave()
    {
        if (enemiesSpawned < enemiesInWave)
        {
            if (Time.time >= nextSpawn)
            {
                Instantiate(enemyTypes[0].gameObject, enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position, enemyTypes[0].gameObject.transform.rotation);
                nextSpawn = Time.time + spawnRate;
                enemiesSpawned++;
            }
        }
        else
        {
            StartCoroutine("WaitBetweenWaves");
        }
    }

    void CountDown()
    {
        timeLeft -= Time.deltaTime;
        if (Mathf.Round(timeLeft) <= 3)
        {
            text.text = timeLeft.ToString("0");
        }
        else
        {
            text.text = "";
        }

        if (Mathf.Round(timeLeft) < 1)
        {
            text.text = "";
            text.gameObject.SetActive(false);
            timeLeft = 4f;
            gameState = "Playing";
        }
    }

    void SaveLevelInfo()
    {
        //PlayerPrefs.SetInt("Level", )
    }


    IEnumerator WaitBetweenWaves()
    {
        yield return new WaitForSeconds(3);
        currentWave++;
        Debug.Log(currentWave);
    }
}
