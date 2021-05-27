using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField] float health = 500;
    Text healthText;
    bool healthReachedZero = false;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        UpdateDisplay();

    }

    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }

    public void DecreaseHealth()
    {
        if(!healthReachedZero)
        {
            health -= 100;
            UpdateDisplay();
            if(health <= 0)
            {
                FindObjectOfType<LevelController>().PlayerDefeated();
            }
        }
    }

    public void IncreaseHealth()
    {
        health += 100;
        UpdateDisplay();
    }
}
