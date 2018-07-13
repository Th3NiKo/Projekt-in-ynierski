using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeSlider : MonoBehaviour {

	Slider slider;
	Kursor3D kursor;
	DrawTest draw;
	PoruszanieKursorem movement;
	void Start () {
		slider = GetComponent<Slider>();
		kursor = GameObject.FindGameObjectWithTag("Kursor").GetComponent<Kursor3D>();
		movement = GameObject.FindGameObjectWithTag("Kursor").GetComponent<PoruszanieKursorem>();
		draw = GameObject.Find("Tube").GetComponent<DrawTest>();

		slider.value = draw.actualRadius;
		PoruszanieKursorem.BlockMovement();
	}
	
	
	void Update () {
		if(movement.position.x < 0){
			slider.value += 0.01f;
			draw.changeThickness(slider.value);
		} else if(movement.position.x > 0){
			slider.value -= 0.01f;
			draw.changeThickness(slider.value);
		}
		if(kursor.IsPressed() == false){
			PoruszanieKursorem.UnlockMovement();
			Destroy(this.gameObject);
		}
		
	}



}