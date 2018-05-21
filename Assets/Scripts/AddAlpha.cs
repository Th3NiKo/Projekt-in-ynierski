using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddAlpha : MonoBehaviour {

	float alpha = 0;

	Image img;
	void Start () {
		img = this.GetComponent<Image>();
	}
	
	
	void Update () {
		if(alpha <= 255){
			alpha+= 0.01f;
		}
		img.color = new Vector4(img.color.r,img.color.g,img.color.b,alpha);
	}
}
