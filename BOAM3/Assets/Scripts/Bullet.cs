using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.tag = "Dead";

            Destroy(gameObject);
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            Destroy(collision.gameObject, 1f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
