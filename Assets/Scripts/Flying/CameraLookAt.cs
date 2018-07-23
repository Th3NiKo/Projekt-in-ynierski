using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {

	private bool follow = true;
	private bool temporary = false;
	public Transform target;
	public Vector3 offset;


	void Update(){
		if(Input.GetKeyDown(KeyCode.C)){
			follow = !follow;
		}
		
		if(Input.GetKey(KeyCode.X) && !Input.GetKey(KeyCode.Z)){
			temporary = true;
		}
		if(Input.GetKeyUp(KeyCode.X)){
			temporary = false;
		}
	}
	void LateUpdate(){
		if(follow && !temporary){
			transform.position = target.position + offset;
		}
	}

}
