using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
	private Transform target;
    private int currentWaypointIndex = 0;
	private Enemy enemy;

	 void Start()
    {
        target = WayPoints.points[0];
		enemy = GetComponent<Enemy>();
    }

	void Update()
    {
        var direction = target.position - transform.position;
        transform.Translate(direction.normalized * Time.deltaTime * enemy.speed, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            GetNextWaypoint();
        }

		enemy.speed = enemy.startSpeed;
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
