using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ColorsOverTime : MonoBehaviour {

	public PostProcessingProfile profile;
	void Start () {
		
	}
	
	
	void FixedUpdate () {
		ColorGradingModel.Settings colorSetting = profile.colorGrading.settings;
		colorSetting.basic.hueShift = (Mathf.Sin(Time.timeSinceLevelLoad / 4) * 180); 
		profile.colorGrading.settings = colorSetting;
	}
}
