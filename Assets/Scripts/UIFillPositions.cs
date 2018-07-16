using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFillPositions : MonoBehaviour {

	Text x;
	Text y;
	Text a1;
	Text a2; 
	Text a3;
	Image plugged;
	
	COM msg;

	void Start () {
		x = transform.GetChild (1).GetComponent<Text>();
		y = transform.GetChild (2).GetComponent<Text>();
		a1 = transform.GetChild (3).GetComponent<Text>();
		a2 = transform.GetChild (4).GetComponent<Text>();
		a3 = transform.GetChild (5).GetComponent<Text>();



		msg = Camera.main.GetComponent<COM>();

	}
	

	void FixedUpdate () {

			if(msg.GetActualDevice() == COM.Device.Pen){
				x.text = "X: " + msg.LoadPositions ().x.ToString ();
				y.text = "Y: " + msg.LoadPositions ().y.ToString ();
				a1.text = "Z: " + msg.LoadPositions().z.ToString ();
				a2.text = "DeltaX:: " + msg.LoadDeltas ().x.ToString ();
				a3.text = "DeltaY:: " + msg.LoadDeltas ().y.ToString ();
			} else {
				x.text = "X: " + msg.LoadPositions ().x.ToString ();
				y.text = "Y: " + msg.LoadPositions ().y.ToString ();
				a1.text = "A1: " + msg.LoadAngles().x.ToString ();
				a2.text = "A2: " + msg.LoadAngles ().y.ToString ();
				a3.text = "A3: " + msg.LoadAngles ().z.ToString ();
			}
			
	}

}
