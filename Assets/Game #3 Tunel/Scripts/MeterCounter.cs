using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterCounter : MonoBehaviour {

	Text meters;
	private float meterCount;
	void Start () {
		meterCount = 0.0f;
		meters = GetComponent<Text>();
	}
	
	void Update () {
		meterCount += Time.deltaTime * 15;
		
		meters.text = Mathf.CeilToInt(meterCount).ToString() + "m";
	}
}
