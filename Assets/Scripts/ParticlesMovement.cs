using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesMovement : MonoBehaviour {

	public GameObject particle1;
	public GameObject particle2;
	public GameObject follow;
	float position;
	float firstLenght;
	float secondLenght;
	void Start () {
		

	}
	
	
	void Update () {
		
		position = follow.transform.position.z;
		firstLenght = Mathf.Abs(position - particle1.transform.position.z);
		secondLenght = Mathf.Abs(position - particle2.transform.position.z);
		if(firstLenght == secondLenght){
			if(particle1.transform.position.z <  particle2.transform.position.z){
				particle1.transform.position = new Vector3(particle1.transform.position.x, particle1.transform.position.y, particle1.transform.position.z + 30.0f);
			} else {
			 	particle2.transform.position = new Vector3(particle1.transform.position.x, particle1.transform.position.y, particle1.transform.position.z + 30.0f);
			}
		}
	}
}
