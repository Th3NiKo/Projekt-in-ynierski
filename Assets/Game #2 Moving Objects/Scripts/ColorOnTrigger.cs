using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOnTrigger : MonoBehaviour {


	Renderer rend;
	
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	void OnTriggerStay(Collider col){
		if (col.name == "Cursor") {
			rend.material.color = new Vector4 (0.1f,0.1f,0.1f,0.5f);;
		} 
	}

	void OnTriggerExit(Collider col){
		if (col.name == "Cursor") {
			rend.material.color = Color.white;
		}
	}
}
