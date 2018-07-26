using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorOnBox : MonoBehaviour {

	[SerializeField] Vector3 position;
	[SerializeField] Vector3 deltas;

	public float MaxRangeInput = 10000;
	public float MaxRangeOutput = 4;

	public bool OnDeltas = false;

	public float Divide = 400;
	public COM msg;
	public float box = 3;

	public Vector2 minMaxX;
	public Vector2 minMaxY;
	public Vector2 minMaxZ;

	bool lastWriting;

	void Start () {
		if(!OnDeltas){
			Divide = 8000;
		} else {
			Divide = 400;
		}
		this.transform.position = new Vector3(0f,1.5f,0f);
		msg = Camera.main.GetComponent<COM>();
		lastWriting = msg.IsWritingPen();
	}
	
	
	void Update () {

		if(msg.IsWritingPen() != lastWriting){
			if(msg.IsWritingPen()){
				Divide = 8000;
			} else {
				Divide = 400;
			}
		}

		if(msg.IsWritingPen()){
			OnDeltas = false;
		} else {
			OnDeltas = true;
		}
		if(Input.GetKey(KeyCode.R)){
			this.transform.position = new Vector3(0,1,0);
		}
		if(!OnDeltas){
		//Sensitivity
			if(Input.GetKey(KeyCode.Alpha1)){
				Divide += 50;
			
			} else if(Input.GetKey(KeyCode.Alpha2)){
				Divide -= 50;
			}
		} else {
			if(Input.GetKey(KeyCode.Alpha1)){
				Divide += 1;
			
			} else if(Input.GetKey(KeyCode.Alpha2)){
				Divide -= 1;
			}
		}
			//Divide = Mathf.Clamp(Divide,10, 1000);

		if(!OnDeltas){
			position = msg.LoadPositions ();
			Vector3 newPos = new Vector3(position.x / Divide, position.y / Divide, -position.z / Divide);
			newPos = new Vector3(Mathf.Clamp(newPos.x, minMaxX.x, minMaxX.y),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
								 Mathf.Clamp(newPos.y, minMaxY.x, minMaxY.y),
								 Mathf.Clamp(newPos.z, minMaxZ.x, minMaxZ.y));
			this.transform.position = newPos;
			//this.GetComponent<Rigidbody>().position = newPos;
		} else {
			position = msg.LoadPositions();
			deltas = msg.LoadDeltas();

			float eps = 2;
			if(deltas.x >= -eps && deltas.x <= eps){
				deltas.x = 0;
			}
			if(deltas.y >= -eps && deltas.y <= eps){
				deltas.y = 0;
			} 
			if(deltas.z >= -eps && deltas.z <= eps){
				deltas.z = 0;
			}

			Vector3 newPos = new Vector3(transform.position.x + (deltas.x / Divide), transform.position.y + (deltas.y / Divide), transform.position.z -(deltas.z / Divide));
			newPos = new Vector3(Mathf.Clamp(newPos.x, minMaxX.x, minMaxX.y),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
								 Mathf.Clamp(newPos.y, minMaxY.x, minMaxY.y),
								 Mathf.Clamp(newPos.z, minMaxZ.x, minMaxZ.y));
			this.transform.position = newPos;
		}
		lastWriting = msg.IsWritingPen();
	}


}
