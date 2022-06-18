using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelSpawner : MonoBehaviour
{
    [SerializeField] private int SquirrelsAtStart;
    [SerializeField] private Squirrel squirrelPrefab;
    [SerializeField] private List<Transform> spawnPoints;

    private void Start()
    {
        for (int i = 0; i < SquirrelsAtStart; i++)
        {
            SpawnSquirrel();
        }
        StartCoroutine(WaitAndSpawn());
    }

    private IEnumerator WaitAndSpawn()
    {
        yield return new WaitForSeconds(2);
        SpawnSquirrel();
        StartCoroutine(WaitAndSpawn());
    }

    private void SpawnSquirrel()
    {
        Vector3 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
        Instantiate(squirrelPrefab, spawnPoint, Quaternion.identity);
    }

}
