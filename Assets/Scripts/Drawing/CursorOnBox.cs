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
	public COM msg;
	public float box = 3;
	void Start () {
		Divide = MaxRangeInput / MaxRangeOutput;
		this.transform.position = new Vector3(0f,1.5f,0f);
		msg = Camera.main.GetComponent<COM>();
	}
	
	
	void Update () {
		if(!OnDeltas){
			position = msg.LoadPositions ();
			Vector3 newPos = new Vector3(position.x / Divide, position.y / Divide, -position.z / Divide);
			newPos = new Vector3(Mathf.Clamp(newPos.x, -box, box),
								 Mathf.Clamp(newPos.y, 0.15f, box),
								 Mathf.Clamp(newPos.z, -box, box));
			//this.transform.position = newPos;
			this.GetComponent<Rigidbody>().position = newPos;
		} else {
			Divide = 400;
			position = msg.LoadPositions();
			deltas = msg.LoadDeltas();
			Vector3 newPos = new Vector3(transform.position.x + (deltas.x / Divide), transform.position.y + (deltas.y / Divide), transform.position.z -(deltas.z / Divide));
			newPos = new Vector3(Mathf.Clamp(newPos.x, -box, box),
								 Mathf.Clamp(newPos.y, 0.15f, box),
								 Mathf.Clamp(newPos.z, -box, box));
			this.transform.position = newPos;
		}
		
	}

	private void OnCollisionEnter(Collision other) {
		
	}
}
