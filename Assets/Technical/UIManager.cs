using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

	public float maxValue = 20000;
	COM msg;
	Vector3 position;
	Vector3 angle;
	Vector3 delta;

	//All Fields access
	//X
	Image XFillRight;
	Image XFillLeft;
	TextMeshProUGUI XLeft;
	TextMeshProUGUI XRight;

	//Y
	Image YFillRight;
	Image YFillLeft;
	TextMeshProUGUI YLeft;
	TextMeshProUGUI YRight;

	


	void Start () {
		msg = Camera.main.GetComponent<COM>();

		//Get X
		XFillLeft = transform.GetChild(0).GetChild(1).GetComponent<Image>();
		XFillRight = transform.GetChild(0).GetChild(0).GetComponent<Image>();
		XLeft = transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();
		XRight = transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();

		//Get Y
		YFillLeft = transform.GetChild(1).GetChild(1).GetComponent<Image>();
		YFillRight = transform.GetChild(1).GetChild(0).GetComponent<Image>();
		YLeft = transform.GetChild(1).GetChild(3).GetComponent<TextMeshProUGUI>();
		YRight = transform.GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>();

		//Get A1 A2 A3 for UFO

		//Get Z for PEN

	}
	
	
	void Update () {
		position = msg.LoadPositions();

		//X filling
		if(position.x >= 0){
			XFillLeft.fillAmount = 0;
			XFillRight.fillAmount = position.x / maxValue;
			
			XLeft.text = "";
			XRight.text = position.x.ToString();
		} else {
			XFillLeft.fillAmount = -position.x / maxValue;
			XFillRight.fillAmount = 0;
			
			XLeft.text = position.x.ToString();
			XRight.text = "";
		}

		//Y filling
		if(position.y >= 0){
			YFillLeft.fillAmount = 0;
			YFillRight.fillAmount = position.y / maxValue;
			
			YLeft.text = "";
			YRight.text = position.y.ToString();
		} else {
			YFillLeft.fillAmount = -position.y / maxValue;
			YFillRight.fillAmount = 0;
			
			YLeft.text = position.y.ToString();
			YRight.text = "";
		}
		
	}
}
