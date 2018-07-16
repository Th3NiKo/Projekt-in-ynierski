using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorOnBox : MonoBehaviour {

	[SerializeField] Vector3 position;
	[SerializeField] Vector3 deltas;

	public float MaxRangeInput = 10000;
	public float MaxRangeOutput = 4;

	public bool OnDeltas = false;

	private float Divide;
	public
	COM msg;
	void Start () {
		Divide = MaxRangeInput / MaxRangeOutput;
		
		msg = Camera.main.GetComponent<COM>();
	}
	
	
	void Update () {
		if(!OnDeltas){
			position = msg.LoadPositions ();
			Vector3 newPos = new Vector3(position.x / Divide, position.y / Divide, -position.z / Divide);
			this.transform.position = newPos;
		} else {
			Divide = 1000;
			position = msg.LoadPositions();
			deltas = msg.LoadDeltas();
			Vector3 newPos = new Vector3(transform.position.x + (deltas.x / Divide), transform.position.y + (deltas.y / Divide), transform.position.z -(deltas.z / Divide));
			newPos = new Vector3(Mathf.Clamp(newPos.x, -MaxRangeOutput, MaxRangeOutput),
								 Mathf.Clamp(newPos.y, -MaxRangeOutput, MaxRangeOutput),
								 Mathf.Clamp(newPos.z, -MaxRangeOutput, MaxRangeOutput));
			this.transform.position = newPos;
		}
		
	}
}
