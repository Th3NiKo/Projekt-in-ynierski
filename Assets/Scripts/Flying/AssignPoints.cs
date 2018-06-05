using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignPoints : MonoBehaviour {

	
	void Start () {
		
	}
	
	
	void Update () {
		this.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = (ShipStats.GetPoints().ToString());
	}
}
