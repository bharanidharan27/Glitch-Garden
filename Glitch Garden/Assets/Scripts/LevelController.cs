using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public int attackersCount = 0;
    bool levelTimerExpired = false;
    public bool playerFailed = false;
    [SerializeField] GameObject levelCompleteScreen;
    [SerializeField] GameObject levelFailedScreen;
    [SerializeField] AudioClip levelCompleteSFX;
    [SerializeField] AudioClip levelFailedSFX;
    [SerializeField] int secondsToComplete = 4;
    [SerializeField] int secondsToFailed = 3;

    // Update is called once per frame

    private void Start()
    {
        levelFailedScreen.SetActive(false);
        levelCompleteScreen.SetActive(false);
    }

    public void AttackerKilled()
    {
        attackersCount--;
        if (attackersCount <= 0 && levelTimerExpired && !playerFailed) 
        {
            StartCoroutine(LevelComplete());
        }
    }

    public void AttackerSpawned()
    {
        attackersCount++;
    }

    public void TimerExpired()
    {
        // Stop spawning attackers
        levelTimerExpired = true;
        StopSpawners();
    }

    void StopSpawners()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner attackerSpawner in attackerSpawners)
        {
            attackerSpawner.StopSpawning();
        }
    }

    IEnumerator LevelComplete()
    {
        levelCompleteScreen.SetActive(true);
        DeactivateButtons();
        AudioSource.PlayClipAtPoint(levelCompleteSFX, Camera.main.transform.position);
        yield return new WaitForSeconds(secondsToComplete);
        GetComponent<LevelLoader>().LoadNextScene();
        //Debug.Log("Load nextScene");
    }

    public void PlayerDefeated()
    {
        playerFailed = true;
        Time.timeScale = 0;
        StopSpawners();
        StartCoroutine(LevelFailed());
    }

    IEnumerator LevelFailed()
    {
        levelFailedScreen.SetActive(true);
        DeactivateButtons();
        AudioSource.PlayClipAtPoint(levelFailedSFX, Camera.main.transform.position);
        yield return new WaitForSeconds(secondsToFailed);
        //GetComponent<LevelLoader>().LoadStartScene(); 
        Debug.Log("Level Failed");
    }

    private void DeactivateButtons()
    {
        DefenderButton[] defenderPrefabs = FindObjectsOfType<DefenderButton>(); 
        foreach(DefenderButton defender in defenderPrefabs)
        {
            defender.DeactivateCollider();
        }
    }
}
