using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {

	private bool follow = true;
	private bool temporary = false;
	public Transform target;
	public Vector3 offset;
	

	COM com;
	DrawTest draw;

	void Start(){
		com = GetComponent<COM>();
		draw = GameObject.Find("Tube").GetComponent<DrawTest>();
	}


	void Update(){
		if(Input.GetKeyDown(KeyCode.C)){
			follow = !follow;
		}
		
		//2 button
		if(!draw.Keyboard && !com.IsWritingPen()){	
			if((com.ButtonPressed(1) || Input.GetKey(KeyCode.X)) && !com.ButtonPressed(0)){
				temporary = true;
			} 
			if(com.ButtonPressedUp(1) || Input.GetKeyUp(KeyCode.X)){
				temporary = false;
			}
		}

		//Writing pen
		if(!draw.Keyboard && com.IsWritingPen()){
			if(Input.GetKey(KeyCode.X) && (!com.ButtonPressed(0))){
				temporary = true;
			} 
			if(Input.GetKeyUp(KeyCode.X)){
				temporary = false;
			}
		}

		//Keyboard
		if(draw.Keyboard){
			if(Input.GetKey(KeyCode.X) && !Input.GetKey(KeyCode.Z)){
				temporary = true;
			}
			if(Input.GetKeyUp(KeyCode.X)){
				temporary = false;
			}
		}
	}
	void LateUpdate(){
		if(follow && !temporary){
			transform.position = target.position + offset;
		}
	}

}
