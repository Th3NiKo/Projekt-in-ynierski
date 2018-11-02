using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {
	/*
	 * Name of GameObject has to be Cursor to work properly with turning on/off sounds.
	 * 
	 * 
	 * 
	 * */

	[SerializeField] Vector2 position;
	[SerializeField] Vector3 angles;
	[Range(0,50000)] public float sensitivity = 10000;
	MessageReceiver msg;
	Rigidbody rgb;


	void Start(){
		
		position = new Vector2 (0, 0);
		angles = new Vector3 (0,0,0);
		msg = GameObject.Find ("Controler").GetComponent<MessageReceiver>();
		rgb = GetComponent<Rigidbody> ();


	}

	void FixedUpdate(){
		position = msg.LoadPositions ();
		angles = msg.LoadAngles ();
		rgb.velocity = new Vector3 (position.x / sensitivity, position.y / sensitivity, -angles.z / sensitivity);
	}


}
