using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public float speed;

    private Transform target;
    private int currentWaypointIndex = 0;

    void Start()
    {
        target = WayPoints.points[0];
    }
    
    void Update()
    {
        var direction = target.position - transform.position;
        transform.Translate(direction.normalized * Time.deltaTime * speed, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (currentWaypointIndex == WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        currentWaypointIndex++;
        target = WayPoints.points[currentWaypointIndex];
    }
}
