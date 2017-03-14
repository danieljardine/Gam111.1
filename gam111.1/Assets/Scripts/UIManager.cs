using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    Player player;
    GameObject[] pauseObjects;
    Text myText;
    public Text health, lives, currentTime, score, bestScore, bestTime;

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        //Pause Controls
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
    }

    // Update is called once per frame
    void Update() {
        //Show relative texts
        score.text = "Score: " + player.score;
        health.text = "Health: " + player.health;
        lives.text = "Lives: " + player.lives;
        bestScore.text = "Best Score: " + player.bestScore;
        bestTime.text = "Best Time: " + player.bestTime;
        currentTime.text = "Time: " + player.currentTime;

        //Pause control
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }
    //Reloads the Level
    //Reload doesn't want to work properly
 /*   public void Reload()
    {
        SceneManager.LoadScene("Lvl1");
          player.score = 0;
          player.health = 100;
          player.lives = 3;
          player.currentTime = 0;
    }*/
    public void Quit()
    {
        Application.Quit();
    }
    public void pauseControl()
    //Determines if the game is paused or not
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }
    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }
    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
    //loads Main Menu
    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
