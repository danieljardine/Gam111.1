using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float bestScore, currentTime;
    public int health, score = 0;

    // Use this for initialization
    void Start()
    {
        bestScore = PlayerPrefs.GetFloat("BestScore", 0);
        currentTime = 0;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
