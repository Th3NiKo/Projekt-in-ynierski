using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AssignText : MonoBehaviour {

	MeteorSpawner meteorSpawner;


	void Start () {

		meteorSpawner = GameObject.Find("MeteorSpawner").GetComponent<MeteorSpawner>();
		
	}
	
	
	void Update () {
		this.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = (85 - (int)meteorSpawner.speedUp).ToString();
		
	}
}
