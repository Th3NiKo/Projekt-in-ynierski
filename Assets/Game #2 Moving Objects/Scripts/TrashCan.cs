using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour {
	private void OnTriggerStay(Collider other) {
		if(other.tag == "Dragable" || other.tag == "Dragable - No Gravity"){
			Destroy(other.gameObject);
		}
	}
}
