using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateDemo : IEnemyStateDemo
{
    enemyAIDemo myEnemy;

    public IdleStateDemo(enemyAIDemo enemy)
    {
        myEnemy = enemy;
    }

    public void UpdateState()
    {
        myEnemy.GetComponent<Renderer>().material.color = Color.green;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            myEnemy.currentState = myEnemy.alertState;
        }
    }

    public void OnTriggerStay(Collider col) { }
    public void OnTriggerExit(Collider col) { }
}