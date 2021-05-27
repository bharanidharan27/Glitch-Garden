using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 1f;
    GameObject currentTarget;
    Health health;
    float difficultyLevel;

    void Start()
    {
        health = GetComponent<Health>();
        difficultyLevel = PlayerPrefsController.GetDifficulty();
        if (difficultyLevel == 0)
        {
            health.health = health.defaultHealth;
        }
        else if (difficultyLevel == 1)
        {
            // health.health = health.defaultHealth;
            health.health += 100;
        }
        else if (difficultyLevel == 2)
        {
            // health.health = health.defaultHealth;
            health.health += 300;
        }
    }

    private void Awake()
    {
        //Debug.Log("Attacker Spawned");
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        //Debug.Log("Attacker Killed");
        LevelController levelController = FindObjectOfType<LevelController>();
        if(levelController != null)
        {
            levelController.AttackerKilled();
        }
        
    }
    
    void Update()
    {
        // Moves the gameobject towards left direction
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed; 
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    private void StrikeCurrentObject(float damage)
    {
        if(!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if(health)
        {
            health.DealDamage(damage);
        }

    }

}
