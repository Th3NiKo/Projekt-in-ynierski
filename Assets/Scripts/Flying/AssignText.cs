using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AssignText : MonoBehaviour {


	ShipMovement movement;


	void Start () {

		movement = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipMovement>();
		
	}
	
	
	void Update () {
		
		this.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = (Mathf.FloorToInt(Mathf.Abs(movement.GetComponent<Rigidbody>().velocity.z)) * 10).ToString();
		
	}
}
