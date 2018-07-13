using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {

	COM msg;
	[SerializeField] Vector3 angles;
	GameObject tower;
	void Start () {
		msg = Camera.main.GetComponent<COM>();
		angles = msg.LoadAngles ();
		tower = GameObject.Find("Column");
	}
	
	
	void Update () {
		if(Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.LeftShift)){
			angles = msg.LoadAngles ();
				if(angles.y > 0){
					tower.transform.Rotate(new Vector3(tower.transform.rotation.eulerAngles.x, 100f * Time.deltaTime, 0.0f));
				} else {
					tower.transform.Rotate(new Vector3(tower.transform.rotation.eulerAngles.x, -100f * Time.deltaTime, 0.0f));
				}
		}
	}
}
