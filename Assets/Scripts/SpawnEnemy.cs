using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 10f;
    public float spawnInterval = 3f;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void Spawn()
    {
        Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        randomPosition.y = 0;
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    }
}