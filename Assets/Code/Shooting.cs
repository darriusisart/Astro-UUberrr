using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    private bool canShoot = true;

    void Update()
    {
        if (canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
            canShoot = false;
            Invoke("ResetShootFlag", 1f); // Call ResetShootFlag function after 1 second
        }
    }

    void ShootBullet()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
    }

    void ResetShootFlag()
    {
        canShoot = true;
    }
}
