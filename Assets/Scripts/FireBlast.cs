using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlast : MonoBehaviour
{
    public Vector3 fireDirection;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 15f;
    public bool fireReady = true;
    public float fireDelay = 0.5f;

    void Update()
    {
        fireDirection = GetComponent<PlayerMovement>().playerDirection;

        if (Input.GetKeyDown(KeyCode.C) && fireReady == true)
        {
            Shoot();
            Invoke("ShootAgain", fireDelay);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2 (fireDirection.x, fireDirection.y) * bulletForce, ForceMode2D.Impulse);
        fireReady = false;
    }

    void ShootAgain()
    {
        fireReady = true;
    }
}
