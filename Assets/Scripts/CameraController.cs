﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cam;
    public Player player;
    public Vector3 cameraDistanceOffset;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + cameraDistanceOffset.x, 0, player.transform.position.z + cameraDistanceOffset.z);
        //transform.position = Vector3.Lerp(new Vector3(0, 0, -7.35f), new Vector3(0, 0, -9.35f), Time.deltaTime);        
    }
}
