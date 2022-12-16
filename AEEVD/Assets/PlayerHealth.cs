using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;
    
    void Start()
    {
        alive = true;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            health = 0;
            alive = false;
            Debug.Log("Player Dead");
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public bool alive{get; private set;}
}
