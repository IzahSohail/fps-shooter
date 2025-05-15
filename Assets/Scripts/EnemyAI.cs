using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypoint = 0;

    public NavMeshAgent agent;
    public Transform player;
    public float detectionRadius = 10f;
    public float attackRadius = 6f;
    public float fireRate = 1f;
    private float lastShotTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= attackRadius)
        {
            agent.isStopped = true;
            transform.LookAt(player);
            Shoot();
        }
        else if (distance <= detectionRadius)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (waypoints.Length == 0) return;

        agent.SetDestination(waypoints[currentWaypoint].position);
        if (agent.remainingDistance <= 0.5f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }

    void Shoot()
    {
        if (Time.time - lastShotTime > fireRate)
        {
            Debug.Log("Enemy shooting player!");
            lastShotTime = Time.time;
            // You can reduce player health here later
        }
    }
}
