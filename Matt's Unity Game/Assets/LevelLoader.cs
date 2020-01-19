using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

   public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadLevelIndex(int index)
    {
        StartCoroutine(LoadLevel(index));

    }

    public void LoadLevelLoader(int index)
    {
        GameInfo.CurrentScene = index;
        StartCoroutine(LoadLevel("LoadingScene"));
    }

    public void LoadFromLoadingScene()
    {
        Debug.Log(GameInfo.CurrentScene);
        StartCoroutine(LoadAsynchronously(GameInfo.CurrentScene));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadLevel(string levelName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
    }

    IEnumerator LoadAsynchronously(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);

        while(!operation.isDone)
        {
            Debug.Log(operation.progress);

            yield return null;

        }

        transition.SetTrigger("Start");
    }
}
