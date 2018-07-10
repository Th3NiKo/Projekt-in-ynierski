using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoruszanieKursorem : MonoBehaviour {

	[SerializeField] Vector2 position;
	[SerializeField] Vector3 angles;
	[Range(0,50000)] public float sensitivity = 10000;
	COM msg;
	public static bool canMove = true;
	Rigidbody rgb;
	void Start () {
		position = new Vector2 (0, 0);
		angles = new Vector3 (0,0,0);
		msg = Camera.main.GetComponent<COM>();
		rgb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(canMove){
			position = msg.LoadPositions ();
			angles = msg.LoadAngles ();
			rgb.velocity = new Vector3 (position.x / sensitivity, position.y / sensitivity, -angles.z / sensitivity);
		} else {
			rgb.velocity = Vector3.zero;
		}
	}

	public static void BlockMovement(){
		canMove = false;
	}

	public static void UnlockMovement(){
		canMove = true;
	}
}
