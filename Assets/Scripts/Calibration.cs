using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Calibration : MonoBehaviour {

    COM com;
    public Image img;
    public Text text;

	void Start () {
        com = Camera.main.GetComponent<COM>();
        img.enabled = false;
        text.enabled = false;
	}
	
	
	void Update () {
       

        if (com.IsCalibrated() == 0) {
            img.enabled = false;
            text.enabled = false;
        } else {
            img.enabled = true;
            text.enabled = true;
        }
	}
}
