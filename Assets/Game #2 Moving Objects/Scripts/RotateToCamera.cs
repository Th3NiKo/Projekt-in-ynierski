using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour {
	float startX;
	Rigidbody rgb;
	void Start () {
		rgb = GetComponent<Rigidbody>();
		startX = rgb.rotation.eulerAngles.x;
		RotateTowardsCamera();
		
	}
	
	
	void Update () {
		RotateTowardsCamera();
	}

	void RotateTowardsCamera(){/* 
		Vector3 lookVector = Camera.main.transform.position - transform.position;
		lookVector.y = transform.position.y - 80;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = rot;*/
		Vector3 targetPostition = new Vector3( Camera.main.transform.position.x, this.transform.position.y - 90 , Camera.main.transform.position.z ) ;
		rgb.transform.LookAt(targetPostition);
 		//this.transform.LookAt( targetPostition ) ;
		//Quaternion rotation = Quaternion.LookRotation(targetPostition);
		//this.transform.Rotate(rotation.eulerAngles);
		 

		//rgb.transform.rotation = Quaternion.Euler(-90, rgb.transform.rotation.eulerAngles.y, rgb.transform.rotation.eulerAngles.z);

	}
}
