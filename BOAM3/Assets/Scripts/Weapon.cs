using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float force = 20f;

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * force, ForceMode2D.Impulse); // ~25 force is perfect for player, 5-10 for the enemies makes the game fair
    }

    public void Grapeshot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * force, ForceMode2D.Impulse);

        GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position * new Vector2(0.1f, 0.1f), firePoint.rotation);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePoint.up * force, ForceMode2D.Impulse);

        GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position * new Vector2(0.2f, 0.2f), firePoint.rotation);
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb3.AddForce(firePoint.up * force, ForceMode2D.Impulse);
    }
}