using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClamp : MonoBehaviour {

	public GameObject kursor;
	bool inside = true;
	void Start () {
		
	}
	
	
	void Update () {
		
	}


	void OnCollisionStay(Collision other)
	{
		if(other.gameObject.name == kursor.name){
			inside = true;
		}	else {
			inside = false;
		}
	}




}
