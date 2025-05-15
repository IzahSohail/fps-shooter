using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackStateDemo : IEnemyStateDemo
{
    enemyAIDemo myEnemy;

    public AttackStateDemo(enemyAIDemo enemy)
    {
        myEnemy = enemy;
    }

    public void UpdateState()
    {
        // Look at player
        Vector3 direction = myEnemy.player.position - myEnemy.transform.position;
        direction.y = 0;
        myEnemy.transform.rotation = Quaternion.LookRotation(direction);

        // Try to shoot
        if (Time.time >= myEnemy.nextFireTime)
        {
            Shoot();
            //Debug.Log("Enemy shot a bullet at: " + Time.time);
            myEnemy.nextFireTime = Time.time + 1f / myEnemy.fireRate;
        }
    }

    private void Shoot()
    {
        GameObject bullet = GameObject.Instantiate(myEnemy.bulletPrefab, myEnemy.firePoint.position, myEnemy.firePoint.rotation);

        BulletDamage bulletDamage = bullet.GetComponent<BulletDamage>();
        if (bulletDamage != null)
        {
            bulletDamage.shooterTag = "Enemy";
        }

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(myEnemy.firePoint.forward * 500f);
        }

        GameObject.Destroy(bullet, 5f);
    }


    public void GoToAlertState() { myEnemy.currentState = myEnemy.alertState; }
    public void GoToIdleState() { myEnemy.currentState = myEnemy.idleState; }
    public void GoToPatrolState() { myEnemy.currentState = myEnemy.patrolState; }
    public void OnTriggerEnter(Collider col) { }
    public void OnTriggerStay(Collider col) { }
    public void OnTriggerExit(Collider col) { }
    public void Impact() { }
}
