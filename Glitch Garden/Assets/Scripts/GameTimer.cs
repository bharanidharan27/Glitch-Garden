using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Time Until Level Finishes In Seconds")]
    [SerializeField] float levelTime = 10;
    bool triggerLevelFinish = false;
    LevelController levelController;

    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }
    // Update is called once per frame
    void Update()
    {
        if(triggerLevelFinish) { return; }
        if(!levelController.playerFailed)
        {
            GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
            bool timerExpired = Time.timeSinceLevelLoad >= levelTime;
            // 
            if (timerExpired)
            {
                FindObjectOfType<LevelController>().TimerExpired();
                triggerLevelFinish = true;
            }
        }
        
    }
}
