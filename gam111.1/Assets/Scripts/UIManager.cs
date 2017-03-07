using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    GameManager gameManager;
    GameObject[] pauseObjects;
    TextAlignment myText;
    public Text health, currentTime, score, bestScore;

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
        score.text = "Score: " + gameManager.bestScore;
        health.text = "Health: " + gameManager.health;
        bestScore.text = "Best Score: " + gameManager.bestScore;
        currentTime.text = "Current Time: " + gameManager.currentTime;

        //Pause Control
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
        //If time = 0 then game over
        if (gameManager.currentTime > 300)
        {
            SceneManager.LoadScene("gameover");
        }
    }
    public void Reload()
    {
        SceneManager.LoadScene("Lvl1");
    }
    public void pauseControl()
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
    //Show objects tagged with ShowOnPause
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }
    //Hide objects tagged with ShowOnPause
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
    //Load Main Menu
    public void mainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
