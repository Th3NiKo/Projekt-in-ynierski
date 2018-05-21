using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

Na przyszlosc zrobic z tego statica wzorzec singleton

 */
public class Kursor3D : MonoBehaviour {

	Vector3 position;

	public Material Clicked;
	public Material NonClicked;

	bool isClicked;
	bool isPressed;
	Collider obj;
	Vector3 lastPosition;
	public Vector3 delta;
	
	float t;
	void Start () {
		t = 0.1f;
		position = new Vector3(0.0f, 0.0f, 0.0f);
		isClicked = false;
		lastPosition = position;
		obj = null;
		isPressed = false;
	}
	
	
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)){
			position = Vector3.Lerp(position, position + new Vector3(-0.1f, 0.0f, 0.0f),t);
		} if(Input.GetKey(KeyCode.RightArrow)){
			position = Vector3.Lerp(position,position + new Vector3(0.1f, 0.0f, 0.0f),t);
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			position = Vector3.Lerp(position, position + new Vector3(0.0f, 0.0f, -0.1f),t);
		} if(Input.GetKey(KeyCode.UpArrow)){
			position = Vector3.Lerp(position, position + new Vector3(0.0f, 0.0f, 0.1f),t);
		}

		if(Input.GetKey(KeyCode.Q)){
			position = Vector3.Lerp(position, position + new Vector3(0.0f, 0.1f, 0.0f),t);
		} if(Input.GetKey(KeyCode.E)){
			position = Vector3.Lerp(position, position + new Vector3(0.0f, -0.1f, 0.0f),t);
		}

		if(Input.GetKey(KeyCode.LeftShift)){ 
			isClicked = !isClicked;
		} 

		if(Input.GetKey(KeyCode.LeftShift)){
			isPressed = true;
		} else {
			isPressed = false;
		}

		if(obj != null){
			if(isClicked){
				obj.transform.position =  Vector3.Lerp(obj.transform.position, (position - lastPosition) + obj.transform.position,1.0f);
				//obj.transform.SetParent(this.transform, true);
			}
			
		}
		delta = lastPosition - position;
		lastPosition = position;

	}

	public Vector3 GetPosition(){
		return position;
	}

	public bool IsPressed(){
		return isPressed;
	}

	
	void OnTriggerEnter(Collider other) {
		
		if(other.tag == "Block"){
			obj = other;
			if(isPressed){
				other.GetComponent<Rigidbody>().useGravity = false;
				other.GetComponent<Rigidbody>().isKinematic = true;
			} else {
				other.GetComponent<Rigidbody>().useGravity = true;
				other.GetComponent<Rigidbody>().isKinematic = false;
			}
			other.GetComponent<MeshRenderer>().material = Clicked;
		} 
	}

	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Block"){
			other.GetComponent<MeshRenderer>().material = Clicked;
			
			if(isClicked){
					obj = other;
					other.GetComponent<Rigidbody>().useGravity = false;
					other.GetComponent<Rigidbody>().isKinematic = true;
				} else {
					other.GetComponent<Rigidbody>().useGravity = true;
					other.GetComponent<Rigidbody>().isKinematic = false;
				}
		}
	}

	void OnTriggerExit(Collider other) {
		
		if(other.tag == "Block"){
			obj = null;
			if(!isClicked){
				other.GetComponent<Rigidbody>().useGravity = true;
				other.GetComponent<Rigidbody>().isKinematic = false;
				other.GetComponent<MeshRenderer>().material = NonClicked;
			}
			
		} 
	}
}
