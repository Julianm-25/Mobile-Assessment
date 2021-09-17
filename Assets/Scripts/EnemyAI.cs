using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    // The enemy
    public GameObject enemy;
    // Center of the game area
    public GameObject center;
    // Speed the enemy is moving at
    public float speed;
    // The empty GameObject housing the ScoreHandler script
    public GameObject scoreHandler;
    // Bool that indicates whether it is turbo mode or not
    public bool isTurbo;
    private void OnMouseDown()
    {
        // If you click on an enemy, they die
        KillEnemy();
    }

    private void Start()
    {
        // Sets the speed to a random number between 10 and 50
        speed = Random.Range(10f, 50f);
        // If the game is in turbo mode
        if (isTurbo)
        {
            // TRIPLE the speed
            speed *= 3;
        }
        // Makes the enemy face the center of the game area
        enemy.transform.LookAt(center.transform);
    }

    private void Update()
    {
        // Makes the enemy move towards the direction they are facing
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        var transformPosition = enemy.transform.position;
        // Keeps the enemy at 0 on the z axis
        transformPosition.z = 0;
        // Updates the position
        enemy.transform.position = transformPosition;
    }
    private void KillEnemy()
    {
        // Increases score by one
        scoreHandler.GetComponent<ScoreHandler>().AddScore();
        // Gets rid of the enemy
        Destroy(enemy);
    }
}