using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float health = 100, speed, lives = 3, bestScore, currentTime, bestTime;
    public int score;
    public bool playerAlive = true;
    //Initial position and rotation
    private Vector3 initialPos;
    private Quaternion initialRotation;
    
    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        //Player preference variables
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestTime = PlayerPrefs.GetFloat("BestTime", 0);
        currentTime = 0;

        //Initial rotation/position
        initialPos = transform.position;
        initialRotation = transform.rotation;
    }
	
	// Update is called once per frame
    //If the player is alive, increment time
	void Update () {
        if (playerAlive)
            currentTime += Time.deltaTime;

        //If the player dies playerAlive is false
        if (lives <= 0){
            playerAlive = false;
        }
        if (health == 0){
            lives -= 1;
            health += 100;
            transform.rotation = initialRotation;
            transform.position = initialPos;
        }
        if (playerAlive == false)
        {
            SceneManager.LoadScene("Game Over");
            PlayerPrefs.SetInt("BestScore", score);
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
    }

    public float ClampValue(float value, float minvalue, float maxvalue)
    {
        //Returns clamp value
        if (value < minvalue){
            value = minvalue;
        }

        else if (value > maxvalue){
            value = maxvalue;
        }
        return value;
    }

    //Move the player based on axis, clamp the players speed between reasonable values
    void FixedUpdate()
        {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        speed = ClampValue(speed, -50, 100);
        }

    //When the player collides with a certain tagged item, run specific code
     void OnTriggerEnter(Collider other)
        {
         if (other.gameObject.CompareTag("Pick Up"))
         {
               other.gameObject.SetActive(false);
               score += 10;
         }

        if (other.gameObject.CompareTag("Flag"))
        {
            SceneManager.LoadScene("Lvl2");
            DontDestroyOnLoad(gameObject);
            transform.rotation = initialRotation;
            transform.position = initialPos;
        }

        if (other.gameObject.CompareTag("End"))
        {
              SceneManager.LoadScene("Game Over");
              PlayerPrefs.SetInt("BestScore", score);
              PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        if (other.gameObject.CompareTag("Speed"))
        {
            speed += 50;
        }
        if (other.gameObject.CompareTag("Reverse"))
        {
            speed -= 23;
        }
    }
}
