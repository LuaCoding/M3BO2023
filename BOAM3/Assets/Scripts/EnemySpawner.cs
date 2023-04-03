using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnRate = 2f;
    float nextSpawn = 0f;

    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            enemyPrefab.GetComponent<EnemyHandler>().enabled = true;

            Vector2 randompos = new Vector2(Random.Range(-11f,-7f), Random.Range(-4f, 4f));
            Instantiate(enemyPrefab, randompos, Quaternion.identity);

            nextSpawn = Time.time + 1f / spawnRate;
        }
    }
}
