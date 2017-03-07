using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    GameManager gameManager;

    public float health = 100.0f;

    public Rigidbody rb;
    public float speed;

    // Use this for initialization
    void Start () {

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            gameManager.score =+ 1;
        }
    }
}
