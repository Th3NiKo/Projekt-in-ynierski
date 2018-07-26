using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorOnBoxFly : MonoBehaviour {

	[SerializeField] Vector3 position;
	[SerializeField] Vector3 angles;

	public float MaxRangeInput = 10000;
	public float MaxRangeOutput = 4;

	private float Divide;
	public bool Keyboard = false;
	float speed = 100;
	public
	COM msg;
	void Start () {
		Divide = MaxRangeInput / MaxRangeOutput;
		msg = Camera.main.GetComponent<COM>();
	}
	
	
	void Update () {
		if(!Keyboard){
		position = msg.LoadPositions ();
		angles = msg.LoadAngles();
		} else {
			KeyboardMovement();
		}

		Vector3 newPos = new Vector3(position.x / Divide, position.y / Divide, -angles.z / Divide);
		this.transform.position = newPos;

		transform.rotation = Quaternion.Euler(184,
											 Mathf.Clamp(angles.x / 266, -45, 45),
											 Mathf.Clamp(angles.y / 266, -45, 45));
											
		
	}


	void KeyboardMovement(){
		//Forward Backward
		if(Input.GetKey(KeyCode.W)){
			angles.z -= speed;
		}
		if(Input.GetKey(KeyCode.S)){
			angles.z += speed;
		}

		//Right Left
		if(Input.GetKey(KeyCode.A)){
			position.x -= speed;
		}
		if(Input.GetKey(KeyCode.D)){
			position.x += speed;
		}
	}
}
