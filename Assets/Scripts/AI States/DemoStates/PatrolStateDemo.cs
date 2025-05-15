//using UnityEngine;
using UnityEngine;
using UnityEngine.AI;

public class PatrolStateDemo : IEnemyStateDemo
{
    private enemyAIDemo myEnemy;
    private int currentWaypoint = 0;

    public PatrolStateDemo(enemyAIDemo enemy)
    {
        myEnemy = enemy;
    }

    public void UpdateState()
    {
        //myEnemy.GetComponent<Renderer>().material.color = myEnemy.greenMaterial;

        // Set destination if not already moving
        if (!myEnemy.agent.hasPath || myEnemy.agent.remainingDistance < 0.5f)
        {
            myEnemy.agent.SetDestination(myEnemy.waypoints[currentWaypoint].position);
            currentWaypoint = (currentWaypoint + 1) % myEnemy.waypoints.Length;
        }
    }

    public void GoToAlertState()
    {
        myEnemy.agent.isStopped = true;
        myEnemy.currentState = myEnemy.alertState;
    }

    public void GoToIdleState() { }
    public void GoToPatrolState() { }

    public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            GoToAlertState();
        }
    }

    public void OnTriggerStay(Collider col) { }
    public void OnTriggerExit(Collider col) { }

    public void Impact()
    {
        GoToAlertState();
    }
}
