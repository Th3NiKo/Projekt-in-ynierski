using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class DrawingUI : MonoBehaviour {

	TextMeshProUGUI sensitivityText;
	TextMeshProUGUI deviceText;
	COM com;
	CursorOnBox kursor;
	private Color actualColor;
	private Color deviceColor;

	//Check for change
	float lastSensitivity;

	bool lastDevice;
	void Start () {
		com = Camera.main.GetComponent<COM>();
		lastDevice = false;
		actualColor = new Vector4(1,1,1,0);
		deviceColor = new Vector4(1,1,1,0);
		sensitivityText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		deviceText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
		kursor = GameObject.Find("Kursor").GetComponent<CursorOnBox>();
		lastSensitivity = kursor.Divide;
	}
	
	void Update() {
		if(lastSensitivity != kursor.Divide){
			Sequence sequence = DOTween.Sequence();
			sequence.Append(DOTween.ToAlpha(()=> actualColor, x=> actualColor = x, 1, 1));
			sequence.Append(DOTween.ToAlpha(()=> actualColor, x=> actualColor = x, 0, 1));
			
		}
		
		if(lastDevice != com.IsWritingPen()){
			Sequence sequence = DOTween.Sequence();
			sequence.Append(DOTween.ToAlpha(()=> deviceColor, x=> deviceColor = x, 1, 1));
			sequence.Append(DOTween.ToAlpha(()=> deviceColor, x=> deviceColor = x, 0, 1));
		}
		lastDevice = com.IsWritingPen();
		lastSensitivity = kursor.Divide;
		
	}
	void OnGUI() {
		sensitivityText.color = actualColor;
		sensitivityText.text ="Sensitivity: " + (15000-kursor.Divide).ToString();


		deviceText.color = deviceColor;
		if(com.IsWritingPen()){
			deviceText.text ="Device: Write Pen";
		} else {
			deviceText.text ="Device: 2 Buttons Pen";
		}
		
	}
}
