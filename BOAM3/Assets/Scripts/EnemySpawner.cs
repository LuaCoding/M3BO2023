using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // spawn enemies
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnRate = 2f;
    float nextSpawn = 0f;

    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            nextSpawn = Time.time + 1f / spawnRate;
        }
    }
}
