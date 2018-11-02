using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x,-0.33f, 0.33f), Mathf.Clamp(this.transform.position.y, -0.33f, 0.33f), -4.853f);

	}
}
