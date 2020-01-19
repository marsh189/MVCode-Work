using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInfo
{
    private static int currentScene;

    public static int CurrentScene
    {
        get
        {
            return currentScene;
        }
        set
        {
            currentScene = value;
        }
    }
}

