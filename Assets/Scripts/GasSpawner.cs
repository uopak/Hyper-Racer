using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasSpawner : MonoBehaviour
{
    public GameObject gasPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 3f;

    void Start()
    {
        InvokeRepeating("SpawnGas", 1f, spawnInterval);
    }

    void SpawnGas()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(gasPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }
}
