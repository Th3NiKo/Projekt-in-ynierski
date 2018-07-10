using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {

	COM msg;
	[SerializeField] Vector3 angles;
	private Vector3 lastAngles;
	void Start () {
		msg = Camera.main.GetComponent<COM>();
		angles = msg.LoadAngles ();
		lastAngles = angles;
	}
	
	
	void Update () {
		angles = msg.LoadAngles ();
		if(Mathf.Abs(lastAngles.x - angles.x) >= 75f){
			if(lastAngles.x - angles.x > 0){
				Camera.main.transform.RotateAround(new Vector3(0,0,0), new Vector3(0,1,0), 5);
			} else {
				Camera.main.transform.RotateAround(new Vector3(0,0,0), new Vector3(0,1,0), -5);
			}
		}




		lastAngles = angles;
	}
}
