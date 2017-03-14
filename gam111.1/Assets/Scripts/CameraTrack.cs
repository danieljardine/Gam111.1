using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        //Follow the players position
        offset = transform.position - player.transform.position;
        DontDestroyOnLoad(gameObject);
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}