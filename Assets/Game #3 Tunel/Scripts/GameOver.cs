using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	Image img;
	void Start () {
		img = GetComponent<Image>();
	}
	
	
	void Update () {
		if(img.fillAmount <= 1)
			img.fillAmount += 0.01f;
	}
}
