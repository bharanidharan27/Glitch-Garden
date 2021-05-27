using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    
    void Start()
    {
        PlayerPrefsController.SetMasterVolume(1f);
        Debug.Log("Returned master volume is " + PlayerPrefsController.GetMasterVolume());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
