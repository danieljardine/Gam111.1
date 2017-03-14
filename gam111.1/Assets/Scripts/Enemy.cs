using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Player player;
    public float damage = 25;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //When colliding with a player, take 25 health
        void OnTriggerEnter(Collider other)
             {
            if (other.gameObject.CompareTag("Player"))
            {
                player.health -= 25;
            }
        }
}
