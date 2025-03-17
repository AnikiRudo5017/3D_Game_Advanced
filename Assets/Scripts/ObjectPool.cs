using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject spherePrefab;
    public Transform spawnPoint;
    public int poolSize = 10;
    public float spawnRate = 1f;
    public float forceAmount = 5f;

    private Queue<GameObject> spherePool;

    void Start()
    {
        spherePool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(spherePrefab);
            obj.SetActive(false);
            spherePool.Enqueue(obj);
        }
        StartCoroutine(SpawnSpheres());
    }

    IEnumerator SpawnSpheres()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            SpawnSphere();
        }
    }

    void SpawnSphere()
    {
        if (spherePool.Count > 0)
        {
            GameObject sphere = spherePool.Dequeue();
            sphere.transform.position = spawnPoint.position;
            sphere.SetActive(true);
            Rigidbody rb = sphere.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 10f, Random.Range(-1f, 1f)).normalized;
                rb.linearVelocity = randomDirection * forceAmount;
            }
        }
    }

    public void ReturnToPool(GameObject sphere)
    {
        sphere.SetActive(false);
        spherePool.Enqueue(sphere);
    }
}
