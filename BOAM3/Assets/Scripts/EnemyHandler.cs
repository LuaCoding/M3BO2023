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
    public TextMeshProUGUI killUI;
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

    // move to player in a 2D plane
    private void FixedUpdate()
    {
        if (gameObject.tag == "Dead")
        {   
            if (done == true)
            {
                return;
            }
            int score = int.Parse(scoreUI.text);
            int kill = int.Parse(killUI.text);

            score += 10;
            kill += 1;

            scoreUI.text = score.ToString();
            killUI.text = kill.ToString();

            done = true;
            return;
        }
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        direction.Normalize();
        Vector2 moveDirection = direction;
        rb.velocity = moveDirection * speed;

        // shoot at player at random intervals
        if (Random.Range(0, 1000) < 10)
        {
            weapon.Fire();
        }
    }
}
