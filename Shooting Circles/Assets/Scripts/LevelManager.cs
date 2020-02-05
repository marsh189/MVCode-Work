using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public Enemy[] enemyTypes;
    public Transform[] enemySpawnPoints;
    public float spawnRate;
    public float waveCount;
    public string gameState;
    public Texture2D cursor;
    public GameObject pauseCanvas;
    public Text text;

    public float timeLeft = 5f;
    float nextSpawn;

    // Start is called before the first frame update
    void Start()
    {

        nextSpawn = Time.time;
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        gameState = "Starting";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == "Playing")
        {
            SpawnWave();
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
        if (Time.time >= nextSpawn)
        {
            Instantiate(enemyTypes[0].gameObject, enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)].position, enemyTypes[0].gameObject.transform.rotation);
            nextSpawn = Time.time + spawnRate;
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
}
