using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShooter : MonoBehaviour
{

    [SerializeField] [Range(0, 10)] float currentSpeed = 1;
    [SerializeField] float projectileDamage = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //otherCollider.GetComponent<Health>().DealDamage(projectileDamage);
        //or
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        if(attacker && health)
        {
            health.DealDamage(projectileDamage);
            Destroy(gameObject);
        }
        
    }
}
