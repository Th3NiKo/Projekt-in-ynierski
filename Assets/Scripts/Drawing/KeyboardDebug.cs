﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardDebug : MonoBehaviour {

    public float speed;

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += new Vector3(-speed, 0, 0);
        } else if(Input.GetKey(KeyCode.RightArrow)) {
            transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.position += new Vector3(0, 0, speed);
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            transform.position += new Vector3(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.E)) {
            transform.position += new Vector3(0, -speed, 0);
        } else if (Input.GetKey(KeyCode.Q)) {
            transform.position += new Vector3(0, speed, 0);
        }

    }
}
