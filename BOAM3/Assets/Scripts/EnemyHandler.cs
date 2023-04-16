using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHandler : MonoBehaviour
{
    // --------- Variables ---------
    public float speed = 2f;
    public Rigidbody2D rb;
    public Transform player;
    public Weapon weapon;
    public TextMeshProUGUI scoreUI;
    bool done = false;

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

    private void FixedUpdate()
    {
        if (gameObject.tag == "Dead")
        {   
            if (done == true)
            {
                return;
            }
            int score = int.Parse(scoreUI.text);

            score += 10;

            scoreUI.text = score.ToString();

            if (score > 199)
            {
                Destroy(gameObject);
            }

            done = true;
            return;
        }
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        direction.Normalize();
        Vector2 moveDirection = direction;
        rb.velocity = moveDirection * speed;

        // shoot at random intervals (bad method?)
        if (Random.Range(0, 1000) < 10)
        {
            weapon.Fire();
        }
    }
}
