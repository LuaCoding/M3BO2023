using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    // --------- Variables ---------
    public float speed = 2f;
    public Rigidbody2D rb;
    public Transform player;

    // ----------- End -------------

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player hit by enemy");
        }
    }

    // move to player in a 2D plane
    private void FixedUpdate()
    {
        if (gameObject.tag == "Dead")
        {
            return;
        }
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        direction.Normalize();
        Vector2 moveDirection = direction;
        rb.velocity = moveDirection * speed;
    }
}
