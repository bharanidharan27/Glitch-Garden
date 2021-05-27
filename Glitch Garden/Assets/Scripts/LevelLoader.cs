using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update

    int currentSceneIndex;
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(3);
        LoadNextScene();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void LoadNextScene() 
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }


    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void Quit()
    {
        Application.Quit();
    }


}
