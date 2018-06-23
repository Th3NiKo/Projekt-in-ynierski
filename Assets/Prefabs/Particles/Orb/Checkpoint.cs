using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {


	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player"){
			//Add points
			ShipStats.AddPoints(10);
			//Make effect

			//Destroy
			Destroy(this.gameObject);
		}
	}
}
