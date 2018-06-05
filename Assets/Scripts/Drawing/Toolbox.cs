using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour {

	Kursor3D kursor;
	public GameObject slider;
	GameObject sliderAlive;

	void Start () {
		kursor = GameObject.FindGameObjectWithTag("Kursor").GetComponent<Kursor3D>();
	}
	
	
	void Update () {

	}


	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Kursor"){
			if(kursor.IsPressed()){
				if(sliderAlive == null){
					sliderAlive = Instantiate(slider);
				}
			} else {
				sliderAlive = null;
			}
		}
		if(other.gameObject.name == "Sphere" || other.gameObject.name == "Cylinder"){
			Destroy(other.gameObject);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Kursor"){
			if(kursor.IsPressed()){
				if(sliderAlive == null){
					sliderAlive = Instantiate(slider);
				}
			} else {
				sliderAlive = null;
			}
		}
		if(other.gameObject.name == "Sphere" || other.gameObject.name == "Cylinder"){
			Destroy(other.gameObject);
		}
	}
	


}
