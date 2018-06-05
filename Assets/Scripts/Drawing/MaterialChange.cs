using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour {

	
	Material thisMaterial;
	Kursor3D kursor;
	void Start () {
		thisMaterial = GetComponent<MeshRenderer>().material;
		kursor = GameObject.FindGameObjectWithTag("Kursor").GetComponent<Kursor3D>();
	}
	
	
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Kursor"){
			if(kursor.IsPressed()){
				other.transform.GetChild(0).GetComponent<Drawing>().material = thisMaterial;
			}
		} 

		
	}

	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Kursor"){
			if(kursor.IsPressed()){
				other.transform.GetChild(0).GetComponent<Drawing>().material = thisMaterial;
			}
		}

		if(other.gameObject.name == "Sphere" || other.gameObject.name == "Cylinder"){
			Destroy(other.gameObject);
		}
	}
}
