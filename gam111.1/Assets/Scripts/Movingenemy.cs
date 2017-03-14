using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingenemy : MonoBehaviour {

    public GameObject[] movePoints;
    public float moveSpeed = 5f;
    private int index = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement(movePoints);
	}
    //Move between two points
    void Movement(GameObject[] points)
    {
        transform.position = Vector3.MoveTowards(transform.position, points[index].transform.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, points[index].transform.position) < 3)
        {
            if (index == 1)
            {
                index = 0;
            }
            else index = 1;
        }
    }
}
