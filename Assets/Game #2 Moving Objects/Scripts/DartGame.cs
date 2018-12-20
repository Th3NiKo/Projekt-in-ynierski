using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour {

	bool hit;
	Vector3 hitPosition;
	void Start () {
		hit = false;
		hitPosition = Vector3.zero;
	}
	
	
	void Update () {
		if(hit){
			//this.transform.position = hitPosition;
			this.transform.rotation = Quaternion.Euler(0,90,0);
			this.GetComponent<Rigidbody>().isKinematic = true;
		}
	}
	
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.name == "DartBoard")
		{
			hit = true;
			hitPosition = this.transform.position;
		}
	}

	void OnTriggerStay(Collider other) {
		if(other.gameObject.name == "Cursor"){
			this.transform.rotation = Quaternion.Euler(0,90,0);
		}
	}
}
