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

	void Start () {
		if(!OnDeltas){
			Divide = MaxRangeInput / MaxRangeOutput;
		}
		this.transform.position = new Vector3(0f,1.5f,0f);
		msg = Camera.main.GetComponent<COM>();
	}
	
	
	void Update () {
		//Sensitivity
		if(Input.GetKey(KeyCode.Alpha1)){
			Divide += 1;
		
		} else if(Input.GetKey(KeyCode.Alpha2)){
			Divide -= 1;
		}
			Divide = Mathf.Clamp(Divide,10, 1000);

		if(!OnDeltas){
			position = msg.LoadPositions ();
			Vector3 newPos = new Vector3(position.x / Divide, position.y / Divide, -position.z / Divide);
			newPos = new Vector3(Mathf.Clamp(newPos.x, minMaxX.x, minMaxX.y),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
								 Mathf.Clamp(newPos.y, minMaxY.x, minMaxY.y),
								 Mathf.Clamp(newPos.z, minMaxZ.x, minMaxZ.y));
			//this.transform.position = newPos;
			this.GetComponent<Rigidbody>().position = newPos;
		} else {
			position = msg.LoadPositions();
			deltas = msg.LoadDeltas();
			Vector3 newPos = new Vector3(transform.position.x + (deltas.x / Divide), transform.position.y + (deltas.y / Divide), transform.position.z -(deltas.z / Divide));
			newPos = new Vector3(Mathf.Clamp(newPos.x, minMaxX.x, minMaxX.y),                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
								 Mathf.Clamp(newPos.y, minMaxY.x, minMaxY.y),
								 Mathf.Clamp(newPos.z, minMaxZ.x, minMaxZ.y));
			this.transform.position = newPos;
		}
		
	}


}
