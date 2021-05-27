using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackerPrefab;
    public bool spawn = true;
    LevelController levelController;

    [SerializeField] float minTimeDelay = 1f;
    [SerializeField] float maxTimeDelay = 5f;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
      
      while (spawn)
      {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minTimeDelay, maxTimeDelay));
            SpawnAttackers();
      }  
    }

    void SpawnAttackers()
    {
        int index = UnityEngine.Random.Range(0, attackerPrefab.Length);
        Spawn(index);
    }


    private void Spawn(int index)
    {
        Attacker newAttacker = Instantiate(attackerPrefab[index], transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }

    public void StopSpawning()
    {
        spawn = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

    
