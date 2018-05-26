using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeSlider : MonoBehaviour {

	Slider slider;
	Kursor3D kursor;
	Drawing draw;
	void Start () {
		slider = GetComponent<Slider>();
		kursor = GameObject.FindGameObjectWithTag("Kursor").GetComponent<Kursor3D>();
		draw = GameObject.FindGameObjectWithTag("Kursor").transform.GetChild(0).GetComponent<Drawing>();
		slider.value = draw.thickness;
		PoruszanieKursorem.BlockMovement();
	}
	
	
	void Update () {
		if(kursor.delta.x < 0){
			slider.value += 0.01f;
			draw.changeThickness(slider.value);
		} else if(kursor.delta.x > 0){
			slider.value -= 0.01f;
			draw.changeThickness(slider.value);
		}
		if(kursor.IsPressed() == false){
			PoruszanieKursorem.UnlockMovement();
			Destroy(this.gameObject);
		}
		
	}



}
