using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;

	private Rigidbody rgb;
	private Kursor3D kursor3d;
	// Use this for initialization
	void Start () {
		rgb = GetComponent<Rigidbody>();
		kursor3d = GameObject.Find("Kursor").GetComponent<Kursor3D>();

		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//transform.position = Vector3.MoveTowards(rgb.position, kursor3d.GetComponent<Rigidbody>().position, 0.1f);
	}

	void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
		
	void OnMouseDrag(){
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		//rgb.velocity = Vector3.MoveTowards(rgb.position, cursorPosition, 0.1f);
		transform.position = cursorPosition;
	}
}
