using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    // vars
    public GameObject powerupPrefab;
    public GameObject intro;
    int randomPup = 0;
    public Transform newPup;
    bool spawned = false;
    void Update()
    {  
        if (Mathf.Round(Time.time) % 5 == 0 && intro.activeSelf == false && spawned == false)
        {
            randomPup = Random.Range(0, 1);

            newPup = powerupPrefab.transform.GetChild(randomPup); // random powerup from child index
            Vector2 randompos = new Vector2(Random.Range(-11f,11f), Random.Range(-4f, 4f));
            Instantiate(newPup, randompos, Quaternion.identity);
            Instantiate(powerupPrefab, randompos, Quaternion.identity);

            spawned = true;
        }

        return;
    }
}
