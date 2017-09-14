using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public float speed;
    public int health = 100;
    public int moneyForKill = 50;

    public GameObject deathEffect;

    private Transform target;
    private int currentWaypointIndex = 0;

    void Start()
    {
        target = WayPoints.points[0];
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += moneyForKill;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    void Update()
    {
        var direction = target.position - transform.position;
        transform.Translate(direction.normalized * Time.deltaTime * speed, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (currentWaypointIndex == WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        currentWaypointIndex++;
        target = WayPoints.points[currentWaypointIndex];
    }

    private void EndPath()
    {
        PlayerStats.Lives--;

        Destroy(gameObject);
    }
}
