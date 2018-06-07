using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDestroyer : MonoBehaviour {

	
	void Start () {
		
	}
	
	
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other) {
		if(other.transform.tag == "Meteor"){
			if(other.transform.parent != null)
				Destroy(other.transform.parent.gameObject);
		}
	}
}
