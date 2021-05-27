using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public float health = 100f;
    public float defaultHealth = 100f;
    [SerializeField] GameObject deathVFX;
    LevelController levelController;

    public void DealDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            TriggerDestroyVFX();
            Destroy(gameObject);
        }
    }

    public void TriggerDestroyVFX()
    {
        if(!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject);
    }
}
