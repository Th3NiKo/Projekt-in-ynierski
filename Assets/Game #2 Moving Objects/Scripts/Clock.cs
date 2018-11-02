using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Clock : MonoBehaviour {

	public TextMesh hours;
	public TextMesh minutes;
	
	void Start(){
		SetTime();
	}
	void FixedUpdate () {
		if(DateTime.Now.Second <= 1){
			//Refresh timer
			SetTime();
		}
	}

	void SetTime(){
		if(DateTime.Now.Hour.ToString().Length < 2){
			hours.text = "0" + DateTime.Now.Hour.ToString();
		} else {
			hours.text = DateTime.Now.Hour.ToString();
		}
		if(DateTime.Now.Minute.ToString().Length < 2){
			minutes.text = "0" + DateTime.Now.Minute.ToString();
		} else {
			minutes.text = DateTime.Now.Minute.ToString();
		}

		
	}
}
