using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Myszka : MonoBehaviour {

	public float x { get; private set; }
	public float y { get; private set; }
	public float z { get; private set; } //Third axis

	public bool isClicked { get; private set; }

	public static Myszka instance;

	Vector3 lastPosition;
	public Vector3 mouseDelta;

	void Awake(){
		instance = this;
	}
	void Start(){
		z = 0.0f;
		
		lastPosition = Input.mousePosition;
	}
	void Update () {
		x = Input.mousePosition.x;
		y = Input.mousePosition.y;
		isClicked = Input.GetMouseButton (0);


		//To fill
		if(Input.GetKeyDown(KeyCode.Q)){
			z += 0.3f;
		} else if(Input.GetKeyDown(KeyCode.E)){
			z -= 0.3f;
		}
		mouseDelta = new Vector3(x,y,z) - lastPosition;
		lastPosition = new Vector3(x,y,z);
	}
	
	public Vector3 MousePosition(){
		return new Vector3(x,z,y);
	}
	public GameObject WhatMousePoints(){
 		RaycastHit hit; 
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
		if ( Physics.Raycast (ray,out hit,100.0f)){ 
			if(hit.transform!=null) { 
				return hit.transform.gameObject;
			}else {
				return null;
			}
		} else {
			return null;
		}
	}


}
