using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    // Player score
    public int score;
    // Text displaying score
    public Text scoreText;
    // Time remaining
    private int timeLeft = 60;
    // Text displaying time remaining
    public Text timerText;
    // The canvas housing the game over menu
    public GameObject gameOver;
    // The text displaying the final score
    public Text finalScore;
    private void Start()
    {
        // Starts the timer
        StartCoroutine(Timer());
        // Makes sure the game is running in the correct timescale
        Time.timeScale = 1;
    }

    public void AddScore()
    {
        // Increases score by one
        score++;
    }

    private void Update()
    {
        // Sets the score text and time left text
        scoreText.text = "Score: " + score;
        timerText.text = "Time left: " + timeLeft;
        // If timer has finished
        if (timeLeft <= 0)
        {
            // Activate the game over canvas
            gameOver.SetActive(true);
            // set timescale to 0
            Time.timeScale = 0;
            // Display final score
            finalScore.text = "You destroyed " + score + " enemy ships!";
        }
    }

    IEnumerator Timer()
    {
        // Makes the timer tick down once per second
        yield return new WaitForSeconds(1);
        timeLeft -= 1;
        StartCoroutine("Timer");
    }
}
