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
    }

    private IEnumerator WaitAndSpawn()
    {
        yield return new WaitForSeconds(10);
        SpawnSquirrel();
    }

    private void SpawnSquirrel()
    {
        Vector3 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
        Instantiate(squirrelPrefab, spawnPoint, Quaternion.identity);
    }

}
