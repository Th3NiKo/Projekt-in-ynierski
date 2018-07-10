using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOnTriiger : MonoBehaviour {

	[SerializeField] Color NormalColor;
	[SerializeField] Color OnTriggerColor;

	Renderer rend;

	bool isSelected;

	void Start(){
		rend = GetComponent<Renderer>();

		NormalColor = rend.material.color;
		OnTriggerColor = Color.green;

		isSelected = false;
	}
	void FixedUpdate()
	{
		isSelected = false;
	}

	void Update(){
		if(isSelected){
			rend.material.color = OnTriggerColor;
		} else {
			rend.material.color = NormalColor;
		}
	}
	private void OnTriggerStay(Collider other) {
		if(other.tag == "Kursor"){
			isSelected = true;
		}
	}

	
}
