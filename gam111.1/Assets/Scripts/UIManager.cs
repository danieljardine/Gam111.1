using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    GameManager gameManager;
    GameObject[] pauseObjects;
    Text myText;
    public Text health, lives, currentTime, score, bestScore;

    // Use this for initialization
    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        //Pause Controls
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
    }

    // Update is called once per frame
    void Update() {
        //Show relative texts
        score.text = "Score: " + gameManager.score;
        health.text = "Health: " + gameManager.health;
        lives.text = "Lives: " + gameManager.lives;
        bestScore.text = "Best Score: " + gameManager.bestScore;
        currentTime.text = "Time: " + gameManager.currentTime;

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
        //If time = 0 then load the game over screen
        if (gameManager.currentTime > 300)
        {
            SceneManager.LoadScene("gameover");
        }
    }
    //Reloads the Level
    public void Reload()
    {
        SceneManager.LoadScene("artillery");
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
        SceneManager.LoadScene("mainmenu");
    }
}
