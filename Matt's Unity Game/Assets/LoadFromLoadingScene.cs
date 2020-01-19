using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFromLoadingScene : MonoBehaviour
{
    public LevelLoader loader;
    public float waitTime;

    void Start()
    {
        StartCoroutine(WaitToStart());
    }

    IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(waitTime);

        loader.LoadFromLoadingScene();
    }
}
