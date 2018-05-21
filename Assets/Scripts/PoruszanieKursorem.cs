using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoruszanieKursorem : MonoBehaviour {

	Kursor3D kursor;
	void Start () {
		kursor = GetComponent<Kursor3D>();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = kursor.GetPosition();
	}
}
