using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class UIManagerOffice : MonoBehaviour {

	TextMeshProUGUI sensitivityText;

	MessageReceiver com;
	CursorOnBox1 kursor;
	private Color actualColor;

	//Check for change
	float lastSensitivity;

	void Start () {
		com = Camera.main.GetComponent<MessageReceiver>();
		actualColor = new Vector4(1,1,1,0);
		sensitivityText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		kursor = GameObject.Find("Cursor").GetComponent<CursorOnBox1>();
		lastSensitivity = kursor.Divide;
	}
	
	void Update() {
		if(lastSensitivity != kursor.Divide){
			Sequence sequence = DOTween.Sequence();
			sequence.Append(DOTween.ToAlpha(()=> actualColor, x=> actualColor = x, 1, 1));
			sequence.Append(DOTween.ToAlpha(()=> actualColor, x=> actualColor = x, 0, 1));
			
		}
		lastSensitivity = kursor.Divide;
		
	}
	void OnGUI() {
		sensitivityText.color = actualColor;
		sensitivityText.text ="Sensitivity: " + (1010-kursor.Divide).ToString();
	}
}
