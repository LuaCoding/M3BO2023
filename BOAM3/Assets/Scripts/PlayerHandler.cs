using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHandler : MonoBehaviour
{
    // --------- Variables ---------
    public float speed = 20f;
    public Rigidbody2D rb;
    public Weapon weapon;
    public GameObject spawnhandler;
    public GameObject status;
    public GameObject main;

    Vector2 moveDirection;
    Vector2 mousePosition;
    public TextMeshProUGUI healthmeter;
    // ----------- End --------------

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (gameObject.tag == "Hurt")
        {
            int health = int.Parse(healthmeter.text);
            health -= 10;
            healthmeter.text = health.ToString();
            if (health <= 0)
            {
                spawnhandler.SetActive(false);

                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

                foreach (GameObject enemy in enemies)
                {
                    Destroy(enemy);
                }

                gameObject.tag = "Dead";
                gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                main.SetActive(false);
                status.SetActive(true);
                return;
            }
            else
            {
                gameObject.tag = "Player";
            }
            gameObject.tag = "Player";
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    
        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }
}