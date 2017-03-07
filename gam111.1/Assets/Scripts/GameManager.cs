using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool playerAlive = true;
    public float bestScore, currentTime, bestTime;
    public int health, lives = 3, score = 0;

    // Use this for initialization
    void Start()
    {
        bestScore = PlayerPrefs.GetFloat("BestScore", 0);
        bestTime = PlayerPrefs.GetFloat("BestTime", 0);
        currentTime = 0;
    }

    // Update is called once per frame
    void Update () {
        //If 5 minutes pass, end the game
        if (currentTime == 300)
            SceneManager.LoadScene("gameover");
        //Increment currentTime if player is alive
        if (playerAlive)
            currentTime += Time.deltaTime;

        //If the player dies, load the game over scene, set the best score and time
        if (lives <= 0)
        {
            SceneManager.LoadScene("gameover");
            PlayerPrefs.SetFloat("BestScore", score);
            PlayerPrefs.SetFloat("BestTime", currentTime);
            playerAlive = false;
        }
    }
}
