using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GunShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 50f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<BulletDamage>().shooterTag = "Player";
        Debug.Log("player shot!");
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * bulletSpeed;
        Destroy(bullet, 50f); // cleanup after 5 seconds
    }
}
