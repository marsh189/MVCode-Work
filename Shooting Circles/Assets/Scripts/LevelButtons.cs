using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour
{
    LevelManager lm;
    PlayerController player;

    void Start()
    {
        lm = GetComponent<LevelManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    public void ContinueLevel()
    {
        Cursor.SetCursor(lm.cursor, Vector2.zero, CursorMode.Auto);
        lm.pauseCanvas.SetActive(false);
        lm.text.gameObject.SetActive(true);
        lm.gameState = "Starting";
    }

    public void ReturnToMenu()
    {
        player.SavePlayerInfo();
        PlayerPrefs.SetFloat("Level", lm.level);
        SceneManager.LoadScene("Menu");
    }

    public void FinishedLevel()
    {
        player.SavePlayerInfo();
        PlayerPrefs.SetFloat("Level", lm.level + 1);
        SceneManager.LoadScene("Menu");
    }
}
