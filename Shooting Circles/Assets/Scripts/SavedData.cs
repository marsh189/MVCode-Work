using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SavedData
{
    public static int level;

    public static float playerShield
    {
        get { return PlayerPrefs.GetFloat("Player Shield"); }
    }
    public static float playerHealth
    {
        get { return PlayerPrefs.GetFloat("Player Health"); }
    }
    public static float playerSpeed
    {
        get { return PlayerPrefs.GetFloat("Player Speed"); }
    }
    public static float playerScore
    {
        get { return PlayerPrefs.GetFloat("Player Score"); }
    }

    public static Player SetUpPlayer()
    {

        Player currPlayer = new Player();
        currPlayer.shield = playerShield;
        currPlayer.health = playerHealth;
        currPlayer.speed = playerSpeed;
        currPlayer.score = playerScore;

        return currPlayer;
    }
}
