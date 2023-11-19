using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawners;
    public float spawnInterval = 3f;
    public int maxEnemies = 10;
    private int currentEnemyCount = 0;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (currentEnemyCount < maxEnemies)
        {
            Transform randomSpawner = spawners[Random.Range(0, spawners.Length)];

            GameObject newEnemy = Instantiate(enemyPrefab, randomSpawner.position, Quaternion.identity);

            newEnemy.transform.parent = randomSpawner;

            currentEnemyCount++;
        }
    }
}
