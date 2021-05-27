using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VALUE = 0f;
    const float MAX_VALUE = 1f;

    
    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VALUE && volume <= MAX_VALUE)
        {
            Debug.Log("Volume set to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.Log("Volume Out of Range");
        }
        
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(float difficulty)
    {
        if(difficulty >= MIN_VALUE && difficulty <= MAX_VALUE)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
