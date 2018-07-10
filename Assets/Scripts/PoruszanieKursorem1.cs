﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoruszanieKursorem1 : MonoBehaviour {

	Kursor3D kursor;
	public static bool canMove = true;
	void Start () {
		kursor = GetComponent<Kursor3D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(canMove){
			this.transform.position += kursor.GetPosition() / 85f;
		}
	}

	public static void BlockMovement(){
		canMove = false;
	}

	public static void UnlockMovement(){
		canMove = true;
	}
}
