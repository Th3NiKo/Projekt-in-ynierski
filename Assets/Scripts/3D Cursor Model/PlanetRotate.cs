using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotate : MonoBehaviour {

	Kursor3D kursor;
	void Start () {
		kursor = GameObject.Find("Kursor3D").GetComponent<Kursor3D>();
	}
	
	
	void Update () {
		transform.rotation = Quaternion.Euler(kursor.GetAngles().x, kursor.GetAngles().y,kursor.GetAngles().z);
	}
}
