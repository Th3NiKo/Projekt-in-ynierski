using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVR : MonoBehaviour {

	public float angle = 5;
	public float shift = 0.3f;
	void Start () {
		//Instantiate eyes
		GameObject leftEye = Instantiate(this.gameObject);
		GameObject rightEye = Instantiate(this.gameObject);

		//Parent objects
		leftEye.transform.parent = this.gameObject.transform;
		rightEye.transform.parent = this.gameObject.transform;

		//Turn Off camera on main
		this.GetComponent<Camera>().enabled = false;

		//Turn off COM on eyes
		leftEye.GetComponent<COM>().enabled = false;
		rightEye.GetComponent<COM>().enabled = false;

		//Move on X eyes
		//If has camera look at 
		if(leftEye.GetComponent<CameraLookAt>()){
			leftEye.GetComponent<CameraLookAt>().offset.x -= shift;
			rightEye.GetComponent<CameraLookAt>().offset.x += shift;
		} else { 
			//Without camera look at
			leftEye.transform.position = new Vector3(leftEye.transform.position.x - shift, 
													 leftEye.transform.position.y, 
													 leftEye.transform.position.z);
			rightEye.transform.position = new Vector3(rightEye.transform.position.x + shift, 
													 rightEye.transform.position.y, 
													 rightEye.transform.position.z);
		}

		//Change angle of eyes
		leftEye.transform.rotation = Quaternion.Euler(leftEye.transform.rotation.eulerAngles.x,
													  leftEye.transform.rotation.eulerAngles.y + angle,
													  leftEye.transform.rotation.eulerAngles.z);
		rightEye.transform.rotation = Quaternion.Euler(rightEye.transform.rotation.eulerAngles.x,
													  rightEye.transform.rotation.eulerAngles.y - angle,
													  rightEye.transform.rotation.eulerAngles.z);

		//Split screens to see two eyes 
		leftEye.GetComponent<Camera>().rect = new Rect(0,0,0.5f, 1.0f);
		rightEye.GetComponent<Camera>().rect = new Rect(0.5f,0,0.5f, 1.0f);

	}
	
	
}
