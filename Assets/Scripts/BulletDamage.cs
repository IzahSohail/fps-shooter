using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletDamage : MonoBehaviour
{
    public float damage = 20f;
    public string shooterTag; // "Player" or "Enemy"

    void Start()
    {
        Debug.Log("ShooterTag is: " + shooterTag);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(shooterTag))
            return;

        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            Debug.Log("Bullet hit: " + collision.gameObject.name);
            health.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}

