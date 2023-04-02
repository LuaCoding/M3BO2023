using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    // --------- Variables ---------
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI killUI;

    int score = 0;
    int kills = 0;
    int playerHP = 100;
    // ----------- End -------------
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.tag = "Dead";
            Destroy(gameObject);
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            Destroy(collision.gameObject, 1f);

            kills++;
            score += 10;

            scoreUI.text = "Score: " + score.ToString();
            killUI.text = "Kills: " + kills.ToString();

            Debug.Log("Kills: " + kills);
            Debug.Log("Score: " + score);
        }
        else if (collision.gameObject.tag == "Player")
        {
            // Adds damage effect on player
            Destroy(gameObject);
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            playerHP -= 10;
            if (playerHP <= 0)
            {
                Destroy(collision.gameObject);
            }
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
