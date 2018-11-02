using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleClean : MonoBehaviour {

	public float angularSpeed = 100.0f;
	void Start(){
		//Give it random rotation 
		if(Random.Range(0,2) == 0) angularSpeed = -angularSpeed;
	}

	void FixedUpdate () {
        transform.Rotate(angularSpeed, 0, 0);
        if (this.transform.position.z < -5f){
			Destroy(this.gameObject);
		}
	}
}
