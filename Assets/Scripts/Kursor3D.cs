using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Technical.COM;
/*

Na przyszlosc zrobic z tego statica wzorzec singleton

 */
public class Kursor3D : MonoBehaviour {

	Vector3 position;
	float speed = 5000f;

	public GameObject COMobj;
    COM com1;
	//public GameObject block;
	//HingeJoint test;
	//Rigidbody rgb;

	bool isClicked;
	bool isPressed;
	Collider obj;
	Vector3 lastPosition;
	Vector3 lastAngle;
	public Vector3 delta;
	public Vector3 positionsSpeed = new Vector3(1.0f, 1.0f, 1.0f);
	public Vector3 anglesPosition;
	public Vector3 anglesDelta;
	public Vector3 anglesSpeed = new Vector3(1.0f, 1.0f, 1.0f);
	
	float t;
	void Start () {
		t = 0.1f;
		position = new Vector3(0.0f, 0.0f, 0.0f);
		anglesPosition = new Vector3(0.0f, 0.0f, 0.0f);
		anglesDelta = new Vector3(0.0f, 0.0f, 0.0f);
		com1 = COMobj.GetComponent<COM>();
		isClicked = false;
		lastPosition = position;
		obj = null;
		isPressed = false;
	}
	
	
	void Update () {
		//Simulating input
		/* 
		float distortion = Random.Range(0,100);
		float sign = Random.Range(0,2);
		if(sign == 0){
			position += new Vector3(distortion, distortion, 0.0f);
			anglesPosition += new Vector3(distortion, distortion, distortion);
		} else {
			position -= new Vector3(distortion, distortion, 0.0f);
			anglesPosition -= new Vector3(distortion, distortion, distortion);
		} */
		//***************************************/
		
		//X Y Z
		if(Input.GetKey(KeyCode.LeftArrow)){
			position = Vector3.Lerp(position, position + new Vector3(-speed, 0.0f, 0.0f),t);
		} if(Input.GetKey(KeyCode.RightArrow)){
			position = Vector3.Lerp(position,position + new Vector3(speed, 0.0f, 0.0f),t);
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			position = Vector3.Lerp(position, position + new Vector3(0.0f, 0.0f, -speed),t);
		} if(Input.GetKey(KeyCode.UpArrow)){
			position = Vector3.Lerp(position, position + new Vector3(0.0f, 0.0f, speed),t);
		}

		if(Input.GetKey(KeyCode.Q)){
			position = Vector3.Lerp(position, position + new Vector3(0.0f, speed, 0.0f),t);
		} if(Input.GetKey(KeyCode.E)){
			position = Vector3.Lerp(position, position + new Vector3(0.0f, -speed, 0.0f),t);
		}


		//Angles 1 2 3
		if(Input.GetKey(KeyCode.Alpha1)){
			anglesPosition = Vector3.Lerp(anglesPosition, anglesPosition + new Vector3(-speed, 0.0f, 0.0f),t);
		} if(Input.GetKey(KeyCode.Alpha2)){
			anglesPosition = Vector3.Lerp(anglesPosition, anglesPosition + new Vector3(speed, 0.0f, 0.0f),t);
		}
		if(Input.GetKey(KeyCode.Alpha3)){
			anglesPosition = Vector3.Lerp(anglesPosition, anglesPosition + new Vector3(0.0f, 0.0f, -speed),t);
		} if(Input.GetKey(KeyCode.Alpha4)){
			anglesPosition = Vector3.Lerp(anglesPosition, anglesPosition + new Vector3(0.0f, 0.0f, speed),t);
		}

		if(Input.GetKey(KeyCode.Alpha5)){
			anglesPosition = Vector3.Lerp(anglesPosition, anglesPosition + new Vector3(0.0f, speed, 0.0f),t);
		} if(Input.GetKey(KeyCode.Alpha6)){
			anglesPosition = Vector3.Lerp(anglesPosition, anglesPosition + new Vector3(0.0f, -speed, 0.0f),t);
		}

		
		//position = com1.LoadPositions();
		//anglesPosition = com1.LoadAngles();


		if(Input.GetKey(KeyCode.LeftShift)){ 
			isClicked = !isClicked;
		} 

		if(Input.GetKey(KeyCode.LeftShift)){
			isPressed = true;
		} else {
			isPressed = false;
		}

		if(obj != null){
			obj.transform.position = this.transform.position;
				//obj.transform.position =  Vector3.Lerp(obj.transform.position, (position - lastPosition) + obj.transform.position,1.0f);
			if(obj.GetComponent<HingeJoint>() != null){
					HingeJoint temp = obj.GetComponent<HingeJoint>();
					temp.connectedBody = GetComponent<Rigidbody>();
					temp.connectedAnchor = this.transform.position;
					temp.anchor = this.transform.position;
				}
		}
		//	delta = (lastPosition - position) / 5000;
		delta = lastPosition - position;
		anglesDelta = lastAngle - anglesPosition;
		//deltaAngles
		lastPosition = position;
		lastAngle = anglesPosition;

	}

	public Vector3 GetPosition(){
		return new Vector3(position.x * positionsSpeed.x, position.y * positionsSpeed.y,anglesPosition.y * anglesSpeed.y);
	}

	public Vector3 GetAngles(){
		return new Vector3(anglesPosition.x * anglesSpeed.x,anglesPosition.y * anglesSpeed.y,anglesPosition.z * anglesSpeed.z);
	}

	public bool IsPressed(){
		return isPressed;
	}

}
