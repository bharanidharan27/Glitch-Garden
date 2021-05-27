using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile, gunPosition;
    [SerializeField] AttackerSpawner[] spawners;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject parentProjectile;
    const string PARENT_PROJECTILE_NAME = "Projectile";

    void Start()
    {
        parentProjectile = GameObject.Find(PARENT_PROJECTILE_NAME);
        if(!parentProjectile)
        {
            parentProjectile = new GameObject(PARENT_PROJECTILE_NAME);
        }
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(IsAttackerInLane())
        {
            // change animation state to shoot
            animator.SetBool("IsAttacking", true);
            Debug.Log("shoot");
        }
        else
        {
            // change animation state to idle
            animator.SetBool("IsAttacking", false);
            Debug.Log("wait");
        }
    }

    void SetLaneSpawner()
    {
        spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if(IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    bool IsAttackerInLane()
    {
        // if child of lanespawner is less than or equal to zero return false  
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gunPosition.transform.position, Quaternion.identity);
        newProjectile.transform.parent = parentProjectile.transform;
    }



}
