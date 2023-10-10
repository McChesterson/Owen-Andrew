using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlast : MonoBehaviour
{
    public Vector3 fireDirection;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 15f;

    void Update()
    {
        fireDirection = GetComponent<PlayerMovement>().playerDirection;

        if (Input.GetKeyDown(KeyCode.C))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2 (fireDirection.x, fireDirection.y) * bulletForce, ForceMode2D.Impulse);

    }
}
