using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotate : MonoBehaviour {

	Kursor3D kursor;
	public Vector3 euler;
	void Start () {
		kursor = GameObject.Find("Kursor3D").GetComponent<Kursor3D>();
	}
	
	
	void Update () {
		euler = new Vector3(-kursor.GetAngles().z / 27,kursor.GetAngles().x / 27, -kursor.GetAngles().y / 27);
		transform.rotation = Quaternion.Euler(euler);
		transform.position = new Vector3(kursor.GetPosition().x / 5000.0f, 0.0f, kursor.GetPosition().y / 5000.0f);
	}
}
