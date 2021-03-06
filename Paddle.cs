﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float PaddleSpeed = 1f;
    private Vector3 PlayerPos = new Vector3(0, -9.5f, 0);
    
	
	void Update () {

        float xPos = transform.position.x + Input.GetAxis("Horizontal") * PaddleSpeed;
        PlayerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0);
        transform.position = PlayerPos;


    }
}
