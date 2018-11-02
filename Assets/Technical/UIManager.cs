using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

	public float maxValue = 20000;
	public float min = -60000;
	public float max = 60000;
	COM msg;
	Vector3 position;
	Vector3 angle;
	Vector3 delta;

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

	//A1

	Image A1FillRight;
	Image A1FillLeft;
	TextMeshProUGUI A1Left;
	TextMeshProUGUI A1Right;
	TextMeshProUGUI A1Label;

	//A2
	GameObject A2;
	Image A2FillRight;
	Image A2FillLeft;
	TextMeshProUGUI A2Left;
	TextMeshProUGUI A2Right;
	TextMeshProUGUI A2Label;

	//A3
	GameObject A3;
	Image A3FillRight;
	Image A3FillLeft;
	TextMeshProUGUI A3Left;
	TextMeshProUGUI A3Right;
	TextMeshProUGUI A3Label;

	//Scale
	Image Tick;
	TextMeshProUGUI ScaleText;
	float scaleValue = 1;


	//Deltas
	float x;
	float y;
	float z;
	float a1; float lastA1;
	float a2; float lastA2;
	float a3; float lastA3;
	private float offset = 0.315f;
	private float offsetMove = 320;

	public bool Keyboard;

	void Start () {
		msg = Camera.main.GetComponent<COM>();
		
		//Reset deltas
		lastA1 = lastA2 = lastA3 = 0;

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

		//Get A1
		A1FillLeft = transform.GetChild(2).GetChild(1).GetComponent<Image>();
		A1FillRight = transform.GetChild(2).GetChild(0).GetComponent<Image>();
		A1Left = transform.GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>();
		A1Right = transform.GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>();
		A1Label = transform.GetChild(2).GetChild(5).GetComponent<TextMeshProUGUI>();

		//Get A2
		A2 = transform.GetChild(3).gameObject;
		A2FillLeft = transform.GetChild(3).GetChild(1).GetComponent<Image>();
		A2FillRight = transform.GetChild(3).GetChild(0).GetComponent<Image>();
		A2Left = transform.GetChild(3).GetChild(3).GetComponent<TextMeshProUGUI>();
		A2Right = transform.GetChild(3).GetChild(2).GetComponent<TextMeshProUGUI>();
		A2Label = transform.GetChild(3).GetChild(5).GetComponent<TextMeshProUGUI>();
		
		//Get A2
		A3 = transform.GetChild(4).gameObject;
		A3FillLeft = transform.GetChild(4).GetChild(1).GetComponent<Image>();
		A3FillRight = transform.GetChild(4).GetChild(0).GetComponent<Image>();
		A3Left = transform.GetChild(4).GetChild(3).GetComponent<TextMeshProUGUI>();
		A3Right = transform.GetChild(4).GetChild(2).GetComponent<TextMeshProUGUI>();
		A3Label = transform.GetChild(4).GetChild(5).GetComponent<TextMeshProUGUI>();

		//Scale
		Tick = transform.GetChild(5).GetChild(1).GetComponent<Image>();
		ScaleText = transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>();
	}

    private void FixedUpdate()
    {
        if (Keyboard)
        {
            if (Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.X))
            {
                if (msg.GetActualDevice() == COM.Device.Pen)
                {
                    scaleValue -= 10.0f;
                }
                else
                {
                    scaleValue -= 10.0f;
                }
            }
            else if (Input.GetKey(KeyCode.X) && !Input.GetKey(KeyCode.Z))
            {
                if (msg.GetActualDevice() == COM.Device.Pen)
                {
                    scaleValue += 10.0f;
                }
                else
                {
                    scaleValue += 10.0f;
                }
            }

            if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.X))
            {
                x = y = z = a1 = a2 = a3 = 0;
            }
        }
    }



    void Update () {

		//Scaling up and down
		Tick.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(
																			(scaleValue * offset) - offsetMove
																			,Tick.gameObject.GetComponent<RectTransform>().anchoredPosition.y 
																			,0
																			);
		if(msg.GetActualDevice() == COM.Device.Pen){
		 	ScaleText.text = (Mathf.Round(scaleValue * 100.0f) / 1000.0f).ToString();
		} else {
			ScaleText.text = (Mathf.Round(scaleValue * 100.0f) / 100.0f).ToString();
		}
        /*
		if(Keyboard){
			if(Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.X)){
				if(msg.GetActualDevice() == COM.Device.Pen){
					scaleValue -= 10f;
				} else {
					scaleValue -= 0.5f;
				}
			} else if(Input.GetKey(KeyCode.X) && !Input.GetKey(KeyCode.Z)){
				if(msg.GetActualDevice() == COM.Device.Pen){
					scaleValue += 10f;
				} else {
					scaleValue += 0.5f;
				}
			}

			if(Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.X)){
				x = y = z = a1 = a2 = a3 = 0;
			}
		} else {
			if(msg.ButtonPressed(0) && !msg.ButtonPressed(1)){
				if(msg.GetActualDevice() == COM.Device.Pen){
					scaleValue -= 10f;
				} else {
					scaleValue -= 0.5f;
				}
			} else if(msg.ButtonPressed(1) && !msg.ButtonPressed(1)){
				if(msg.GetActualDevice() == COM.Device.Pen){
					scaleValue += 10f;
				} else {
					scaleValue += 0.5f;
				}
			}

			if(msg.ButtonPressed(0) && msg.ButtonPressed(1)){
				x = y = z = a1 = a2 = a3 = 0;
			}
		}*/

		//Scale for each device
		if(msg.GetActualDevice() == COM.Device.Pen){
			offset = 0.315f;
			scaleValue = Mathf.Clamp(scaleValue, 10f, 2000.0f);
		} else {
			offsetMove = 315;
			scaleValue = Mathf.Clamp(scaleValue, 1f, 20.0f);
		}

		position = msg.LoadPositions();
		if(Mathf.Approximately(position.x, 0) ){
			x = 0;
		}



		if(msg.GetActualDevice() == COM.Device.Ufo){
			maxValue = 35000;
			angle = msg.LoadAngles();
			delta = msg.LoadDeltas();
		} else {
			delta = msg.LoadDeltas();
			maxValue = 60000;
		}
		
		//Scaling values
		position = new Vector3(position.x * scaleValue, position.y * scaleValue, position.z * scaleValue);
		angle = new Vector3(angle.x * scaleValue, angle.y * scaleValue, angle.z * scaleValue);


		//Deltas
		x += (delta.x * scaleValue);
		x = Mathf.Clamp(x, min, max);

		y += (delta.y * scaleValue);
		y = Mathf.Clamp(y,min, max);

		z += (delta.z * scaleValue);
		z = Mathf.Clamp(z,min,max);
		

		//X filling
		if(x >= 0){
			XFillLeft.fillAmount = 0;
			XFillRight.fillAmount = x / maxValue;
			
			XLeft.text = "";
			XRight.text = (Mathf.Round(x / scaleValue)).ToString();
		} else {
			XFillLeft.fillAmount = -x / maxValue;
			XFillRight.fillAmount = 0;
			
			XLeft.text = (Mathf.Round(x / scaleValue)).ToString();
			XRight.text = "";
		}

		//Y filling
		if(y >= 0){
			YFillLeft.fillAmount = 0;
			YFillRight.fillAmount = y / maxValue;
			
			YLeft.text = "";
			YRight.text = (Mathf.Round(y / scaleValue)).ToString();
		} else {
			YFillLeft.fillAmount = -y / maxValue;
			YFillRight.fillAmount = 0;
			
			YLeft.text = (Mathf.Round(y / scaleValue)).ToString();
			YRight.text = "";
		}

		if(msg.GetActualDevice() == COM.Device.Ufo){
			//Deltas count
			a1 += (lastA1 - angle.x) * scaleValue;
			a1 = Mathf.Clamp(a1,min,max);
			lastA1 = angle.x;

			a2 += (lastA2 - angle.y) * scaleValue;
			a2 = Mathf.Clamp(a2,min,max);
			lastA2 = angle.y;

			a3 += (lastA3 - angle.z) * scaleValue;
			a3 = Mathf.Clamp(a3,min,max);
			lastA3 = angle.z;
		
			//Angles
			//A1
			A1Label.text = "A1";
			

			
			if(a1 >= 0){
				A1FillLeft.fillAmount = 0;
				A1FillRight.fillAmount = a1 / maxValue;
			
				A1Left.text = "";
				A1Right.text = (Mathf.Round(a1 / scaleValue)).ToString();
			} else {
				A1FillLeft.fillAmount = -a1 / maxValue;
				A1FillRight.fillAmount = 0;
			
				A1Left.text = (Mathf.Round(a1 / scaleValue)).ToString();
				A1Right.text = "";
			}

			//A2
			if(!A2.activeSelf) { A2.SetActive(true); }
			A2Label.text = "A2";
			if(a2 >= 0){
				A2FillLeft.fillAmount = 0;
				A2FillRight.fillAmount = a2 / maxValue;
			
				A2Left.text = "";
				A2Right.text = (Mathf.Round(a2 / scaleValue)).ToString();
			} else {
				A2FillLeft.fillAmount = -a2 / maxValue;
				A2FillRight.fillAmount = 0;
			
				A2Left.text = (Mathf.Round(a2 / scaleValue)).ToString();
				A2Right.text = "";
			}

			//A3
			if(!A3.activeSelf) { A3.SetActive(true); }
			A3Label.text = "A3";
			if(a3 >= 0){
				A3FillLeft.fillAmount = 0;
				A3FillRight.fillAmount = a3 / maxValue;
			
				A3Left.text = "";
				A3Right.text = (Mathf.Round(a3 / scaleValue)).ToString();
			} else {
				A3FillLeft.fillAmount = -a3 / maxValue;
				A3FillRight.fillAmount = 0;
			
				A3Left.text = (Mathf.Round(a3 / scaleValue)).ToString();
				A3Right.text = "";
			}


		} else if(msg.GetActualDevice() == COM.Device.Pen){
			//Z
			A1Label.text = "Z";
			if(z >= 0){
				A1FillLeft.fillAmount = 0;
				A1FillRight.fillAmount = z / maxValue;
			
				A1Left.text = "";
				A1Right.text = (Mathf.Round(z / scaleValue)).ToString();
			} else {
				A1FillLeft.fillAmount = -z / maxValue;
				A1FillRight.fillAmount = 0;
			
				A1Left.text = (Mathf.Round(z / scaleValue)).ToString().ToString();
				A1Right.text = "";
			}

			//Turn off all others
			A2.SetActive(false);
			A3.SetActive(false);
		}


		
		
		
	}
}
