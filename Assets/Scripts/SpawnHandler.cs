using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnHandler : MonoBehaviour
{
    // List of spawn locations
    public List<GameObject> spawners = new List<GameObject>();
    // The center of the game area
    public GameObject center;
    // The enemy that's being cloned 
    public GameObject enemy;

    private void Start()
    {
        // Start spawning enemies
        StartCoroutine(SpawnCycle());
    }

    IEnumerator SpawnCycle()
    {
        // Spawn a new enemy every 0.7 seconds
        yield return new WaitForSeconds(0.7f);
        SpawnEnemy();
        StartCoroutine(SpawnCycle());
    }

    GameObject SpawnEnemy()
    {
        // Creates newEnemy
        GameObject newEnemy;
        // Instantiates a new version of the original enemy
        newEnemy = Instantiate(enemy);
        // Spawns it at one of the spawners
        newEnemy.transform.position = spawners[Random.Range(1, spawners.Count)].transform.position;
        // Activates it
        newEnemy.SetActive(true);
        return newEnemy;
    }
}
