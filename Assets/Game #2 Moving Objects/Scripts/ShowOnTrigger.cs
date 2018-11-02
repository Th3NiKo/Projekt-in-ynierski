using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnTrigger : MonoBehaviour {

	MeshRenderer rend;
	void Start () {
		rend = GetComponent<MeshRenderer>();
		rend.enabled = false;
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.name == "Cursor"){
			rend.enabled = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.name == "Cursor"){
			rend.enabled = false;
		}
	}
}
