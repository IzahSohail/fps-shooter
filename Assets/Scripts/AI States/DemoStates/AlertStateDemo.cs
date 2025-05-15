using UnityEngine;
using System.Collections;


public class AlertStateDemo : IEnemyStateDemo
{
    enemyAIDemo myEnemy;

    public AlertStateDemo(enemyAIDemo enemy)
    {
        myEnemy = enemy;
    }

    public void UpdateState()
    {
        myEnemy.GetComponent<Renderer>().material.color = Color.red;

        if (myEnemy.player != null)
        {
            Vector3 lookDir = myEnemy.player.position - myEnemy.transform.position;
            lookDir.y = 0;
            Quaternion targetRot = Quaternion.LookRotation(lookDir);
            myEnemy.transform.rotation = Quaternion.Slerp(myEnemy.transform.rotation, targetRot, Time.deltaTime * 2);
            GoToAttackState();
        }
    }

    public void GoToAttackState()
    {
        Debug.Log("Switched to Attack State");
        myEnemy.currentState = myEnemy.attackState;
    }


    public void OnTriggerEnter(Collider col) { }

    public void OnTriggerStay(Collider col) { }

    public void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            myEnemy.currentState = myEnemy.idleState;
        }
    }
}


