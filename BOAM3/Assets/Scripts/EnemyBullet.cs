using UnityEngine;
using TMPro;

public class EnemyBullet : MonoBehaviour
{    
    // my lazy way of handling enemy damage to the player.

    int health;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.tag = "Hurt";
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
