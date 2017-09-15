using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public float startSpeed = 10f;
    [HideInInspector] public float speed;
    public float health = 100;
    public int worth = 50;
    public GameObject deathEffect;
    
    void Start()
    {
        speed = startSpeed;    
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += worth;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    public void Slow(float slowModifier)
    {
        speed = startSpeed * (1f - slowModifier);
    }
}
